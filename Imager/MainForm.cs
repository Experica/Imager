/*
MainForm.cs is part of the Imager.
Copyright (c) 2021 Li Alex Zhang and Contributors

Permission is hereby granted, free of charge, to any person obtaining a 
copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included 
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF 
OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using PvDotNet;
using PvGUIDotNet;
using Ice;

namespace Imager
{
    public partial class MainForm : Form
    {
        // Handler used to bring link disconnected event in the main UI thread
        Action mDisconnectedHandler = null;

        // Handler used to bring acquisition mode changed event in the main UI thread
        Action mAcquisitionModeChangedHandler = null;

        // Handler used to bring acquisition state manager callbacks in the main UI thread
        Action mAcquisitionStateChangedHandler = null;

        Action mRecordStoppedHandler = null;

        public Action<bool> mRecordCheckedHandler = null;

        // Main application objects: device, stream, pipeline
        private PvDevice mDevice = null;
        private PvStream mStream = null;
        private PvPipeline mPipeline = null;

        // Acquisition state manager
        private PvAcquisitionStateManager mAcquisitionManager = null;

        // Display thread
        private PvDisplayThread mDisplayThread = null;

        // Parameter browsers
        private BrowserForm mCommBrowser = new BrowserForm();
        private BrowserForm mDeviceBrowser = new BrowserForm();
        private BrowserForm mStreamBrowser = new BrowserForm();

        public Recorder recorder = new Recorder();
        const string configpath = "Config.yaml";
        Config config;
        Communicator communicator;
        bool iscolormap = false;
        bool isdisplay = true;
        PvBufferConverter mBufferConverter = new PvBufferConverter(Environment.ProcessorCount);
        PvBuffer mPvBuffer = new PvBuffer(PvPayloadType.Image);

        public MainForm()
        {
            InitializeComponent();

            // Handlers used to callbacks in the UI thread
            mDisconnectedHandler += OnDisconnected;
            mAcquisitionModeChangedHandler += OnAcquisitionModeChanged;
            mAcquisitionStateChangedHandler += OnAcquisitionStateChanged;
            mRecordStoppedHandler += OnRecordStopped;
            mRecordCheckedHandler += OnRecordChecked;

            // Set browser form owners
            mCommBrowser.Owner = this;
            mDeviceBrowser.Owner = this;
            mStreamBrowser.Owner = this;

            // Create display thread, hook event
            mDisplayThread = new PvDisplayThread();
            mDisplayThread.OnBufferDisplay += DisplayThread_OnBufferDisplay;
            mDisplayThread.OnBufferDone += DisplayThread_OnBufferDone;

            DataFormat.DataSource = Enum.GetNames(typeof(DataFormat));
            DataFormat.SelectedIndex = 0;

            var displaymenu = display.ContextMenuStrip;
            displaymenu.Items.Add(new ToolStripSeparator());
            displaymenu.Items.Add("Create ROI").Click += CreateROI_Click;
            displaymenu.Items.Add("Upload ROI").Click += UploadROI_Click;
            displaymenu.Items.Add(new ToolStripSeparator());
            displaymenu.Items.Add("Clear ROI").Click += ClearROI_Click;
        }

        void UploadROI_Click(object sender, EventArgs e)
        {
            if (display.ROI.IsEmpty)
            {
                if (MessageBox.Show("Set Full Frame?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Play.Checked = false;
                    mDevice.Parameters.SetIntegerValue("OffsetX", 0);
                    mDevice.Parameters.SetIntegerValue("OffsetY", 0);
                    mDevice.Parameters.SetIntegerValue("Width", mDevice.Parameters.GetIntegerValue("WidthMax"));
                    mDevice.Parameters.SetIntegerValue("Height", mDevice.Parameters.GetIntegerValue("HeightMax"));
                    display.ClearROI();
                    Play.Checked = true;
                    IsDisplay.Checked = true;
                }
                else
                {
                    display.ClearROI();
                }
            }
            else
            {
                // minimum 2 increments for X Axis, 1 increments for Y Axis
                var w = (display.ROI.Width % 2 == 1) ? display.ROI.Width + 1 : display.ROI.Width;
                var h = display.ROI.Height;
                var x = (display.ROI.X % 2 == 1) ? display.ROI.X + 1 : display.ROI.X;
                var y = display.ROI.Y;
                if (MessageBox.Show($"Set Frame ROI: Width={w}, Height={h}, OffsetX={x}, OffsetY={y}?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Play.Checked = false;
                    mDevice.Parameters.SetIntegerValue("OffsetX", 0);
                    mDevice.Parameters.SetIntegerValue("OffsetY", 0);
                    mDevice.Parameters.SetIntegerValue("Width", w);
                    mDevice.Parameters.SetIntegerValue("Height", h);
                    mDevice.Parameters.SetIntegerValue("OffsetX", x);
                    mDevice.Parameters.SetIntegerValue("OffsetY", y);
                    display.ClearROI();
                    Play.Checked = true;
                    IsDisplay.Checked = true;
                }
                else
                {
                    display.ClearROI();
                }
            }
        }

        void ClearROI_Click(object sender, EventArgs e)
        {
            display.ClearROI();
            UploadROI_Click(null, null);
        }

        void CreateROI_Click(object sender, EventArgs e)
        {
            IsDisplay.Checked = false;
            display.CreateROI();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
            UpdateFromConfig();
            EnableUI();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            UpdateToConfig();
            SaveConfig();
        }

        void LoadConfig()
        {
            if (File.Exists(configpath))
            {
                config = configpath.ReadYamlFile<Config>();
            }
            if (config == null)
            {
                config = new Config();
            }
        }

        void UpdateFromConfig()
        {
            DataDir.Text = config.DataDir;
            RecordName.Text = config.RecordName;
            DataFormat.SelectedIndex = (int)config.DataFormat;
            AvgBitRate.Minimum = config.MinAvgBitrate;
            AvgBitRate.Maximum = config.MaxAvgBitrate;
            AvgBitRate.Value = config.AvgBitrate;
            ServerIP.Text = config.ServerAddress;
            ServerPort.Value = config.ServerPort;
            Server.Checked = config.EnableServer;
            mDisplayThread.VSyncEnabled = config.DisplayVSync;
            mDisplayThread.TargetFPS = config.DisplayTargetFPS;
        }

        void UpdateToConfig()
        {
            config.DataDir = DataDir.Text;
            config.RecordName = RecordName.Text;
            config.DataFormat = (DataFormat)DataFormat.SelectedIndex;
            config.AvgBitrate = (uint)AvgBitRate.Value;
            config.EnableServer = Server.Checked;
            config.ServerAddress = ServerIP.Text;
            config.ServerPort = (ushort)ServerPort.Value;
            config.DisplayVSync = mDisplayThread.VSyncEnabled;
            config.DisplayTargetFPS = mDisplayThread.TargetFPS;
        }

        void DeviceUpdateFromConfig()
        {
            config.ImageFormat.Write(mDevice.Parameters);
            config.AcquisitionControl.Write(mDevice.Parameters);
        }

        void DeviceUpdateToConfig()
        {
            config.ImageFormat.Read(mDevice.Parameters);
            config.AcquisitionControl.Read(mDevice.Parameters);
        }

        void SaveConfig(string filepath = configpath, bool ismeta = false)
        {
            if (ismeta)
            {
                var cm = config.ColorMap;
                config.ColorMap = null;
                filepath.WriteYamlFile(config);
                config.ColorMap = cm;
            }
            else
            { filepath.WriteYamlFile(config); }
        }

        void EnableUI()
        {
            connectButton.Enabled = mDevice == null;
            disconnectButton.Enabled = mDevice != null;

            EnableTreeBrowsers();
            EnableAcquisitionUI();
        }

        void EnableTreeBrowsers()
        {
            communicationButton.Enabled = mDevice != null;
            deviceButton.Enabled = mDevice != null;
            streamButton.Enabled = mDevice != null;
        }

        void EnableAcquisitionUI()
        {
            if (mAcquisitionManager == null)
            {
                // Not connected, disable all
                modeComboBox.Enabled = false;
                Play.Enabled = false;
                Play.BackColor = DefaultBackColor;
                SaveImage.Enabled = false;
                Record.Enabled = false;
                Record.BackColor = DefaultBackColor;
            }
            else
            {
                Play.Enabled = true;
                Play.BackColor = Color.PaleGreen;
                var isplaying = mAcquisitionManager.State == PvAcquisitionState.Locked;
                modeComboBox.Enabled = !isplaying;
                SaveImage.Enabled = isplaying;
                Record.Enabled = isplaying;
                Record.BackColor = isplaying ? Color.LightSkyBlue : DefaultBackColor;
            }
        }

        void connectButton_Click(object sender, EventArgs e)
        {
            // Create and open device selection dialog
            PvDeviceFinderForm devfinddlg = new PvDeviceFinderForm();
            if ((devfinddlg.ShowDialog() != DialogResult.OK) || (devfinddlg.Selected == null))
            {
                return;
            }
            Cursor old = Cursor;
            Cursor = Cursors.WaitCursor;
            Connect(devfinddlg.Selected);
            Cursor = old;
        }

        void disconnectButton_Click(object sender, EventArgs e)
        {
            Cursor old = Cursor;
            Cursor = Cursors.WaitCursor;
            Disconnect();
            Cursor = old;
        }

        void Connect(PvDeviceInfo devinfo)
        {
            // Just in case we came here still connected
            Disconnect();

            if (devinfo == null)
            {
                MessageBox.Show("No Device to Connect.", Text);
                return;
            }

            try
            {
                mDevice = PvDevice.CreateAndConnect(devinfo);
                mStream = PvStream.CreateAndOpen(devinfo);

                // GigE Vision specific connection steps
                if (devinfo.Type == PvDeviceInfoType.GEV)
                {
                    PvDeviceGEV lDeviceGEV = mDevice as PvDeviceGEV;
                    PvStreamGEV lStreamGEV = mStream as PvStreamGEV;
                    lDeviceGEV.NegotiatePacketSize();
                    lDeviceGEV.SetStreamDestination(lStreamGEV.LocalIPAddress, lStreamGEV.LocalPort);
                }
                DeviceUpdateFromConfig();
                mPipeline = new PvPipeline(mStream)
                {
                    BufferCount = Math.Max(4, config.BufferCount),
                    HandleBufferTooSmall = config.BufferAutoResize
                };
            }
            catch (PvException ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnect();
                return;
            }

            // Register update event of all the parameters in the device's node map
            foreach (PvGenParameter lParameter in mDevice.Parameters)
            {
                lParameter.OnParameterUpdate += OnParameterChanged;
            }

            mDevice.OnLinkDisconnected += OnLinkDisconnected;
            UpdateAttributes(devinfo);

            // Fill acquisition mode
            modeComboBox.Items.Clear();
            PvGenEnum lMode = mDevice.Parameters.GetEnum("AcquisitionMode");
            if (lMode != null)
            {
                foreach (PvGenEnumEntry lEntry in lMode)
                {
                    if (lEntry.IsAvailable)
                    {
                        int lIndex = modeComboBox.Items.Add(lEntry.ValueString);
                        if (lEntry.ValueInt == lMode.ValueInt)
                        {
                            modeComboBox.SelectedIndex = lIndex;
                        }
                    }
                }
            }

            // Ready image reception
            StartStreaming();

            // Sync the UI with our new status
            EnableUI();
        }

        void Disconnect()
        {
            StopStreaming();

            // Close all configuration child windows
            mDeviceBrowser.Browser.GenParameterArray = null;
            CloseGenWindow(mDeviceBrowser);
            mStreamBrowser.Browser.GenParameterArray = null;
            CloseGenWindow(mStreamBrowser);

            if (mPipeline != null)
            {
                config.BufferCount = mPipeline.BufferCount;
                config.BufferAutoResize = mPipeline.HandleBufferTooSmall;
                mPipeline.Dispose();
                mPipeline = null;
            }

            if (mStream != null)
            {
                mStream.Close();
                mStream.Dispose();
                mStream = null;
            }

            if (mDevice != null)
            {
                if (mDevice.IsConnected)
                {
                    DeviceUpdateToConfig();
                    mDevice.OnLinkDisconnected -= OnLinkDisconnected;
                    foreach (PvGenParameter lP in mDevice.Parameters)
                    {
                        lP.OnParameterUpdate -= OnParameterChanged;
                    }
                    mDevice.Disconnect();
                    mDevice.Dispose();
                    mDevice = null;
                }
            }

            display.Clear();
            UpdateAttributes(null);
            statusControl.Warning = "";

            // Sync the UI with our new status
            EnableUI();
        }

        void UpdateAttributes(PvDeviceInfo devinfo)
        {
            string lVendorName = "";
            string lModelName = "";
            string lMACAddress = "";
            string lIPAddress = "";
            string lGUID = "";
            string lUserDefinedName = "";

            if (devinfo != null)
            {
                // Get device attributes
                lVendorName = devinfo.VendorName;
                lModelName = devinfo.ModelName;
                lMACAddress = "N/A";
                lIPAddress = "N/A";
                lGUID = "N/A";
                lUserDefinedName = devinfo.UserDefinedName;

                // GigE Vision specific device attributes
                if (devinfo is PvDeviceInfoGEV lDeviceInfoGEV)
                {
                    lMACAddress = lDeviceInfoGEV.MACAddress;
                    lIPAddress = lDeviceInfoGEV.IPAddress;
                }

                // USB3 Vision specific device attributes
                if (devinfo is PvDeviceInfoU3V lDeviceInfoU3V)
                {
                    lGUID = lDeviceInfoU3V.DeviceGUID;
                }
            }

            manufacturerTextBox.Text = lVendorName;
            modelTextBox.Text = lModelName;
            macAddressTextBox.Text = lMACAddress;
            ipAddressTextBox.Text = lIPAddress;
            guidTextBox.Text = lGUID;
            nameTextBox.Text = lUserDefinedName;
        }

        /// <summary>
        /// Setups streaming. After calling this method the application is ready to receive data.
        /// StartAcquisition will instruct the device to actually start sending data.
        /// </summary>
        void StartStreaming()
        {
            statusControl.Stream = mStream;
            statusControl.DisplayThread = mDisplayThread;

            mDisplayThread.Start(mPipeline, mDevice.Parameters);
            mDisplayThread.Priority = PvThreadPriority.AboveNormal;

            mAcquisitionManager = new PvAcquisitionStateManager(mDevice, mStream);
            mAcquisitionManager.OnAcquisitionStateChanged += OnAcquisitionStateChanged;

            mPipeline.Start();
        }

        /// <summary>
        /// Stops streaming. After calling this method the application is no longer armed or ready to receive data.
        /// </summary>
        void StopStreaming()
        {
            if (!mDisplayThread.IsRunning)
            {
                return;
            }

            // Status control is configured in StartStreaming, must release resources in StopStreaming
            statusControl.Stream = null;
            statusControl.DisplayThread = null;

            mDisplayThread.Stop(false);

            mAcquisitionManager.Dispose();
            mAcquisitionManager = null;

            if (mPipeline.IsStarted)
            {
                mPipeline.Stop();
            }

            // Wait on display thread
            mDisplayThread.WaitComplete();
        }

        void DisplayThread_OnBufferDisplay(PvDisplayThread aDisplayThread, PvBuffer aBuffer)
        {
            if (!isdisplay) { return; }

            if (iscolormap && config.ColorMap != null)
            {
                // convert current buffer to same size buffer with BGRA8 pixels(display internal buffer format)
                mBufferConverter.Convert(aBuffer, mPvBuffer, true);
                // color mapping
                unsafe
                {
                    Parallel.For(0, mPvBuffer.Image.Width * mPvBuffer.Image.Height, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
                       {
                           // BGRA 8 bits per channel. Reads B-G-R-A from lowest to highest byte address
                           var pB = mPvBuffer.Image.DataPointer + 4 * i;
                           var pG = pB + 1;
                           var pR = pB + 2;
                           // RGB 8 bits per channel in colormap
                           *pR = config.ColorMap[*pR][0];
                           *pG = config.ColorMap[*pG][1];
                           *pB = config.ColorMap[*pB][2];
                       });
                }
                display.Display(mPvBuffer);
            }
            else
            {
                display.Display(aBuffer);
            }
        }

        void DisplayThread_OnBufferDone(PvDisplayThread aDisplayThread, PvBuffer aBuffer)
        {
            switch (recorder.RecordStatus)
            {
                case RecordStatus.Recording:
                    recorder.SaveImage(aBuffer);
                    return;
                case RecordStatus.Stopping:
                    recorder.StopMP4();
                    BeginInvoke(mRecordStoppedHandler);
                    recorder.RecordStatus = RecordStatus.Stopped;
                    return;
            }
        }

        void OnRecordStopped()
        {
            UpdateToConfig();
            DeviceUpdateToConfig();
            SaveConfig($"{recorder.RecordPath}.meta.yaml", true);
            recorder.RecordPath = null;
            Record.Text = "Start Record";
        }

        /// <summary>
        /// GenICam parameter invalidation event, registered for all parameters.
        /// </summary>
        /// <param name="aParameter"></param>
        void OnParameterChanged(PvGenParameter aParameter)
        {
            string lName = aParameter.Name;
            if (lName == "AcquisitionMode")
            {
                // Have main UI thread update the acquisition mode combo box status
                BeginInvoke(mAcquisitionModeChangedHandler);
            }
        }

        /// <summary>
        /// Acquisition mode event handler in main thread.
        /// </summary>
        private void OnAcquisitionModeChanged()
        {
            // Get parameter
            PvGenEnum lParameter = mDevice.Parameters.GetEnum("AcquisitionMode");

            // Update value: find which matches in the combo box
            string lValue = lParameter.ValueString;
            foreach (string lString in modeComboBox.Items)
            {
                if (lValue == lString)
                {
                    modeComboBox.SelectedValue = lString;
                }
            }
        }

        /// <summary>
        /// Direct acquisition state changed handler. Bring back to main UI thread.
        /// </summary>
        /// <param name="aDevice"></param>
        /// <param name="aStream"></param>
        /// <param name="aSource"></param>
        /// <param name="aState"></param>
        void OnAcquisitionStateChanged(PvDevice aDevice, PvStream aStream, uint aSource, PvAcquisitionState aState)
        {
            // Invoke event in main UI thread.
            BeginInvoke(mAcquisitionStateChangedHandler);
        }

        /// <summary>
        /// OnAcquisitionStateChanged main UI thread counterpart. Syncs acquisition control status.
        /// </summary>
        void OnAcquisitionStateChanged()
        {
            EnableAcquisitionUI();
        }

        /// <summary>
        /// Displays a GenICam browser form. If already visible, close it for toggle effect.
        /// </summary>
        /// <param name="aForm"></param>
        /// <param name="aParams"></param>
        /// <param name="aTitle"></param>
        private void ShowGenWindow(BrowserForm aForm, PvGenParameterArray aParams, string aTitle)
        {
            if (aForm.Visible)
            {
                CloseGenWindow(aForm);
                return;
            }

            // Creates, assigns parameters, set title and show modeless
            aForm.Text = aTitle;
            aForm.Browser.GenParameterArray = aParams;
            aForm.Show();
        }

        /// <summary>
        /// Closes a GenICam browser form.
        /// </summary>
        /// <param name="aForm"></param>
        private void CloseGenWindow(Form aForm)
        {
            aForm.Hide();
        }

        /// <summary>
        /// Direct device disconnect handler. Just jump back to main UI thread.
        /// </summary>
        /// <param name="aDevice"></param>
        private void OnLinkDisconnected(PvDevice aDevice)
        {
            BeginInvoke(mDisconnectedHandler);
        }

        /// <summary>
        /// Reaction to device disconnected event: stop streaming, close device connection.
        /// </summary>
        private void OnDisconnected()
        {
            MessageBox.Show("Connection to device lost.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            StopStreaming();
            Disconnect();
        }

        void StartAcquisition()
        {
            var lPayloadSize = mDevice.PayloadSize;

            // Propagate to pipeline to make sure buffers are big enough
            mPipeline.BufferSize = lPayloadSize;
            mPipeline.Reset();

            // Reset stream statistics
            PvGenCommand lResetStats = mStream.Parameters.GetCommand("Reset");
            lResetStats.Execute();

            // Prepare buffer for colormap and display
            mPvBuffer.Free();
            mPvBuffer.Image.Alloc((uint)mDevice.Parameters.GetInteger("Width").Value, (uint)mDevice.Parameters.GetInteger("Height").Value, PvPixelType.BGRa8);

            // Reset display thread stats
            mDisplayThread.ResetStatistics();

            // Use acquisition manager to send the acquisition start command to the device
            mAcquisitionManager.Start();
        }

        void StopAcquisition()
        {
            // Use acquisition manager to send the acquisition stop command to the device
            mAcquisitionManager.Stop();
        }

        void communicationButton_Click(object sender, EventArgs e)
        {
            ShowGenWindow(mCommBrowser, mDevice.CommunicationParameters, "Communication Control");
        }

        void deviceButton_Click(object sender, EventArgs e)
        {
            ShowGenWindow(mDeviceBrowser, mDevice.Parameters, "Device Control");
        }

        void streamButton_Click(object sender, EventArgs e)
        {
            ShowGenWindow(mStreamBrowser, mStream.Parameters, "Image Stream Control");
        }

        /// <summary>
        /// Acquisition mode combo box changed. Propagate to device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nothing selected? Unexpected, just do nothing...
            if (modeComboBox.SelectedIndex < 0)
            {
                return;
            }

            PvGenEnum lMode = mDevice.Parameters.GetEnum("AcquisitionMode");

            // Take selection, propagate to parameter
            string lSelected = (string)modeComboBox.SelectedItem;
            lMode.ValueString = lSelected;
        }

        void ChooseDataDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Choose Data Directory ..."
            };
            if (fbdlg.ShowDialog() == DialogResult.OK)
            {
                DataDir.Text = fbdlg.SelectedPath;
            }
        }

        string RecordPath()
        {
            if (!string.IsNullOrEmpty(recorder.RecordPath))
            {
                return recorder.RecordPath;
            }
            if (!Directory.Exists(DataDir.Text))
            {
                MessageBox.Show($"Data Directory: \"{DataDir.Text}\" Not Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataDir.Text = "";
                return null;
            }
            if (string.IsNullOrEmpty(RecordName.Text))
            {
                MessageBox.Show("Record Name Is Empty.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            var recorddir = Path.Combine(DataDir.Text, RecordName.Text);
            if (!Directory.Exists(recorddir))
            {
                Directory.CreateDirectory(recorddir);
            }
            return Path.Combine(recorddir, RecordName.Text);
        }

        void SaveImage_Click(object sender, EventArgs e)
        {
            var recordpath = RecordPath();
            if (string.IsNullOrEmpty(recordpath)) { return; }

            recorder.RecordPath = recordpath;
            recorder.DataFormat = (DataFormat)DataFormat.SelectedIndex;
            recorder.SaveCurrentImage(mDisplayThread);
            recorder.RecordPath = null;
        }

        void OnRecordChecked(bool check)
        {
            Record.Checked = check;
        }

        void Record_CheckedChanged(object sender, EventArgs e)
        {
            if (Record.Checked)
            {
                var recordpath = RecordPath();
                if (string.IsNullOrEmpty(recordpath))
                {
                    Record.CheckedChanged -= Record_CheckedChanged;
                    Record.Checked = false;
                    Record.CheckedChanged += Record_CheckedChanged;
                    return;
                }

                if (config.StopDisplayWhenRecord)
                {
                    IsDisplay.Checked = false;
                }
                if (config.ResetStatisticsWhenRecord)
                {
                    mStream.Parameters.ExecuteCommand("Reset");
                    mDisplayThread.ResetStatistics();
                }

                recorder.RecordPath = recordpath;
                recorder.DataFormat = (DataFormat)DataFormat.SelectedIndex;
                recorder.AvgBitrate = (uint)AvgBitRate.Value;
                recorder.Reset();
                recorder.RecordStatus = RecordStatus.Recording;
                Record.Text = "Stop Record";
            }
            else
            {
                recorder.RecordStatus = RecordStatus.Stopping;
            }
        }

        void Play_CheckedChanged(object sender, EventArgs e)
        {
            if (Play.Checked)
            {
                Play.Text = "Stop";
                StartAcquisition();
            }
            else
            {
                Play.Text = "Start";
                StopAcquisition();
            }
        }

        void Server_CheckedChanged(object sender, EventArgs e)
        {
            if (Server.Checked)
            {
                try
                {
                    if (communicator == null)
                    {
                        communicator = Util.initialize();
                        var adapter = communicator.createObjectAdapterWithEndpoints("Imager", $"default -h {ServerIP.Text} -p {ServerPort.Value}");
                        adapter.add(new CommandI(this), Util.stringToIdentity("Command"));
                        adapter.activate();

                        ServerIP.Enabled = false;
                        ServerPort.Enabled = false;
                    }
                }
                catch (System.Exception exc)
                {
                    MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Server.Checked = false;
                }
            }
            else
            {
                if (communicator != null)
                {
                    communicator.Dispose();
                    communicator = null;

                    ServerIP.Enabled = true;
                    ServerPort.Enabled = true;
                }
            }
        }

        void ColorMap_CheckedChanged(object sender, EventArgs e)
        {
            iscolormap = ColorMap.Checked;
        }

        void IsDisplay_CheckedChanged(object sender, EventArgs e)
        {
            isdisplay = IsDisplay.Checked;
        }
    }
}
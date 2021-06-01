/*
MainForm.Designer.cs is part of the Imager.
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
namespace Imager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.display = new PvGUIDotNet.PvDisplayControl();
            this.statusControl = new PvGUIDotNet.PvStatusControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Play = new System.Windows.Forms.CheckBox();
            this.SaveImage = new System.Windows.Forms.Button();
            this.Record = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.communicationButton = new System.Windows.Forms.Button();
            this.deviceButton = new System.Windows.Forms.Button();
            this.streamButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guidTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.manufacturerTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.macAddressTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.AvgBitRate = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.DataFormat = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RecordName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ChooseDataDir = new System.Windows.Forms.Button();
            this.DataDir = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ServerPort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvgBitRate)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.display);
            this.groupBox4.Controls.Add(this.statusControl);
            this.groupBox4.Location = new System.Drawing.Point(346, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(662, 748);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Display";
            // 
            // display
            // 
            this.display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.display.BackColor = System.Drawing.Color.Transparent;
            this.display.BackgroundColor = System.Drawing.Color.DarkGray;
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.display.Location = new System.Drawing.Point(6, 17);
            this.display.Name = "display";
            this.display.ROI = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.display.Size = new System.Drawing.Size(650, 650);
            this.display.TabIndex = 0;
            this.display.TextOverlay = "";
            this.display.TextOverlayColor = System.Drawing.Color.Lime;
            this.display.TextOverlayOffsetX = 10;
            this.display.TextOverlayOffsetY = 10;
            this.display.TextOverlaySize = 18;
            // 
            // statusControl
            // 
            this.statusControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusControl.BuffersReallocated = false;
            this.statusControl.DisplayThread = null;
            this.statusControl.Location = new System.Drawing.Point(6, 673);
            this.statusControl.MinimumSize = new System.Drawing.Size(400, 32);
            this.statusControl.Name = "statusControl";
            this.statusControl.Size = new System.Drawing.Size(650, 67);
            this.statusControl.Stream = null;
            this.statusControl.TabIndex = 1;
            this.statusControl.Warning = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Play);
            this.groupBox3.Controls.Add(this.SaveImage);
            this.groupBox3.Controls.Add(this.Record);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.modeComboBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 658);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 116);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acquisition Control";
            // 
            // Play
            // 
            this.Play.Appearance = System.Windows.Forms.Appearance.Button;
            this.Play.AutoSize = true;
            this.Play.Enabled = false;
            this.Play.FlatAppearance.CheckedBackColor = System.Drawing.Color.Pink;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.Location = new System.Drawing.Point(8, 64);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(68, 36);
            this.Play.TabIndex = 6;
            this.Play.Text = "Start";
            this.Play.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Play.UseVisualStyleBackColor = false;
            this.Play.CheckedChanged += new System.EventHandler(this.Play_CheckedChanged);
            // 
            // SaveImage
            // 
            this.SaveImage.Enabled = false;
            this.SaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveImage.Location = new System.Drawing.Point(85, 59);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(75, 44);
            this.SaveImage.TabIndex = 5;
            this.SaveImage.Text = "Save Image";
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // Record
            // 
            this.Record.Appearance = System.Windows.Forms.Appearance.Button;
            this.Record.AutoSize = true;
            this.Record.Enabled = false;
            this.Record.FlatAppearance.CheckedBackColor = System.Drawing.Color.Violet;
            this.Record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(168, 64);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(144, 36);
            this.Record.TabIndex = 4;
            this.Record.Text = "Start Record";
            this.Record.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Record.UseVisualStyleBackColor = false;
            this.Record.CheckedChanged += new System.EventHandler(this.Record_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mode";
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.Enabled = false;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(92, 24);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(181, 21);
            this.modeComboBox.TabIndex = 1;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.modeComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.communicationButton);
            this.groupBox2.Controls.Add(this.deviceButton);
            this.groupBox2.Controls.Add(this.streamButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 120);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters and Controls";
            // 
            // communicationButton
            // 
            this.communicationButton.Enabled = false;
            this.communicationButton.Location = new System.Drawing.Point(31, 20);
            this.communicationButton.Name = "communicationButton";
            this.communicationButton.Size = new System.Drawing.Size(257, 26);
            this.communicationButton.TabIndex = 0;
            this.communicationButton.Text = "Communication control";
            this.communicationButton.UseVisualStyleBackColor = true;
            this.communicationButton.Click += new System.EventHandler(this.communicationButton_Click);
            // 
            // deviceButton
            // 
            this.deviceButton.Enabled = false;
            this.deviceButton.Location = new System.Drawing.Point(31, 53);
            this.deviceButton.Name = "deviceButton";
            this.deviceButton.Size = new System.Drawing.Size(257, 26);
            this.deviceButton.TabIndex = 1;
            this.deviceButton.Text = "Device control";
            this.deviceButton.UseVisualStyleBackColor = true;
            this.deviceButton.Click += new System.EventHandler(this.deviceButton_Click);
            // 
            // streamButton
            // 
            this.streamButton.Enabled = false;
            this.streamButton.Location = new System.Drawing.Point(31, 87);
            this.streamButton.Name = "streamButton";
            this.streamButton.Size = new System.Drawing.Size(257, 26);
            this.streamButton.TabIndex = 2;
            this.streamButton.Text = "Image stream control";
            this.streamButton.UseVisualStyleBackColor = true;
            this.streamButton.Click += new System.EventHandler(this.streamButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guidTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.modelTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.manufacturerTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.macAddressTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ipAddressTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.disconnectButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // guidTextBox
            // 
            this.guidTextBox.Location = new System.Drawing.Point(110, 107);
            this.guidTextBox.Name = "guidTextBox";
            this.guidTextBox.ReadOnly = true;
            this.guidTextBox.Size = new System.Drawing.Size(181, 20);
            this.guidTextBox.TabIndex = 7;
            this.guidTextBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "GUID";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(110, 185);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(181, 20);
            this.nameTextBox.TabIndex = 13;
            this.nameTextBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Name";
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(110, 159);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.ReadOnly = true;
            this.modelTextBox.Size = new System.Drawing.Size(181, 20);
            this.modelTextBox.TabIndex = 11;
            this.modelTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Model";
            // 
            // manufacturerTextBox
            // 
            this.manufacturerTextBox.Location = new System.Drawing.Point(110, 133);
            this.manufacturerTextBox.Name = "manufacturerTextBox";
            this.manufacturerTextBox.ReadOnly = true;
            this.manufacturerTextBox.Size = new System.Drawing.Size(181, 20);
            this.manufacturerTextBox.TabIndex = 9;
            this.manufacturerTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Manufacturer";
            // 
            // macAddressTextBox
            // 
            this.macAddressTextBox.Location = new System.Drawing.Point(110, 81);
            this.macAddressTextBox.Name = "macAddressTextBox";
            this.macAddressTextBox.ReadOnly = true;
            this.macAddressTextBox.Size = new System.Drawing.Size(181, 20);
            this.macAddressTextBox.TabIndex = 5;
            this.macAddressTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MAC address";
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Location = new System.Drawing.Point(110, 55);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.ReadOnly = true;
            this.ipAddressTextBox.Size = new System.Drawing.Size(181, 20);
            this.ipAddressTextBox.TabIndex = 3;
            this.ipAddressTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP address";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(31, 19);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(126, 26);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Select / Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(163, 19);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(125, 26);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1022, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.AvgBitRate);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.DataFormat);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.RecordName);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.ChooseDataDir);
            this.groupBox5.Controls.Add(this.DataDir);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(12, 380);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(320, 146);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "File";
            // 
            // AvgBitRate
            // 
            this.AvgBitRate.Location = new System.Drawing.Point(81, 116);
            this.AvgBitRate.Name = "AvgBitRate";
            this.AvgBitRate.Size = new System.Drawing.Size(183, 20);
            this.AvgBitRate.TabIndex = 9;
            this.AvgBitRate.ThousandsSeparator = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "AvgBitrate";
            // 
            // DataFormat
            // 
            this.DataFormat.DisplayMember = "1";
            this.DataFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataFormat.FormattingEnabled = true;
            this.DataFormat.Location = new System.Drawing.Point(81, 82);
            this.DataFormat.Name = "DataFormat";
            this.DataFormat.Size = new System.Drawing.Size(183, 21);
            this.DataFormat.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Format";
            // 
            // RecordName
            // 
            this.RecordName.Location = new System.Drawing.Point(81, 49);
            this.RecordName.Name = "RecordName";
            this.RecordName.Size = new System.Drawing.Size(183, 20);
            this.RecordName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "RecordName";
            // 
            // ChooseDataDir
            // 
            this.ChooseDataDir.Location = new System.Drawing.Point(274, 17);
            this.ChooseDataDir.Name = "ChooseDataDir";
            this.ChooseDataDir.Size = new System.Drawing.Size(30, 23);
            this.ChooseDataDir.TabIndex = 2;
            this.ChooseDataDir.Text = ". . .";
            this.ChooseDataDir.UseVisualStyleBackColor = true;
            this.ChooseDataDir.Click += new System.EventHandler(this.ChooseDataDir_Click);
            // 
            // DataDir
            // 
            this.DataDir.Location = new System.Drawing.Point(81, 19);
            this.DataDir.Name = "DataDir";
            this.DataDir.Size = new System.Drawing.Size(183, 20);
            this.DataDir.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "DataDir";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ServerPort);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.ServerIP);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.Server);
            this.groupBox6.Location = new System.Drawing.Point(12, 532);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(320, 118);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Command Server";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(81, 82);
            this.ServerPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(183, 20);
            this.ServerPort.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Port";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(81, 46);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(183, 20);
            this.ServerIP.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "IP Address";
            // 
            // Server
            // 
            this.Server.AutoSize = true;
            this.Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server.Location = new System.Drawing.Point(131, 16);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(78, 24);
            this.Server.TabIndex = 0;
            this.Server.Text = "Enable";
            this.Server.UseVisualStyleBackColor = true;
            this.Server.CheckedChanged += new System.EventHandler(this.Server_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 778);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(846, 512);
            this.Name = "MainForm";
            this.Text = "Imager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvgBitRate)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServerPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private PvGUIDotNet.PvDisplayControl display;
        private PvGUIDotNet.PvStatusControl statusControl;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button communicationButton;
        private System.Windows.Forms.Button deviceButton;
        private System.Windows.Forms.Button streamButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox manufacturerTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox macAddressTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TextBox guidTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox RecordName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ChooseDataDir;
        private System.Windows.Forms.TextBox DataDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox Server;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox DataFormat;
        private System.Windows.Forms.Button SaveImage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown AvgBitRate;
        private System.Windows.Forms.NumericUpDown ServerPort;
        public System.Windows.Forms.CheckBox Record;
        public System.Windows.Forms.CheckBox Play;
    }
}


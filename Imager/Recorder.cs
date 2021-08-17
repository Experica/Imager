/*
Recorder.cs is part of the Imager.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PvDotNet;

namespace Imager
{
    public enum DataFormat
    {
        Raw,
        TIFF,
        MP4
    }

    public enum RecordStatus
    {
        None,
        Starting,
        Recording,
        Stopping,
        Stopped
    }

    public class Recorder
    {
        readonly object call = new object();
        PvBufferWriter bufferWriter = new PvBufferWriter();
        PvMp4Writer mp4Writer = new PvMp4Writer();

        RecordStatus _recordstatus = RecordStatus.None;
        public RecordStatus RecordStatus
        {
            get { lock (call) { return _recordstatus; } }
            set { lock (call) { _recordstatus = value; } }
        }
        public DataFormat DataFormat = DataFormat.TIFF;
        public string RecordPath = null;
        public string RecordEpoch = "0";

        public uint BytesWritten = 0;
        public uint ImageWritten = 0;

        public uint AvgBitrate
        {
            get { return mp4Writer.AvgBitrate; }
            set { mp4Writer.AvgBitrate = value; }
        }

        public void ResetPath()
        {
            RecordPath = null;
            RecordEpoch = "0";
        }

        public void ResetCounter()
        {
            ImageWritten = 0;
            BytesWritten = 0;
        }

        public bool RecordImage(PvBuffer pvBuffer)
        {
            lock (call)
            {
                if (_recordstatus == RecordStatus.Recording)
                {
                    return SaveImage(pvBuffer);
                }
                return false;
            }
        }

        bool SaveImage(PvBuffer pvBuffer)
        {
            if (pvBuffer == null) { return false; }
            switch (DataFormat)
            {
                case DataFormat.MP4:
                    SaveMP4(pvBuffer);
                    break;
                case DataFormat.TIFF:
                    bufferWriter.Store(pvBuffer, $"{RecordPath}-Epoch{RecordEpoch}-Frame{ImageWritten}.{DataFormat}", PvBufferFormatType.TIFF, ref BytesWritten);
                    ImageWritten++;
                    break;
                case DataFormat.Raw:
                    bufferWriter.Store(pvBuffer, $"{RecordPath}-Epoch{RecordEpoch}-Frame{ImageWritten}.{DataFormat}", PvBufferFormatType.Raw, ref BytesWritten);
                    ImageWritten++;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public bool SaveCurrentImage(PvDisplayThread displayThread)
        {
            bool hr = false;
            if (!IsFormatVedio)
            {
                hr = SaveImage(displayThread.RetrieveLatestBuffer());
                displayThread.ReleaseLatestBuffer();
            }
            return hr;
        }

        public bool IsFormatVedio { get { return DataFormat == DataFormat.MP4; } }

        void SaveMP4(PvBuffer pvBuffer)
        {
            if (!mp4Writer.IsOpened())
            {
                mp4Writer.Open($"{RecordPath}-Epoch{RecordEpoch}.{DataFormat}", pvBuffer.Image);
            }
            mp4Writer.WriteFrame(pvBuffer.Image, ref BytesWritten);
        }

        public void StopMP4()
        {
            lock (call)
            {
                if (mp4Writer.IsOpened())
                {
                    mp4Writer.Close();
                }
            }
        }

    }
}
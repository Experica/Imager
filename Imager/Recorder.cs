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
        uint bytesWritten = 0;
        uint imageWritten = 0;
        RecordStatus recordStatus = RecordStatus.None;

        public DataFormat DataFormat = DataFormat.TIFF;
        public string RecordPath = null;
        public uint AvgBitrate
        {
            get { return mp4Writer.AvgBitrate; }
            set { mp4Writer.AvgBitrate = value; }
        }
        public void Reset()
        {
            lock (call) { RecordPath = null; imageWritten = 0; }
        }
        public bool IsRecording { get { lock (call) { return recordStatus == RecordStatus.Recording; } } }
        public void StartStop(bool isstart)
        {
            lock (call) { recordStatus = isstart ? RecordStatus.Recording : RecordStatus.Stopped; }
        }


        public bool RecordImage(PvBuffer pvBuffer)
        {
            lock (call)
            {
                if (recordStatus == RecordStatus.Recording)
                {
                    return SaveImage(pvBuffer);
                }
                return false;
            }
        }

        public bool SaveCurrentImage(PvDisplayThread displayThread)
        {
            lock (call)
            {
                bool hr = false;
                if (DataFormat != DataFormat.MP4)
                {
                    hr = SaveImage(displayThread.RetrieveLatestBuffer());
                    displayThread.ReleaseLatestBuffer();
                }
                return hr;
            }
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

        bool SaveImage(PvBuffer pvBuffer)
        {
            if (pvBuffer == null) { return false; }
            switch (DataFormat)
            {
                case DataFormat.MP4:
                    SaveMP4(pvBuffer);
                    break;
                case DataFormat.TIFF:
                    bufferWriter.Store(pvBuffer, $"{RecordPath}-Frame{imageWritten}.{DataFormat}", PvBufferFormatType.TIFF, ref bytesWritten);
                    imageWritten++;
                    break;
                case DataFormat.Raw:
                    bufferWriter.Store(pvBuffer, $"{RecordPath}-Frame{imageWritten}.{DataFormat}", PvBufferFormatType.Raw, ref bytesWritten);
                    imageWritten++;
                    break;
                default:
                    return false;
            }
            return true;
        }

        void SaveMP4(PvBuffer pvBuffer)
        {
            if (!mp4Writer.IsOpened())
            {
                mp4Writer.Open($"{RecordPath}.{DataFormat}", pvBuffer.Image);
            }
            mp4Writer.WriteFrame(pvBuffer.Image, ref bytesWritten);
        }

    }
}
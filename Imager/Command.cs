/*
Command.cs is part of the Imager.
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
using System.Windows.Forms;
using Ice;

namespace Imager
{
    public class CommandI : CommandDisp_
    {
        MainForm mainform;
        int timeout;

        public CommandI(MainForm form, int timeout_millisecond = 1000)
        {
            mainform = form;
            timeout = timeout_millisecond;
        }

        public override string getRecordPath(Current current = null)
        {
            try
            {
                return mainform.recorder.RecordPath;
            }
            catch { return null; }
        }

        public override bool setRecordPath(string path, Current current = null)
        {
            try
            {
                mainform.recorder.RecordPath = path;
                return true;
            }
            catch { return false; }
        }

        public override string getRecordEpoch(Current current = null)
        {
            try
            {
                return mainform.recorder.RecordEpoch;
            }
            catch { return null; }
        }

        public override bool setRecordEpoch(string epoch, Current current = null)
        {
            try
            {
                mainform.recorder.RecordEpoch = epoch;
                return true;
            }
            catch { return false; }
        }

        public override string getDataFormat(Current current = null)
        {
            try
            {
                return mainform.recorder.DataFormat.ToString();
            }
            catch { return null; }
        }

        public override bool setDataFormat(string format, Current current = null)
        {
            if (Enum.TryParse(format, out DataFormat fmt))
            {
                mainform.recorder.DataFormat = fmt;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool getIsAcquisiting(Current current = null)
        {
            try
            {
                return mainform.IsAcquisiting;
            }
            catch { return false; }
        }

        public override bool setIsAcquisiting(bool isacquisiting, Current current = null)
        {
            try
            {
                var ar = mainform.BeginInvoke(mainform.mPlayCheckedHandler, isacquisiting);
                ar.AsyncWaitHandle.WaitOne(timeout);
                if (ar.IsCompleted) { return true; } else { return false; }
            }
            catch { return false; }
        }
        public override bool getIsRecording(Current current = null)
        {
            try
            {
                return mainform.recorder.RecordStatus == RecordStatus.Recording;
            }
            catch { return false; }
        }

        public override bool setIsRecording(bool isrecording, Current current = null)
        {
            try
            {
                var ar = mainform.BeginInvoke(mainform.mRecordCheckedHandler, isrecording);
                ar.AsyncWaitHandle.WaitOne(timeout);
                if (ar.IsCompleted) { return true; } else { return false; }
            }
            catch { return false; }
        }

        public override bool StartRecordAndAcquisite(Current current = null)
        {
            return setIsRecording(true) && setIsAcquisiting(true);
        }

        public override bool StopAcquisiteAndRecord(Current current = null)
        {
            return setIsAcquisiting(false) && setIsRecording(false);
        }
    }
}
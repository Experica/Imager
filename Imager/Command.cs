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

        public CommandI(MainForm form)
        {
            mainform = form;
        }

        public override string getRecordPath(Current current = null)
        {
            return mainform.recorder.RecordPath;
        }

        public override void setRecordPath(string path, Current current = null)
        {
            mainform.recorder.RecordPath = path;
        }

        public override bool getIsRecording(Current current = null)
        {
            return mainform.recorder.RecordStatus == RecordStatus.Recording;
        }

        public override void setIsRecording(bool isrecording, Current current = null)
        {
            mainform.BeginInvoke(mainform.mRecordCheckedHandler, isrecording);
        }

        public override string getRecordEpoch(Current current = null)
        {
            return mainform.recorder.RecordEpoch;
        }

        public override void setRecordEpoch(string epoch, Current current = null)
        {
            mainform.recorder.RecordEpoch = epoch;
        }

        public override string getDataFormat(Current current = null)
        {
            return mainform.recorder.DataFormat.ToString();
        }

        public override void setDataFormat(string format, Current current = null)
        {
            if (Enum.TryParse(format, out DataFormat fmt))
            {
                mainform.recorder.DataFormat = fmt;
            }
            else
            {
                MessageBox.Show($"DataFormat: {format} Not Supported.", "Command", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override bool getIsAcqusiting(Current current = null)
        {
            return mainform.Play.Checked;
        }

        public override void setIsAcqusiting(bool isacqusiting, Current current = null)
        {
            mainform.BeginInvoke(mainform.mPlayCheckedHandler, isacqusiting);
        }

        public override bool getIsAcqusitingAndRecording(Current current = null)
        {
            return getIsAcqusiting(current) && getIsRecording(current);
        }

        public override void setIsAcqusitingAndRecording(bool isacqusitingandrecording, Current current = null)
        {
            setIsAcqusiting(isacqusitingandrecording, current);
            setIsRecording(isacqusitingandrecording, current);
        }
    }
}
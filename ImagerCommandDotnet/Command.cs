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
using System.Threading.Tasks;
using Ice;
using Imager;

namespace ImagerCommand
{
    public class Command
    {
        Communicator communicator;
        CommandPrx command;

        public void Connect(string host = "LocalHost", uint port = 10000)
        {
            if (communicator == null)
            {
                communicator = Util.initialize();
                var obj = communicator.stringToProxy($"Command:default -h {host} -p {port}");
                command = CommandPrxHelper.checkedCast(obj);
                if (command == null)
                {
                    throw new ApplicationException($"Invalid Command Proxy from Host: {host}, Port: {port}");
                }
            }
        }

        public void Disconnect()
        {
            if (communicator != null)
            {
                communicator.Dispose();
                communicator = null;
                command = null;
            }
        }

        public string RecordPath
        {
            get { return command.getRecordPath(); }
            set { command.setRecordPath(value); }
        }

        public string RecordEpoch
        {
            get { return command.getRecordEpoch(); }
            set { command.setRecordEpoch(value); }
        }

        public string DataFormat
        {
            get { return command.getDataFormat(); }
            set { command.setDataFormat(value); }
        }

        public bool IsAcqusiting
        {
            get { return command.getIsAcqusiting(); }
            set { command.setIsAcqusiting(value); }
        }

        public bool IsRecording
        {
            get { return command.getIsRecording(); }
            set { command.setIsRecording(value); }
        }

        public bool StartRecordAndAcqusite()
        {
            return command.StartRecordAndAcqusite();
        }

        public bool StopAcqusiteAndRecord()
        {
            return command.StopAcqusiteAndRecord();
        }
    }
}
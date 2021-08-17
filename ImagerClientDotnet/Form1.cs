/*
Form1.cs is part of the Imager.
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImagerCommand;

namespace ImagerClient
{
    public partial class Form1 : Form
    {
        Command command = new Command();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                command.Connect(IP.Text,(uint)Port.Value);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            command.Disconnect();
        }

        private void Record_CheckedChanged(object sender, EventArgs e)
        {
            if(Record.Checked)
            {
                command.RecordPath = RecordPath.Text;
            }
            command.IsRecording = Record.Checked;
        }

        private void Play_CheckedChanged(object sender, EventArgs e)
        {
            command.IsAcqusiting = Play.Checked;
        }

        private void StartRecordPlay_Click(object sender, EventArgs e)
        {
            if(!command.StartRecordAndAcqusite())
            {
                MessageBox.Show("unsuccessful starting record and acqusition.");
            }
        }

        private void StopPlayRecord_Click(object sender, EventArgs e)
        {
            if(!command.StopAcqusiteAndRecord())
            {
                MessageBox.Show("unsuccessful stopping acqusition and record.");
            }
        }
    }
}

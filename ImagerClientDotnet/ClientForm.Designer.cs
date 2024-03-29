﻿/*
ClientForm.Designer.cs is part of the Imager.
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
namespace ImagerClient
{
    partial class ClientForm
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
            this.Record = new System.Windows.Forms.CheckBox();
            this.IP = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RecordPath = new System.Windows.Forms.TextBox();
            this.Play = new System.Windows.Forms.CheckBox();
            this.StartRecordPlay = new System.Windows.Forms.Button();
            this.StopPlayRecord = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.SuspendLayout();
            // 
            // Record
            // 
            this.Record.Appearance = System.Windows.Forms.Appearance.Button;
            this.Record.AutoSize = true;
            this.Record.FlatAppearance.CheckedBackColor = System.Drawing.Color.Violet;
            this.Record.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Record.Location = new System.Drawing.Point(148, 170);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(144, 36);
            this.Record.TabIndex = 0;
            this.Record.Text = "Start Record";
            this.Record.UseVisualStyleBackColor = true;
            this.Record.CheckedChanged += new System.EventHandler(this.Record_CheckedChanged);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(62, 13);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(120, 20);
            this.IP.TabIndex = 1;
            this.IP.Text = "10.1.51.93";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(62, 58);
            this.Port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(120, 20);
            this.Port.TabIndex = 2;
            this.Port.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Imager IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Record Path";
            // 
            // RecordPath
            // 
            this.RecordPath.Location = new System.Drawing.Point(150, 123);
            this.RecordPath.Name = "RecordPath";
            this.RecordPath.Size = new System.Drawing.Size(120, 20);
            this.RecordPath.TabIndex = 6;
            // 
            // Play
            // 
            this.Play.Appearance = System.Windows.Forms.Appearance.Button;
            this.Play.AutoSize = true;
            this.Play.FlatAppearance.CheckedBackColor = System.Drawing.Color.Pink;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.Location = new System.Drawing.Point(41, 170);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(65, 36);
            this.Play.TabIndex = 7;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.CheckedChanged += new System.EventHandler(this.Play_CheckedChanged);
            // 
            // StartRecordPlay
            // 
            this.StartRecordPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartRecordPlay.Location = new System.Drawing.Point(39, 258);
            this.StartRecordPlay.Name = "StartRecordPlay";
            this.StartRecordPlay.Size = new System.Drawing.Size(105, 40);
            this.StartRecordPlay.TabIndex = 10;
            this.StartRecordPlay.Text = "StartRecordPlay";
            this.StartRecordPlay.UseVisualStyleBackColor = true;
            this.StartRecordPlay.Click += new System.EventHandler(this.StartRecordPlay_Click);
            // 
            // StopPlayRecord
            // 
            this.StopPlayRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopPlayRecord.Location = new System.Drawing.Point(188, 258);
            this.StopPlayRecord.Name = "StopPlayRecord";
            this.StopPlayRecord.Size = new System.Drawing.Size(105, 40);
            this.StopPlayRecord.TabIndex = 11;
            this.StopPlayRecord.Text = "StopPlayRecord";
            this.StopPlayRecord.UseVisualStyleBackColor = true;
            this.StopPlayRecord.Click += new System.EventHandler(this.StopPlayRecord_Click);
            // 
            // connect
            // 
            this.connect.Appearance = System.Windows.Forms.Appearance.Button;
            this.connect.AutoSize = true;
            this.connect.FlatAppearance.CheckedBackColor = System.Drawing.Color.LimeGreen;
            this.connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.Location = new System.Drawing.Point(209, 26);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(103, 36);
            this.connect.TabIndex = 12;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 311);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.StopPlayRecord);
            this.Controls.Add(this.StartRecordPlay);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.RecordPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.Record);
            this.Name = "ClientForm";
            this.Text = "ImagerClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Record;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RecordPath;
        private System.Windows.Forms.CheckBox Play;
        private System.Windows.Forms.Button StartRecordPlay;
        private System.Windows.Forms.Button StopPlayRecord;
        private System.Windows.Forms.CheckBox connect;
    }
}


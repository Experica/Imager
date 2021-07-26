/*
Config.cs is part of the Imager.
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
using PvDotNet;

namespace Imager
{
    public class Config
    {
        public string DataDir { get; set; } = "";
        public string RecordName { get; set; } = "";
        public DataFormat DataFormat { get; set; } = DataFormat.TIFF;
        public uint AvgBitrate { get; set; } = 100000000;
        public uint MinAvgBitrate { get; set; } = 1000000;
        public uint MaxAvgBitrate { get; set; } = 1000000000;
        public bool EnableServer { get; set; } = false;
        public string ServerAddress { get; set; } = "LocalHost";
        public ushort ServerPort { get; set; } = 10000;
        public bool DisplayVSync { get; set; } = false;
        public uint DisplayTargetFPS { get; set; } = 30;
        public bool StopDisplayWhenRecord { get; set; } = false;
        public bool ResetStatisticsWhenRecord { get; set; } = true;
        /// <summary>
        /// Increasing the buffer count can make streaming more tolerant to missing block IDs, 
        /// but at the expense of using more memory and increasing latency.
        /// Using more than 16 buffers is typically used in high frame rate, small buffer size applications.
        /// Applications using low frame rates or using very large buffers are not as sensitive to missing block IDs and 
        /// can thus save memory and latency by only using 4 or 8 buffers.
        /// </summary>
        public uint BufferCount { get; set; } = 16;
        /// <summary>
        /// If enabled, buffers are automatically resized by the acquisition pipeline 
        /// when the BUFFER_TOO_SMALL operation result is returned.
        /// </summary>
        public bool BufferAutoResize { get; set; } = true;
        public ImageFormat ImageFormat { get; set; } = new ImageFormat();
        public AcquisitionControl AcquisitionControl { get; set; } = new AcquisitionControl();
        public Strobe Strobe { get; set; } = new Strobe();
        /// <summary>
        /// Array of 256 colors with R,G,B 8 bits per channel pixel
        /// </summary>
        public byte[][] ColorMap { get; set; } = null;
    }

    public class ImageFormat
    {
        public uint Width { get; set; } = 1000;
        public uint Height { get; set; } = 1000;
        public uint OffsetX { get; set; } = 0;
        public uint OffsetY { get; set; } = 0;
        public PvPixelType PixelFormat { get; set; } = PvPixelType.Mono8;

        public void Read(PvGenParameterArray ps)
        {
            var t = ps.GetInteger("Width");
            if (t != null)
            {
                Width = (uint)t.Value;
            }
            t = ps.GetInteger("Height");
            if (t != null)
            {
                Height = (uint)t.Value;
            }
            t = ps.GetInteger("OffsetX");
            if (t != null)
            {
                OffsetX = (uint)t.Value;
            }
            t = ps.GetInteger("OffsetY");
            if (t != null)
            {
                OffsetY = (uint)t.Value;
            }
            var p = ps.GetEnum("PixelFormat");
            if (p != null)
            {
                PixelFormat = (PvPixelType)Enum.Parse(typeof(PvPixelType), p.ValueString);
            }
        }

        public void Write(PvGenParameterArray ps)
        {
            ps.SetIntegerValue("Width", Width);
            ps.SetIntegerValue("Height", Height);
            ps.SetIntegerValue("OffsetX", OffsetX);
            ps.SetIntegerValue("OffsetY", OffsetY);
            ps.SetEnumValue("PixelFormat", PixelFormat.ToString());
        }
    }

    public class AcquisitionControl
    {
        public bool AcquisitionFrameRateEnable { get; set; } = true;
        public double AcquisitionFrameRate { get; set; } = 10;
        /// <summary>
        /// Exposure time in microseconds
        /// </summary>
        public double ExposureTime { get; set; } = 10000;

        public void Read(PvGenParameterArray ps)
        {
            var b = ps.GetBoolean("AcquisitionFrameRateEnable");
            if (b != null)
            {
                AcquisitionFrameRateEnable = b.Value;
            }
            var f = ps.GetFloat("AcquisitionFrameRate");
            if (f != null)
            {
                AcquisitionFrameRate = f.Value;
            }
            f = ps.GetFloat("ExposureTime");
            if (f != null)
            {
                ExposureTime = f.Value;
            }
        }

        public void Write(PvGenParameterArray ps)
        {
            ps.SetBooleanValue("AcquisitionFrameRateEnable", AcquisitionFrameRateEnable);
            ps.SetFloatValue("AcquisitionFrameRate", AcquisitionFrameRate);
            ps.SetFloatValue("ExposureTime", ExposureTime);
        }
    }

    public class Strobe
    {
        /// <summary>
        /// Strobe Delay after internal trigger for exposure in microseconds
        /// </summary>
        public double Strobe_Delay { get; set; } = 0;
        /// <summary>
        /// Strobe pulse width in microseconds
        /// </summary>
        public double Strobe_PulseWidth { get; set; } = 2000;
        public bool Strobe_Invert { get; set; } = false;

        public void Read(PvGenParameterArray ps)
        {
            var b = ps.GetBoolean("Strobe_Invert");
            if (b != null)
            {
                Strobe_Invert = b.Value;
            }
            var f = ps.GetFloat("Strobe_Delay");
            if (f != null)
            {
                Strobe_Delay = f.Value;
            }
            f = ps.GetFloat("Strobe_PulseWidth");
            if (f != null)
            {
                Strobe_PulseWidth = f.Value;
            }
        }

        public void Write(PvGenParameterArray ps)
        {
            ps.SetBooleanValue("Strobe_Invert", Strobe_Invert);
            ps.SetFloatValue("Strobe_Delay", Strobe_Delay);
            ps.SetFloatValue("Strobe_PulseWidth", Strobe_PulseWidth);
        }
    }
}
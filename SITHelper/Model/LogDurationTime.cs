using System;
using System.Collections.Generic;
using System.Text;

namespace SITHelper.Model
{
    public class LogDurationTime
    {
        public LogDurationTime()
        {
            PreviousTime = 240;
            LaterTime = 60;
        }

        public int PreviousTime { get; set; }
        public int LaterTime { get; set; }
    }
}

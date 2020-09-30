using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SaveLog
{
    public class SaveLogFactory
    {
        public static ISaveLog GetInstance(string mode = "Base")
        {
            switch (mode.ToLower())
            {
                case "base":
                    return new SaveLogBase();
                default:
                    return new SaveLogBase();
            }
        }
    }
}

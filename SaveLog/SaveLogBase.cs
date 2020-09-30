using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaveLog
{
    public class SaveLogBase : ISaveLog
    {

        public void CopyLog(string sourcePath, string targetPath, DateTime starttime, DateTime endTime)
        {
            if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);
            using (FileStream file = File.Create(System.IO.Path.Combine(targetPath, $"{starttime.ToString("mmss")}.txt")))
            { }
        }
    }
}

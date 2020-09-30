using System;
using System.Collections.Generic;
using System.Text;

namespace SaveLog
{
    public interface ISaveLog
    {
        public void CopyLog(string sourcePath, string targetPath);
    }
}

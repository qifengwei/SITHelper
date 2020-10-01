using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace SaveLog
{
    public class SaveLogBase : ISaveLog
    {

        public void CopyLog(string sourcePath, string targetPath, string zipName, in DateTime starttime, in DateTime endTime)
        {
            if (!Directory.Exists(targetPath)) Directory.CreateDirectory(targetPath);
            if (!File.Exists(Path.Combine(targetPath, zipName))) File.Create(Path.Combine(targetPath, zipName));
            TraversalDirectory(sourcePath, targetPath, zipName, starttime, endTime);
        }

        private void TraversalDirectory(string parentPath, string targetPath, string zipName, in DateTime starttime, in DateTime endTime)
        {
            
            string [] sonPaths = Directory.GetDirectories(parentPath);
            if (sonPaths.Length != 0)
            {
                foreach (var path in sonPaths)
                {
                    TraversalDirectory(path, targetPath, zipName, starttime, endTime);
                }
            }
            if (Directory.GetLastWriteTime(parentPath) >= starttime)
            {
                ZipLog(parentPath, targetPath,zipName, starttime, endTime);
            }
        }

        private void ZipLog(string sourcePath, string targetPath, string zipName, in DateTime starttime, in DateTime endTime)
        {
            
            foreach (var file in Directory.GetFiles(sourcePath))
            {
                if (Directory.GetLastWriteTime(file) >= starttime && Directory.GetLastWriteTime(file) <= endTime)
                {
                    using (FileStream zipToOpen = new FileStream(Path.Combine(targetPath, zipName), FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            archive.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Fastest);
                        }
                    }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace SaveLog
{
    public class LogPathNode
    {
        public List<LogPathNode> SonCollection { get; set; } = new List<LogPathNode>();
        public String SavedPath;
        public String LogPath;

        public LogPathNode DeepCopy()
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as LogPathNode;
            }
        }
    }
    public class SaveLog
    {
        public DateTime OccurrenceTime { get; set; }
        public Int32 PreviousTimeRange { get; set; } = 300;
        public Int32 LaterTimeRange { get; set; } = 300;
        public String SavePath { get; set; }
        public LogPathNode LogPaths { get; set; }

        public SaveLog(DateTime dateTime, Int32 preTime, Int32 laterTime, String savePath, LogPathNode logPaths)
        {
            OccurrenceTime = dateTime;
            PreviousTimeRange = preTime;
            LaterTimeRange = laterTime;
            SavePath = savePath;
            LogPaths = logPaths.DeepCopy();
        }

        public async void StartCopy()
        {
            await Task.Run(() =>
            {
                TimeSpan span = new TimeSpan(0, 0, LaterTimeRange);
                if (OccurrenceTime + span > DateTime.Now) Thread.Sleep(OccurrenceTime + span - DateTime.Now);
                ErgodicLogPath(LogPaths);
            });
        }

        private void ErgodicLogPath(LogPathNode parentPath)
        {
            if (parentPath.SonCollection.Count > 0)
            {
                foreach (var sonPath in parentPath.SonCollection) ErgodicLogPath(sonPath);
                return;
            }
            Copy(parentPath);
        }

        private void Copy(LogPathNode pathNode)
        { 
        }

    }
}

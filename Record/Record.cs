using System;
using System.Collections.Generic;

namespace Record
{
    public class Record
    {
        public List<string> Contents { get; set; } = new List<string>();

        public Record() { }

        public string ReloadContents()
        {
            string newContents = "";
            foreach (var s in Contents) newContents += $"{s}\n";
            return newContents;
        }
    }
}

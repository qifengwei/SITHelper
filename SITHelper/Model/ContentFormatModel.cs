using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SITHelper.Model
{
    public class ContentFormatModel
    {
        public string Host { get; set; }
        public string Slave { get; set; }

        public static ObservableCollection<ContentFormatModel> GetObservableCollection()
        {
            ObservableCollection<ContentFormatModel> value = new ObservableCollection<ContentFormatModel>();
            value.Add(new ContentFormatModel() { Host = "12345", Slave = "23456" });
            
            return value;
        }
    }
}

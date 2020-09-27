using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SITHelper.Model
{
    public class HistoryGridModel:INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

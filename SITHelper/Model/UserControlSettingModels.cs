using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SITHelper.Model
{
    class UserControlSettingModels
    {
        public static ObservableCollection<char> ColumnName { get; set; }

        public UserControlSettingModels()
        {
            ColumnName = new ObservableCollection<char>
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
        }
    }
}

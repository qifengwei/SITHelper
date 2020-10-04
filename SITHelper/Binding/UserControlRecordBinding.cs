using SITHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SITHelper.Binding
{
    public static class UserControlRecordBinding
    {
        private static string _title;
        private static string _content;

        static UserControlRecordBinding()
        {
            _title = ConfigExcelFormat.TitleColumn.ToString();
            _content = ConfigExcelFormat.ContentColumn.ToString();
        }
        public static string TitleToolTip 
        { 
            get 
            { return $"Title will be writen in column {_title}"; } 
            set 
            { _title = value; } 
        } 
        public static string ContentToolTip
        {
            get
            { return $"Title will be writen in column {_content}"; }
            set
            { _content = value; }
        }


    }
}

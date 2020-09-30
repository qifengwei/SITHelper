using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace SITHelper.Validation
{
    public class TimeRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var time = 0;
            try
            {
                if (((string)value).Length > 0)
                    time = int.Parse((string)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if (time < Min || time > Max)
            {
                return new ValidationResult(false,
                    $"Please enter a time in the range:{Min}-{Max}.");
            }
            return new ValidationResult(true, null);
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Controls;

namespace Task1
{
    public class DoubleRangeRule : ValidationRule
    {
        public double Min { get; set; }

        public double Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double parameter = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    parameter = double.Parse((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, ValidationData.ILLEGAL_CHARACTERS + e.Message);
            }

            if ((parameter <= Min) || (parameter > Max))
            {
                return new ValidationResult(false, ValidationData.VALUE_IS_OUT_OF_RANGE + Min + " - " + Max + ".");
            }

            return new ValidationResult(true, null);
        }
    }
}

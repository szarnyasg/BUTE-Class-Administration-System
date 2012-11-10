using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BUTEClassAdministrationClient
{
    class NameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (nameIsValid((string)value))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }

        public static bool nameIsValid(string value)
        {
            return (value.Length > 0);
        }
    }


}

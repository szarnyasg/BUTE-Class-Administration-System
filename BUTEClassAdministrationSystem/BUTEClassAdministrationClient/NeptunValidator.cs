using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace BUTEClassAdministrationClient
{
    class NeptunValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string neptunregex = @"^[A-Z][A-Z0-9]{5}$";

            if (Regex.IsMatch((string)value, neptunregex, RegexOptions.IgnoreCase))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }
    }
}

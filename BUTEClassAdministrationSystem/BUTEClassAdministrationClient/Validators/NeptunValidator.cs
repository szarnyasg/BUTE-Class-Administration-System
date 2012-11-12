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
            if (neptunIsValid((string)value))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }

        public static bool neptunIsValid(string value)
        {
            string neptunregex = @"^[A-Z][A-Z0-9]{5}$";
            return Regex.IsMatch(value, neptunregex, RegexOptions.IgnoreCase);

        }
    }
}

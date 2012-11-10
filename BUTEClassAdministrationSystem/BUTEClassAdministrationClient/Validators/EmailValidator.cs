using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace BUTEClassAdministrationClient
{
    class EmailValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (emailIsValid((string)value))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }

        public static bool emailIsValid(string value)
        {
            string emailregex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return Regex.IsMatch(value, emailregex, RegexOptions.IgnoreCase);

        }
    }
}

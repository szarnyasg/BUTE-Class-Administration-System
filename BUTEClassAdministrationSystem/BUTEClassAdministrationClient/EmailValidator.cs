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
            string emailregex = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            if (Regex.IsMatch((string)value, emailregex, RegexOptions.IgnoreCase))
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }
    }
}

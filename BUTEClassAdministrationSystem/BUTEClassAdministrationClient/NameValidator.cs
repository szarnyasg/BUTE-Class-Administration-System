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
            if (((string)value).Length > 0)
                return new ValidationResult(true, null);

            return new ValidationResult(false, null);
        }
    }
}

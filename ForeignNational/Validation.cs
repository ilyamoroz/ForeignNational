using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ForeignNational
{
    class Validation
    {
        public bool isSymbolic(string str, int min, int max, string exp = @"^[a-zA-Z ]{3,16}$") => (Regex.IsMatch(str, exp) && str.Length >= min && str.Length <= max) ? true : false;
        public bool isNumeric(string str, string exp = @"^[A-Za-z ]{3,32}[0-9]{1,5}") => Regex.IsMatch(str, exp) ? true : false;
        public bool isNumbers(string str) => Regex.IsMatch(str, @"^[0-9]{2,16}$") ? true : false;
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUTEClassAdministrationClient
{
    class PrettyFormatter
    {
        
        public static string parityFormatter(bool param)
        {
            if (param) return "páros hét";
            else return "páratlan hét";
        }

        public static string dayFormatter(int i)
        {
            switch (i)
            {
                case 0: return "Hétfő";
                case 1: return "Kedd";
                case 2: return "Szerda";
                case 3: return "Csütörtök";
                case 4: return "Péntek";
                case 5: return "Szombat";
                case 6: return "Vasárnap";
                default: return "";
            }
        }


    }
}

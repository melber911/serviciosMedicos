using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Bus.Utilities
{
    public class General
    {
        public static string Rigth(string Cadena, int NroCaracteres)
        {
            string result = Cadena.Substring(Cadena.Length - NroCaracteres, NroCaracteres);

            return result;
        }
    }
}
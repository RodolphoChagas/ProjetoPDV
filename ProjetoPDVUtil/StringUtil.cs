using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVUtil
{
    public static class StringUtil
    {
        public static string RemoverAcentos(string texto)
        {
            var comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇçªº";
            var semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc..";

            for (var i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto.Trim();
        }


        public static string PadBoth(this string str, int length, char character = ' ')
        {
            return str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
        }

    }
}

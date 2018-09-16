using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPDVUtil
{
    public static class DigitoVerificador
    {

        public static int DigitoModulo11(string area)
        {
            int Soma;
            int res;
            int X, Y;
            int dv;
            string Cod;

            Cod = (area).Trim();
            if (Cod.Length < 1)
            {
                dv = 0;
                return dv;
            }

            Soma = 0;
            Y = 2;

            for (X = (Cod.Length); X != 0; X--)
            {
                Soma = Soma + (Convert.ToInt32(Cod.Substring(X - 1, 1)) * Y);
                Y = Y + 1;
                if (Y == 10) Y = 2;
            }

            res = (Soma % 11);

            if (res != 0)
            {
                res = 11 - res;

                if (res == 10) res = 0;

            }

            dv = Convert.ToInt16((res).ToString());

            return dv;
        }

    }
}

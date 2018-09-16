using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPDVUtil
{
    public class FormataTextBox
    {

        public static void TextBoxMoeda(ref TextBox txt)
        {
            try
            {

                var n = txt.Text.Replace(",", "").Replace(".", "");

                if (n.Equals(""))
                    n = "000";


                n = n.PadLeft(3, '0');

                if (n.Length > 3 & n.Substring(0, 1) == "0")
                    n = n.Substring(1, n.Length - 1);

                var v = Convert.ToDouble(n) / 100;

                //txt.Text = string.Format("{0:N}", v);
                txt.Text = $"{v:N}";
                
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TextBoxMoeda");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class Conexion_FormatoMoneda
    {
        public void Formato_Moneda(TextBox TBTexto)
        {
            if (TBTexto.Text == string.Empty)
            {
                return;
            }
            else
            {
                decimal Monto;

                Monto = Convert.ToDecimal(TBTexto.Text);
                TBTexto.Text = Monto.ToString("C", new CultureInfo("en-US"));
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Datos;

namespace Negocio
{
    public class fFormato_Moneda
    {
        public void FormatoMoneda(TextBox TBTexto)
        {
            Conexion_FormatoMoneda Conexion_FormatoMoneda = new Conexion_FormatoMoneda();

            Conexion_FormatoMoneda.Formato_Moneda(TBTexto);
        }
    }
}

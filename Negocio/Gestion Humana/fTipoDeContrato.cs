using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fTipoDeContrato
    {
        public static DataTable Lista()
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            return Datos.Lista();
        }

    }
}

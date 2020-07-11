using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class fGestion_Departameto
    {
        public static DataTable Lista()
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            return Datos.Lista();
        }
    }
}

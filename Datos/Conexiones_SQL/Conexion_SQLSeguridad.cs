using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_SQLSeguridad
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Contraseña;
        private static Conexion_SQLSeguridad Con = null;
        private bool Seguridad = true;

        private Conexion_SQLSeguridad()
        {
            this.Base = "Leal_Tecnologia";
            this.Servidor = "(Local)";
            this.Usuario = "LealTecnologia";
            this.Contraseña = "TecnologiaLealSQL.XXX";
            this.Seguridad = true;
        }

        public SqlConnection Conexion_SeguridadSQL()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + ";";
                if (this.Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + this.Usuario + "; Password=" + this.Contraseña;
                }

            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion_SQLSeguridad getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion_SQLSeguridad();
            }
            return Con;
        }
    }
}

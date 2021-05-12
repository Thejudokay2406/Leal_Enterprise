using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;

using System.Data.SqlClient;
using static System.Configuration.ConfigurationManager;

namespace Datos
{
    public class Conexion_SQLServer
    {
        //public static string preconex = ConnectionStrings["stringConexion"].ConnectionString;

        private string Base;
        private string Servidor;
        private string Usuario;
        private string Contraseña;
        private static Conexion_SQLServer Con = null;
        private bool Seguridad = true;

        private Conexion_SQLServer()
        {
            //var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            this.Base = "Leal_Enterprise";
            this.Servidor = "(Local)";
            this.Usuario = "LealTecnologia";
            this.Contraseña = "TecnologiaLealSQL.XXX";
            this.Seguridad = true;

            //this.Base = configFile.AppSettings.Settings["baseDatos"].Value;
            //this.Servidor = configFile.AppSettings.Settings["servidor"].Value;
            //this.Usuario = configFile.AppSettings.Settings["usuario"].Value;
            //this.Contraseña = configFile.AppSettings.Settings["Password"].Value;
            //this.Seguridad = true;
        }

        public static string preconex = ConnectionStrings["stringConexion"].ConnectionString;
        //static SqlConnection conexion = new SqlConnection(preconex);

        public SqlConnection Conexion()
        {
            //MessageBox
            //SqlConnection Cadena = new SqlConnection();

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

        public static Conexion_SQLServer getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion_SQLServer();
            }
            return Con;
        }

    }
}

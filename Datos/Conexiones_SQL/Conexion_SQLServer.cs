using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_SQLServer
    {
        private string _Base;
        private string _Servidor;
        private string _Usuario;
        private string _Contraseña;
        private static Conexion_SQLServer Con = null;
        private bool Seguridad = true;

        public string Base { get => _Base; set => _Base = value; }
        public string Servidor { get => _Servidor; set => _Servidor = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }

        private Conexion_SQLServer()
        {
            //this.Base = "Leal_Enterprise";
            //this.Servidor = "(local)";
            //this.Usuario = "LealTecnologia";
            //this.Contraseña = "TecnologiaLealSQL.XXX";
            //this.Seguridad = true;
        }

        public SqlConnection Conexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                ////CONEXION FUNCIONAL
                Cadena.ConnectionString = Properties.Settings.Default.Conexion_General;


                //Cadena.ConnectionString = "Server=" + Servidor + "; Database=" + Base + ";";
                //if (this.Seguridad)
                //{
                //    Cadena.ConnectionString = Cadena.ConnectionString + "User Id=" + Usuario + "; Password=" + Contraseña;
                //}
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

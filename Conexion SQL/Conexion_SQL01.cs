using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Configuration.ConfigurationManager;

namespace Conexion_SQL
{
    public class Conexion_SQL01
    {
        public static string preconex = ConnectionStrings["stringConexion"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(preconex);
        static void AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed) conexion.Open();
        }

        static void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open) conexion.Close();
        }

        public static DataTable Listar(string nombreProcedimiento)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public static void cambiarConexion(string cadenaConex)
        {
            String cadenaNueva = cadenaConex;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["stringConexion"].ConnectionString = cadenaNueva;
            config.Save(ConfigurationSaveMode.Modified, true);
            Properties.Settings.Default.Save();
            MessageBox.Show("LA CADENA DE CONEXION SE ACTUALIZO CORRECTAMENTE", "INFORMACION DEL SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }
    }
}

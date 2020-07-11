using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_Pagos
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.TipoDePago", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public DataTable Buscar(string Valor, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.TipoDePago", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Valor;

                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
        }

        public string Guardar_DatosBasicos(Entidad_TipoDePago Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                //SqlCommand Comando = new SqlCommand("Compras.LI_Cotizacion", SqlCon);
                //Comando.CommandType = CommandType.StoredProcedure;

                ////Datos Auxiliares
                //Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                ////Panel Datos Basicos -- Campos Obligatorios
                //Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = Obj.Idbodega;
                //Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = Obj.Idproveedor;
                //Comando.Parameters.Add("@Idtipodepago", SqlDbType.Int).Value = Obj.Idtipodepago;
                //Comando.Parameters.Add("@Idordendecompra", SqlDbType.Int).Value = Obj.Idordendecompra;
                //Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                //Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                //Comando.Parameters.Add("@Almacen", SqlDbType.VarChar).Value = Obj.Almacen;
                //Comando.Parameters.Add("@Codigo_Almacen", SqlDbType.VarChar).Value = Obj.Codigo_Almacen;
                
                //SqlCon.Open();
                //Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Realizar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }


        public string Eliminar(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                //SqlCommand Comando = new SqlCommand("Consulta.TipoDePago", SqlCon);
                //Comando.CommandType = CommandType.StoredProcedure;

                ////Panel Datos Basicos
                //Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                //Comando.Parameters.Add("@Idtipodepago", SqlDbType.Int).Value = IDEliminar_Sql;

                //SqlCon.Open();
                //Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Eliminar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return Rpta;
        }
    }
}

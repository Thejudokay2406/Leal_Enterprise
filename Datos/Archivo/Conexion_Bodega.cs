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
    public class Conexion_Bodega
    {
        public DataTable Lista(int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = Auto;

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
                SqlCommand Comando = new SqlCommand("Archivo.LI_Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta", SqlDbType.Int).Value = Auto;
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

        public string Guardar_DatosBasicos(Entidad_Bodega Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Idsucurzal", SqlDbType.Int).Value = Obj.Idsucurzal;
                Comando.Parameters.Add("@Bodega", SqlDbType.VarChar).Value = Obj.Bodega;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Director", SqlDbType.VarChar).Value = Obj.Director;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Telefono01", SqlDbType.VarChar).Value = Obj.Telefono01;
                Comando.Parameters.Add("@Extension01", SqlDbType.VarChar).Value = Obj.Extension01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.VarChar).Value = Obj.Telefono02;
                Comando.Parameters.Add("@Extension02", SqlDbType.VarChar).Value = Obj.Extension02;
                Comando.Parameters.Add("@Movil01", SqlDbType.VarChar).Value = Obj.Movil01;
                Comando.Parameters.Add("@Movil02", SqlDbType.VarChar).Value = Obj.Movil02;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Medidas", SqlDbType.VarChar).Value = Obj.Medida;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Realizar el Registro";
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

        public string Editar_DatosBasicos(Entidad_Bodega Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = Obj.Idbodega;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Idsucurzal", SqlDbType.Int).Value = Obj.Idsucurzal;
                Comando.Parameters.Add("@Bodega", SqlDbType.VarChar).Value = Obj.Bodega;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Director", SqlDbType.VarChar).Value = Obj.Director;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Telefono01", SqlDbType.VarChar).Value = Obj.Telefono01;
                Comando.Parameters.Add("@Extension01", SqlDbType.VarChar).Value = Obj.Extension01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.VarChar).Value = Obj.Telefono02;
                Comando.Parameters.Add("@Extension02", SqlDbType.VarChar).Value = Obj.Extension02;
                Comando.Parameters.Add("@Movil01", SqlDbType.VarChar).Value = Obj.Movil01;
                Comando.Parameters.Add("@Movil02", SqlDbType.VarChar).Value = Obj.Movil02;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Medidas", SqlDbType.VarChar).Value = Obj.Medida;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() != 1 ? "OK" : "Error al Actualizar el Registro";
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

        public string Eliminar(int IDEliminar_Sql, int auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = auto;
                Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = IDEliminar_Sql;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Eliminar el Registro";
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

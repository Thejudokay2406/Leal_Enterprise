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
    public class Conexion_Proveedor
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Proveedor", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Consulta.Proveedor", SqlCon);
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

        public DataTable BuscarExistencia_SQL(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Proveedor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

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

        public string Guardar_DatosBasicos(Entidad_Proveedor Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Proveedor.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Obj.Tipo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Representante", SqlDbType.VarChar).Value = Obj.Representante;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar).Value = Obj.Nacionalidad;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = Obj.Fechadeinicio;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                //
                Comando.Parameters.Add("@Pais_DE", SqlDbType.VarChar).Value = Obj.Receptor;
                Comando.Parameters.Add("@Ciudad_DE", SqlDbType.VarChar).Value = Obj.Pais_DE;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Ciudad_DE;
                Comando.Parameters.Add("@Direccion_P", SqlDbType.VarChar).Value = Obj.Direccion_P;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Telefono_DE", SqlDbType.VarChar).Value = Obj.Telefono_DE;
                Comando.Parameters.Add("@Movil_DE", SqlDbType.VarChar).Value = Obj.Movil__DE;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                //
                Comando.Parameters.Add("@Retencion", SqlDbType.VarChar).Value = Obj.Retencion;
                Comando.Parameters.Add("@ValorRetencion", SqlDbType.VarChar).Value = Obj.ValorRetencion;
                Comando.Parameters.Add("@Banco01", SqlDbType.VarChar).Value = Obj.BancoPrincipal;
                Comando.Parameters.Add("@Banco02", SqlDbType.VarChar).Value = Obj.BancoAuxiliar;
                Comando.Parameters.Add("@Cuenta01", SqlDbType.VarChar).Value = Obj.Cuenta01;
                Comando.Parameters.Add("@Cuenta02", SqlDbType.VarChar).Value = Obj.Cuenta02;
                Comando.Parameters.Add("@CreditoMin", SqlDbType.VarChar).Value = Obj.CreditoMin;
                Comando.Parameters.Add("@CreditoMax", SqlDbType.VarChar).Value = Obj.CreditoMax;
                Comando.Parameters.Add("@Prorroga", SqlDbType.VarChar).Value = Obj.Prorroga;
                
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
        public string Editar_DatosBasicos(Entidad_Proveedor Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Proveedor.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = Obj.Idproveedor;
                Comando.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Obj.Tipo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Representante", SqlDbType.VarChar).Value = Obj.Representante;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar).Value = Obj.Nacionalidad;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = Obj.Fechadeinicio;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                //
                Comando.Parameters.Add("@Pais_DE", SqlDbType.VarChar).Value = Obj.Receptor;
                Comando.Parameters.Add("@Ciudad_DE", SqlDbType.VarChar).Value = Obj.Pais_DE;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Ciudad_DE;
                Comando.Parameters.Add("@Direccion_P", SqlDbType.VarChar).Value = Obj.Direccion_P;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Telefono_DE", SqlDbType.VarChar).Value = Obj.Telefono_DE;
                Comando.Parameters.Add("@Movil_DE", SqlDbType.VarChar).Value = Obj.Movil__DE;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;

                //
                Comando.Parameters.Add("@Retencion", SqlDbType.VarChar).Value = Obj.Retencion;
                Comando.Parameters.Add("@ValorRetencion", SqlDbType.VarChar).Value = Obj.ValorRetencion;
                Comando.Parameters.Add("@Banco01", SqlDbType.VarChar).Value = Obj.BancoPrincipal;
                Comando.Parameters.Add("@Banco02", SqlDbType.VarChar).Value = Obj.BancoAuxiliar;
                Comando.Parameters.Add("@Cuenta01", SqlDbType.VarChar).Value = Obj.Cuenta01;
                Comando.Parameters.Add("@Cuenta02", SqlDbType.VarChar).Value = Obj.Cuenta02;
                Comando.Parameters.Add("@CreditoMin", SqlDbType.VarChar).Value = Obj.CreditoMin;
                Comando.Parameters.Add("@CreditoMax", SqlDbType.VarChar).Value = Obj.CreditoMax;
                Comando.Parameters.Add("@Prorroga", SqlDbType.VarChar).Value = Obj.Prorroga;

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

        public string Eliminar(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Proveedor", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = IDEliminar_Sql;

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

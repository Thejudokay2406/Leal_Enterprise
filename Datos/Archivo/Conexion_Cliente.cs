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
    public class Conexion_Cliente
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
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

        public string Guardar_DatosBasicos(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Almacen.LI_Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Obj.Departamento;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                //
                Comando.Parameters.Add("@Pais_DE", SqlDbType.VarChar).Value = Obj.Pais_Envios;
                Comando.Parameters.Add("@Ciudad_DE", SqlDbType.VarChar).Value = Obj.Ciudad_Envios;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Receptor_Envios;
                Comando.Parameters.Add("@Direccion_P", SqlDbType.VarChar).Value = Obj.DireccionPrincipal_Envios;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01_Envios;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02_Envios;
                Comando.Parameters.Add("@Telefono_DE", SqlDbType.VarChar).Value = Obj.Telefono_Envios;
                Comando.Parameters.Add("@Movil_DE", SqlDbType.VarChar).Value = Obj.Movil_Envios;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion_Envios;

                //
                Comando.Parameters.Add("@Credito", SqlDbType.VarChar).Value = Obj.Credito;
                Comando.Parameters.Add("@LimiteDeCredito", SqlDbType.VarChar).Value = Obj.LimiteDeCredito;
                Comando.Parameters.Add("@Dias", SqlDbType.VarChar).Value = Obj.DiasDeCredito;
                Comando.Parameters.Add("@Prorroga", SqlDbType.VarChar).Value = Obj.DiasDeProrroga;
                Comando.Parameters.Add("@Intereses", SqlDbType.VarChar).Value = Obj.InteresesPorMora;
                Comando.Parameters.Add("@CreditoMin", SqlDbType.VarChar).Value = Obj.CreditoMinimo;
                Comando.Parameters.Add("@CreditoMax", SqlDbType.VarChar).Value = Obj.CreditoMaximo;

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
        public string Editar_DatosBasicos(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Almacen.LI_Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Obj.Departamento;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                //
                Comando.Parameters.Add("@Pais_DE", SqlDbType.VarChar).Value = Obj.Pais_Envios;
                Comando.Parameters.Add("@Ciudad_DE", SqlDbType.VarChar).Value = Obj.Ciudad_Envios;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Ciudad_Envios;
                Comando.Parameters.Add("@Direccion_P", SqlDbType.VarChar).Value = Obj.DireccionPrincipal_Envios;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01_Envios;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02_Envios;
                Comando.Parameters.Add("@Telefono_DE", SqlDbType.VarChar).Value = Obj.Telefono_Envios;
                Comando.Parameters.Add("@Movil_DE", SqlDbType.VarChar).Value = Obj.Movil_Envios;

                //
                Comando.Parameters.Add("@Credito", SqlDbType.VarChar).Value = Obj.Credito;
                Comando.Parameters.Add("@LimiteDeCredito", SqlDbType.VarChar).Value = Obj.LimiteDeCredito;
                Comando.Parameters.Add("@Dias", SqlDbType.VarChar).Value = Obj.DiasDeCredito;
                Comando.Parameters.Add("@Prorroga", SqlDbType.VarChar).Value = Obj.DiasDeProrroga;
                Comando.Parameters.Add("@Intereses", SqlDbType.VarChar).Value = Obj.InteresesPorMora;
                Comando.Parameters.Add("@CreditoMin", SqlDbType.VarChar).Value = Obj.CreditoMinimo;
                Comando.Parameters.Add("@CreditoMax", SqlDbType.VarChar).Value = Obj.CreditoMaximo;

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
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = IDEliminar_Sql;

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

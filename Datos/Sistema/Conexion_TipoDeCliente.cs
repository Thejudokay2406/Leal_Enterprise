﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion_TipoDeCliente
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.TipoDeCliente", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Consulta.TipoDeCliente", SqlCon);
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

        public string Guardar_DatosBasicos(Entidad_TipoDeCliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Sistema.LI_TipoDeCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Obj.Tipo;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                //
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Realizar el Registro";
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
        public string Editar_DatosBasicos(Entidad_TipoDeCliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Sistema.LI_TipoDeCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = Obj.Tipo;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Observacion;
                Comando.Parameters.Add("@Estado", SqlDbType.Int).Value = Obj.Estado;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Actualizar el Registro";
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
                SqlCommand Comando = new SqlCommand("Consulta.TipoDeCliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
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

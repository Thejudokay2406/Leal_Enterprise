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
    public class Conexion_Impuesto
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Impuesto", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Archivo.LI_Impuesto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Valor;
                Comando.Parameters.Add("@Consulta", SqlDbType.VarChar).Value = Auto;

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

        public string Guardar_DatosBasicos(Entidad_Impuesto Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Impuesto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Impuesto", SqlDbType.VarChar).Value = Obj.Impuesto;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Obj.Valor;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@MinCom", SqlDbType.VarChar).Value = Obj.MontoDeCompra;
                Comando.Parameters.Add("@MinVen", SqlDbType.VarChar).Value = Obj.MontoDeVenta;
                Comando.Parameters.Add("@MinSer", SqlDbType.VarChar).Value = Obj.MontoDeServicio;
                Comando.Parameters.Add("@Compra", SqlDbType.Int).Value = Obj.Compra;
                Comando.Parameters.Add("@Venta", SqlDbType.Int).Value = Obj.Venta;
                Comando.Parameters.Add("@Servicio", SqlDbType.Int).Value = Obj.Servicio;
                Comando.Parameters.Add("@ImpuestoGravado", SqlDbType.Int).Value = Obj.ImpuestoGravado;
                Comando.Parameters.Add("@ImpuestoRetencion", SqlDbType.Int).Value = Obj.ImpuestoRetencion;

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
                
        public string Editar_DatosBasicos(Entidad_Impuesto Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Archivo.LI_Impuesto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idimpuesto", SqlDbType.Int).Value = Obj.Idimpuesto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Impuesto", SqlDbType.VarChar).Value = Obj.Impuesto;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Obj.Valor;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@MinCom", SqlDbType.VarChar).Value = Obj.MontoDeCompra;
                Comando.Parameters.Add("@MinVen", SqlDbType.VarChar).Value = Obj.MontoDeVenta;
                Comando.Parameters.Add("@MinSer", SqlDbType.VarChar).Value = Obj.MontoDeServicio;
                Comando.Parameters.Add("@Compra", SqlDbType.Int).Value = Obj.Compra;
                Comando.Parameters.Add("@Venta", SqlDbType.Int).Value = Obj.Venta;
                Comando.Parameters.Add("@Servicio", SqlDbType.Int).Value = Obj.Servicio;
                Comando.Parameters.Add("@ImpuestoGravado", SqlDbType.Int).Value = Obj.ImpuestoGravado;
                Comando.Parameters.Add("@ImpuestoRetencion", SqlDbType.Int).Value = Obj.ImpuestoRetencion;

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
                SqlCommand Comando = new SqlCommand("Archivo.LI_Impuesto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idimpuesto", SqlDbType.Int).Value = IDEliminar_Sql;

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

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
    public class Conexion_CotizacionDeCompra
    {
        public DataTable Auto_ConsultaEnOrden(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.OrdenDeCompra", SqlCon);
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

        public DataTable Auto_ConsultaDetalle(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.OrdenDeCompra", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Detalle", SqlDbType.VarChar).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Consulta.Cotizacion_Compra", SqlCon);
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

        public string Guardar_DatosBasicos(Entidad_CotizacionDeCompra Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Compras.LI_Cotizacion", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos -- Campos Obligatorios
                Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = Obj.Idbodega;
                Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = Obj.Idproveedor;
                Comando.Parameters.Add("@Idtipodepago", SqlDbType.Int).Value = Obj.Idtipodepago;
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo_CotizacionDeCompra;
                Comando.Parameters.Add("@Cod_Almacen", SqlDbType.VarChar).Value = Obj.Codigo_Almacen;
                Comando.Parameters.Add("@Alm_Descripcion", SqlDbType.VarChar).Value = Obj.Almacen;

                //
                Comando.Parameters.Add("@SubTotal", SqlDbType.VarChar).Value = Obj.SubTotal;
                Comando.Parameters.Add("@Descuento", SqlDbType.VarChar).Value = Obj.Descuento;
                Comando.Parameters.Add("@Desc_Aplicado", SqlDbType.VarChar).Value = Obj.Descuento_Aplicado;
                Comando.Parameters.Add("@Impuesto", SqlDbType.VarChar).Value = Obj.Impuesto;
                Comando.Parameters.Add("@Valor", SqlDbType.VarChar).Value = Obj.Valor;
                Comando.Parameters.Add("@Mora", SqlDbType.VarChar).Value = Obj.Mora;
                Comando.Parameters.Add("@Disponible", SqlDbType.VarChar).Value = Obj.Disponible;
                Comando.Parameters.Add("@Flete", SqlDbType.VarChar).Value = Obj.Flete;
                Comando.Parameters.Add("@Pago", SqlDbType.VarChar).Value = Obj.Pago;
                Comando.Parameters.Add("@Dias", SqlDbType.VarChar).Value = Obj.Dias;
                Comando.Parameters.Add("@Vence", SqlDbType.Int).Value = Obj.Vence;
                Comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Obj.Fecha;

                //Detalle de Cotizacion de Compra
                Comando.Parameters.Add("@Detalle", SqlDbType.Structured).Value = Obj.Cotizacion_Detalles;
                
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
    }
}

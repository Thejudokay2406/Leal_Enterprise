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
    public class Conexion_Producto
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
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

        public DataTable Buscar_Igualdad(int auto_igualdad, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Igualdad", SqlDbType.Int).Value = auto_igualdad;
                Comando.Parameters.Add("@Det_Igualdad", SqlDbType.Int).Value = Valor;

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

        public DataTable Buscar_Impuesto(int auto_impuesto, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Impuesto", SqlDbType.Int).Value = auto_impuesto;
                Comando.Parameters.Add("@Det_Impuesto", SqlDbType.Int).Value = Valor;

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

        public DataTable Buscar_Proveedor(int auto_proveedor, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Proveedor", SqlDbType.Int).Value = auto_proveedor;
                Comando.Parameters.Add("@Det_Proveedor", SqlDbType.Int).Value = Valor;

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

        public DataTable Buscar_Lote(int auto_lote, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Lote", SqlDbType.Int).Value = auto_lote;
                Comando.Parameters.Add("@Det_Lote", SqlDbType.Int).Value = Valor;

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

        public DataTable Buscar_Ubicacion(int auto_ubicacion, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = auto_ubicacion;
                Comando.Parameters.Add("@Det_Ubicacion", SqlDbType.Int).Value = Valor;

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

        public DataTable Buscar_CodigoDeBarra(int auto_codigodebarra, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@auto_codigodebarra", SqlDbType.Int).Value = auto_codigodebarra;
                Comando.Parameters.Add("@Det_CodigoDeBarra", SqlDbType.Int).Value = Valor;

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

        public DataTable AutoComplementar_SQL(int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;

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

        public string Guardar_DatosBasicos(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                //Comando.Parameters.Add("@Producto_AutoSQL", SqlDbType.Int).Value = Obj.Producto_AutoSQL;

                Comando.Parameters.Add("@Lote_AutoSQL", SqlDbType.Int).Value = Obj.Lote_AutoSQL;
                Comando.Parameters.Add("@CodBarra_AutoSQL", SqlDbType.Int).Value = Obj.CodBarra_AutoSQL;
                Comando.Parameters.Add("@Igualdad_AutoSQL", SqlDbType.Int).Value = Obj.Igualdad_AutoSQL;
                Comando.Parameters.Add("@Impuesto_AutoSQL", SqlDbType.Int).Value = Obj.Impuesto_AutoSQL;
                Comando.Parameters.Add("@Ubicacion_AutoSQL", SqlDbType.Int).Value = Obj.Ubicacion_AutoSQL;
                Comando.Parameters.Add("@Proveedor_AutoSQL", SqlDbType.Int).Value = Obj.Proveedor_AutoSQL;

                //Variables Para Ejecutar Si o No Las Transacciones
                Comando.Parameters.Add("@Tran_Ubicacion", SqlDbType.Int).Value = Obj.Tran_Ubicacion;
                Comando.Parameters.Add("@Tran_Igualdad", SqlDbType.Int).Value = Obj.Tran_Igualdad;
                Comando.Parameters.Add("@Tran_Impuesto", SqlDbType.Int).Value = Obj.Tran_Impuesto;
                Comando.Parameters.Add("@Tran_Proveedor", SqlDbType.Int).Value = Obj.Tran_Proveedor;
                Comando.Parameters.Add("@Tran_CodBarra", SqlDbType.Int).Value = Obj.Tran_CodBarra;
                Comando.Parameters.Add("@Tran_Lote", SqlDbType.Int).Value = Obj.Tran_Lote;

                //Panel Datos Basicos -- Campos Obligatorios
                Comando.Parameters.Add("@Idmarca", SqlDbType.Int).Value = Obj.Idmarca;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Producto;
                Comando.Parameters.Add("@ManVenc", SqlDbType.Int).Value = Obj.ManejaVencimiento;
                Comando.Parameters.Add("@ManImpu", SqlDbType.Int).Value = Obj.ManejaImpuesto;
                Comando.Parameters.Add("@Importado", SqlDbType.Int).Value = Obj.Importado;
                Comando.Parameters.Add("@Exportado", SqlDbType.Int).Value = Obj.Exportado;
                Comando.Parameters.Add("@Ofertable", SqlDbType.Int).Value = Obj.Ofertable;
                Comando.Parameters.Add("@ManComision", SqlDbType.Int).Value = Obj.ManejaComision;

                //Panel Datos Basicos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = Obj.Presentacion;
                Comando.Parameters.Add("@ComiPor", SqlDbType.Int).Value = Obj.Comision_Porcentaje;
                Comando.Parameters.Add("@ComiVal", SqlDbType.VarChar).Value = Obj.Comision;
                Comando.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Obj.Unidad;
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Idempaque", SqlDbType.Int).Value = Obj.Idempaque;

                //Panel Precios -- Campos Obligatorios
                Comando.Parameters.Add("@ComProm", SqlDbType.VarChar).Value = Obj.Compra_Promedio;

                //Panel Precios -- Campos NO Obligatorios

                Comando.Parameters.Add("@ComFinal", SqlDbType.VarChar).Value = Obj.Compra_Final;
                Comando.Parameters.Add("@VenExc", SqlDbType.VarChar).Value = Obj.Venta_Excento;
                Comando.Parameters.Add("@VenNoExc", SqlDbType.VarChar).Value = Obj.Venta_NoExcento;
                Comando.Parameters.Add("@VenMayor", SqlDbType.VarChar).Value = Obj.Venta_Mayorista;
                Comando.Parameters.Add("@Fabri", SqlDbType.VarChar).Value = Obj.Fabricacion;
                Comando.Parameters.Add("@Mate", SqlDbType.VarChar).Value = Obj.Materiales;
                Comando.Parameters.Add("@Export", SqlDbType.VarChar).Value = Obj.Exportacion;
                Comando.Parameters.Add("@Import", SqlDbType.VarChar).Value = Obj.Importacion;
                Comando.Parameters.Add("@Seguri", SqlDbType.VarChar).Value = Obj.Seguro;
                Comando.Parameters.Add("@Gastos", SqlDbType.VarChar).Value = Obj.Gastos;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Ubicacion", SqlDbType.Structured).Value = Obj.Detalle_Ubicacion;

                //Panel Cantidades -- Campos NO Obligatorios
                Comando.Parameters.Add("@VeMinClie", SqlDbType.VarChar).Value = Obj.Venta_MinimaCliente;
                Comando.Parameters.Add("@VeMaxClie", SqlDbType.VarChar).Value = Obj.Venta_MaximaCliente;
                Comando.Parameters.Add("@VeMinMayo", SqlDbType.VarChar).Value = Obj.Venta_MinimaMayorista;
                Comando.Parameters.Add("@VeMaxMayo", SqlDbType.VarChar).Value = Obj.Venta_MaximaMayorista;
                Comando.Parameters.Add("@CoMinClie", SqlDbType.VarChar).Value = Obj.Compra_MinimaCliente;
                Comando.Parameters.Add("@CoMaxClie", SqlDbType.VarChar).Value = Obj.Compra_MaximaCliente;
                Comando.Parameters.Add("@CoMinMayo", SqlDbType.VarChar).Value = Obj.Compra_MinimaMayorista;
                Comando.Parameters.Add("@CoMaxMayo", SqlDbType.VarChar).Value = Obj.Compra_MaximaMayorista;

                //Panel Impuestos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Impuesto", SqlDbType.Structured).Value = Obj.Detalle_Impuesto;

                //Panel Igualdad -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Igualdad", SqlDbType.Structured).Value = Obj.Detalle_Igualdad;

                //Panel Lotes -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Lotes", SqlDbType.Structured).Value = Obj.Detalle_Lote;

                //Panel Codigo de Barra -- Campos Obligatorios
                Comando.Parameters.Add("@Det_CodigoBarra", SqlDbType.Structured).Value = Obj.Detalle_CodigoDeBarra;

                //Panel Proveedor -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Proveedor", SqlDbType.Structured).Value = Obj.Detalle_Proveedor;

                //Panel Imagenes -- Campos NO Obligatorios
                Comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = Obj.Imagen;

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

        public string Editar_DatosBasicos(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Datos Basicos -- Campos Obligatorios
                Comando.Parameters.Add("@Idmarca", SqlDbType.Int).Value = Obj.Idmarca;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Producto;
                Comando.Parameters.Add("@ManVenc", SqlDbType.Int).Value = Obj.ManejaVencimiento;
                Comando.Parameters.Add("@ManImpu", SqlDbType.Int).Value = Obj.ManejaImpuesto;
                Comando.Parameters.Add("@Importado", SqlDbType.Int).Value = Obj.Importado;
                Comando.Parameters.Add("@Exportado", SqlDbType.Int).Value = Obj.Exportado;
                Comando.Parameters.Add("@Ofertable", SqlDbType.Int).Value = Obj.Ofertable;
                Comando.Parameters.Add("@ManComision", SqlDbType.Int).Value = Obj.ManejaComision;

                //Panel Datos Basicos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = Obj.Presentacion;
                Comando.Parameters.Add("@ComiPor", SqlDbType.Int).Value = Obj.Comision_Porcentaje;
                Comando.Parameters.Add("@ComiVal", SqlDbType.VarChar).Value = Obj.Comision;
                Comando.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Obj.Unidad;
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Idempaque", SqlDbType.Int).Value = Obj.Idempaque;

                //Panel Precios -- Campos Obligatorios
                Comando.Parameters.Add("@ComProm", SqlDbType.VarChar).Value = Obj.Compra_Promedio;

                //Panel Precios -- Campos NO Obligatorios

                Comando.Parameters.Add("@ComFinal", SqlDbType.VarChar).Value = Obj.Compra_Final;
                Comando.Parameters.Add("@VenExc", SqlDbType.VarChar).Value = Obj.Venta_Excento;
                Comando.Parameters.Add("@VenNoExc", SqlDbType.VarChar).Value = Obj.Venta_NoExcento;
                Comando.Parameters.Add("@VenMayor", SqlDbType.VarChar).Value = Obj.Venta_Mayorista;
                Comando.Parameters.Add("@Fabri", SqlDbType.VarChar).Value = Obj.Fabricacion;
                Comando.Parameters.Add("@Mate", SqlDbType.VarChar).Value = Obj.Materiales;
                Comando.Parameters.Add("@Export", SqlDbType.VarChar).Value = Obj.Exportacion;
                Comando.Parameters.Add("@Import", SqlDbType.VarChar).Value = Obj.Importacion;
                Comando.Parameters.Add("@Seguri", SqlDbType.VarChar).Value = Obj.Seguro;
                Comando.Parameters.Add("@Gastos", SqlDbType.VarChar).Value = Obj.Gastos;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Ubicacion", SqlDbType.Structured).Value = Obj.Detalle_Ubicacion;

                //Panel Cantidades -- Campos NO Obligatorios
                Comando.Parameters.Add("@VeMinClie", SqlDbType.VarChar).Value = Obj.Venta_MinimaCliente;
                Comando.Parameters.Add("@VeMaxClie", SqlDbType.VarChar).Value = Obj.Venta_MaximaCliente;
                Comando.Parameters.Add("@VeMinMayo", SqlDbType.VarChar).Value = Obj.Venta_MinimaMayorista;
                Comando.Parameters.Add("@VeMaxMayo", SqlDbType.VarChar).Value = Obj.Venta_MaximaMayorista;
                Comando.Parameters.Add("@CoMinClie", SqlDbType.VarChar).Value = Obj.Compra_MinimaCliente;
                Comando.Parameters.Add("@CoMaxClie", SqlDbType.VarChar).Value = Obj.Compra_MaximaCliente;
                Comando.Parameters.Add("@CoMinMayo", SqlDbType.VarChar).Value = Obj.Compra_MinimaMayorista;
                Comando.Parameters.Add("@CoMaxMayo", SqlDbType.VarChar).Value = Obj.Compra_MaximaMayorista;

                //Panel Impuestos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Impuesto", SqlDbType.Structured).Value = Obj.Detalle_Impuesto;

                //Panel Igualdad -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Igualdad", SqlDbType.Structured).Value = Obj.Detalle_Igualdad;

                //Panel Lotes -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Lotes", SqlDbType.Structured).Value = Obj.Detalle_Lote;

                //Panel Codigo de Barra -- Campos Obligatorios
                Comando.Parameters.Add("@Det_CodigoBarra", SqlDbType.Structured).Value = Obj.Detalle_CodigoDeBarra;

                //Panel Proveedor -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Proveedor", SqlDbType.Structured).Value = Obj.Detalle_Proveedor;

                //Panel Imagenes -- Campos NO Obligatorios
                Comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = Obj.Imagen;

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
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Ubicacion(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Impuesto(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Proveedor(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_CodigoDeBara(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Lote(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Igualdad(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Producto", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = IDEliminar_Sql;

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

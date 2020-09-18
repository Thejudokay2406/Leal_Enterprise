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

        public DataTable Lista_Ubicacion(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Ubicacion", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

        public DataTable Lista_Proveedor(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Proveedor", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

        public DataTable Lista_CodigoDeBarra(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_CodBarra", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

        public DataTable Lista_Igualdad(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Igualdad", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

        public DataTable Lista_Impuesto(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Impuesto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

        public DataTable Lista_Lote(int Auto, int idproducto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Lote", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = idproducto;

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

                //Panel Cantidades -- Campos NO Obligatorios
                Comando.Parameters.Add("@VeMinClie", SqlDbType.VarChar).Value = Obj.Venta_MinimaCliente;
                Comando.Parameters.Add("@VeMaxClie", SqlDbType.VarChar).Value = Obj.Venta_MaximaCliente;
                Comando.Parameters.Add("@VeMinMayo", SqlDbType.VarChar).Value = Obj.Venta_MinimaMayorista;
                Comando.Parameters.Add("@VeMaxMayo", SqlDbType.VarChar).Value = Obj.Venta_MaximaMayorista;
                Comando.Parameters.Add("@CoMinClie", SqlDbType.VarChar).Value = Obj.Compra_MinimaCliente;
                Comando.Parameters.Add("@CoMaxClie", SqlDbType.VarChar).Value = Obj.Compra_MaximaCliente;
                Comando.Parameters.Add("@CoMinMayo", SqlDbType.VarChar).Value = Obj.Compra_MinimaMayorista;
                Comando.Parameters.Add("@CoMaxMayo", SqlDbType.VarChar).Value = Obj.Compra_MaximaMayorista;

                //Panel Imagenes -- Campos NO Obligatorios
                Comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = Obj.Imagen;

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

        public string Guardar_Ubicacion(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.AutoDet_Ubicacion;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = Obj.Idbodega;
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;             

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

        public string Guardar_Proveedor(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Proveedor", SqlDbType.Int).Value = Obj.AutoDet_Ubicacion;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = Obj.Idproveedor;
                Comando.Parameters.Add("@Proveedor", SqlDbType.VarChar).Value = Obj.Proveedor;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Proveedor_Documento;

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

        public string Guardar_Lote(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Lote", SqlDbType.Int).Value = Obj.AutoDet_Lote;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Lote", SqlDbType.VarChar).Value = Obj.Lote;
                Comando.Parameters.Add("@Lote_Compra", SqlDbType.VarChar).Value = Obj.Lote_Compra;
                Comando.Parameters.Add("@Lote_Venta", SqlDbType.VarChar).Value = Obj.Lote_Venta;
                Comando.Parameters.Add("@Lote_Cantidad", SqlDbType.VarChar).Value = Obj.Lote_Cantidad;
                Comando.Parameters.Add("@Lote_Fecha", SqlDbType.DateTime).Value = Obj.Lote_Fecha;

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

        public string Guardar_Impuestos(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Impuesto", SqlDbType.Int).Value = Obj.AutoDet_Impuesto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idimpuesto", SqlDbType.Int).Value = Obj.Idimpueto;
                Comando.Parameters.Add("@Impuesto_Edi", SqlDbType.VarChar).Value = Obj.Impuesto;
                Comando.Parameters.Add("@Valor_Edi", SqlDbType.VarChar).Value = Obj.Impuesto_Valor;
                Comando.Parameters.Add("@DescripcionImpu_Edi", SqlDbType.VarChar).Value = Obj.Impuesto_Descripcion;

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

        public string Guardar_Igualdad(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Igualdad", SqlDbType.Int).Value = Obj.AutoDet_Igualdad;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@CodigoProducto", SqlDbType.VarChar).Value = Obj.Igualdad_Codigo;
                Comando.Parameters.Add("@Producto", SqlDbType.VarChar).Value = Obj.Igualdad_Producto;
                Comando.Parameters.Add("@Marca", SqlDbType.VarChar).Value = Obj.Igualdad_Marca;

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

        public string Guardar_CodigoDeBarra(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_CodigoDeBarra", SqlDbType.Int).Value = Obj.AutoDet_Codigodebarra;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@CodigodeBarra", SqlDbType.VarChar).Value = Obj.CodigoDeBarra;

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

        public string Editar_Proveedor(Entidad_Productos Obj)
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
                Comando.Parameters.Add("@Proveedor_SQL", SqlDbType.Int).Value = Obj.Proveedor_SQL;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Proveedor", SqlDbType.Structured).Value = Obj.Detalle_Proveedor;

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

        public string Editar_Igualdad(Entidad_Productos Obj)
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
                Comando.Parameters.Add("@Igualdad_SQL", SqlDbType.Int).Value = Obj.Igualdad_SQL;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Igualdad", SqlDbType.Structured).Value = Obj.Detalle_Igualdad;

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

        public string Editar_Impuesto(Entidad_Productos Obj)
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
                Comando.Parameters.Add("@Impuesto_SQL", SqlDbType.Int).Value = Obj.Impuesto_SQL;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Impuesto", SqlDbType.Structured).Value = Obj.Detalle_Impuesto;

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

        public string Editar_Lote(Entidad_Productos Obj)
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
                Comando.Parameters.Add("@Lote_SQL", SqlDbType.Int).Value = Obj.Lote_SQL;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Lote", SqlDbType.Structured).Value = Obj.Detalle_Lote;

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

        public string Editar_CodigoDeBarra(Entidad_Productos Obj)
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

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_CodigoDeBarra", SqlDbType.Structured).Value = Obj.Detalle_CodigoDeBarra;

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

        public string Eliminar(int Idproducto, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;

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

        public string Eliminar_Ubicacion(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idubicacion", SqlDbType.Int).Value = Iddetalle;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;

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

        public string Eliminar_Impuesto(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;
                Comando.Parameters.Add("@Idimpuesto", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_Proveedor(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;
                Comando.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_CodigoDeBara(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;
                Comando.Parameters.Add("@IdCodBarra", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_Lote(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;
                Comando.Parameters.Add("@IdLote", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_Igualdad(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Idproducto;
                Comando.Parameters.Add("@IdIgualdad", SqlDbType.Int).Value = Iddetalle;

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

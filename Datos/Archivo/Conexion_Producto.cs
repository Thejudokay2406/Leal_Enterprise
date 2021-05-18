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
        public DataTable AutoIncrementable(int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                //Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Valor;

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

        public DataTable Lista_Proveedor(int Auto, int filt_proveedor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Proveedor", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Filt_Proveedor", SqlDbType.Int).Value = filt_proveedor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_CodigoDeBarra", SqlDbType.Int).Value = Auto;
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

        public DataTable Lista_Compuesto(int Auto, int Filt_Compuesto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Compuesto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Filt_Compuesto", SqlDbType.Int).Value = Filt_Compuesto;

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

        public DataTable Lista_Exterior(int Auto, int idproducto)
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

        public DataTable Buscar(int Auto, string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
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

        public DataTable Buscar_Compuesto(int auto_compuestp, int Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Compuesto", SqlDbType.Int).Value = auto_compuestp;
                Comando.Parameters.Add("@Filt_Compuesto", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Igualdad", SqlDbType.Int).Value = auto_igualdad;
                Comando.Parameters.Add("@Filt_Igualdad", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Impuesto", SqlDbType.Int).Value = auto_impuesto;
                Comando.Parameters.Add("@Filt_Impuesto", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Proveedor", SqlDbType.Int).Value = auto_proveedor;
                Comando.Parameters.Add("@Filt_Proveedor", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_Ubicacion", SqlDbType.Int).Value = auto_ubicacion;
                Comando.Parameters.Add("@Filt_Ubicacion", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Cons_CodigoDeBarra", SqlDbType.Int).Value = auto_codigodebarra;
                Comando.Parameters.Add("@Filt_CodigoDeBarra", SqlDbType.Int).Value = Valor;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
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
                
                Comando.Parameters.Add("@CodBarra_AutoSQL", SqlDbType.Int).Value = Obj.CodBarra_AutoSQL;
                Comando.Parameters.Add("@Igualdad_AutoSQL", SqlDbType.Int).Value = Obj.Igualdad_AutoSQL;
                Comando.Parameters.Add("@Impuesto_AutoSQL", SqlDbType.Int).Value = Obj.Impuesto_AutoSQL;
                Comando.Parameters.Add("@Ubicacion_AutoSQL", SqlDbType.Int).Value = Obj.Ubicacion_AutoSQL;
                Comando.Parameters.Add("@Proveedor_AutoSQL", SqlDbType.Int).Value = Obj.Proveedor_AutoSQL;
                Comando.Parameters.Add("@Exterior_AutoSQL", SqlDbType.Int).Value = Obj.Exterior_AutoSQL;
                Comando.Parameters.Add("@Compuesto_AutoSQL", SqlDbType.Int).Value = Obj.Compuesto_AutoSQL;

                //Variables Para Ejecutar Si o No Las Transacciones
                Comando.Parameters.Add("@Tran_Ubicacion", SqlDbType.Int).Value = Obj.Tran_Ubicacion;
                Comando.Parameters.Add("@Tran_Igualdad", SqlDbType.Int).Value = Obj.Tran_Igualdad;
                Comando.Parameters.Add("@Tran_Impuesto", SqlDbType.Int).Value = Obj.Tran_Impuesto;
                Comando.Parameters.Add("@Tran_Proveedor", SqlDbType.Int).Value = Obj.Tran_Proveedor;
                Comando.Parameters.Add("@Tran_CodBarra", SqlDbType.Int).Value = Obj.Tran_CodBarra;
                Comando.Parameters.Add("@Tran_Compuesto", SqlDbType.Int).Value = Obj.Tran_Compuesto;
                Comando.Parameters.Add("@Tran_Exterior", SqlDbType.Int).Value = Obj.Tran_Exterior;

                //Panel Datos Basicos -- Campos Obligatorios
                Comando.Parameters.Add("@Idmarca", SqlDbType.Int).Value = Obj.Idmarca;
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Producto;
                Comando.Parameters.Add("@ManVenc", SqlDbType.Int).Value = Obj.ManejaVencimiento;
                Comando.Parameters.Add("@ManImpu", SqlDbType.Int).Value = Obj.ManejaImpuesto;
                Comando.Parameters.Add("@Importado", SqlDbType.Int).Value = Obj.Importado;
                Comando.Parameters.Add("@Exportado", SqlDbType.Int).Value = Obj.Exportado;
                Comando.Parameters.Add("@Ofertable", SqlDbType.Int).Value = Obj.Ofertable;
                Comando.Parameters.Add("@Fabricado", SqlDbType.Int).Value = Obj.Fabricado;
                Comando.Parameters.Add("@ManComision", SqlDbType.Int).Value = Obj.ManejaComision;
                Comando.Parameters.Add("@ManEmpaque", SqlDbType.Int).Value = Obj.ManejaEmpaque;
                Comando.Parameters.Add("@ManBalanza", SqlDbType.Int).Value = Obj.ManejaBalanza;
                Comando.Parameters.Add("@ManReten", SqlDbType.Int).Value = Obj.ManejaRetencion;

                //Panel Datos Basicos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Idempaque", SqlDbType.Int).Value = Obj.Idempaque;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = Obj.Presentacion;
                Comando.Parameters.Add("@Comision", SqlDbType.BigInt).Value = Obj.Comision;
                
                //Panel Precios -- Campos Obligatorios
                Comando.Parameters.Add("@ComProm", SqlDbType.VarChar).Value = Obj.Compra_Promedio;
                Comando.Parameters.Add("@ComFinal", SqlDbType.VarChar).Value = Obj.Compra_Final;

                //Panel Precios -- Campos NO Obligatorios
                Comando.Parameters.Add("@Venta01", SqlDbType.VarChar).Value = Obj.Venta01;
                Comando.Parameters.Add("@PorVenta01", SqlDbType.VarChar).Value = Obj.Venta01_Porcentaje;
                Comando.Parameters.Add("@BaseVen01", SqlDbType.VarChar).Value = Obj.Venta01_BaseInicial;
                Comando.Parameters.Add("@ImpVen01", SqlDbType.VarChar).Value = Obj.Venta01_Impuesto;
                Comando.Parameters.Add("@Venta02", SqlDbType.VarChar).Value = Obj.Venta02;
                Comando.Parameters.Add("@PorVenta02", SqlDbType.VarChar).Value = Obj.Venta02_Porcentaje;
                Comando.Parameters.Add("@BaseVen02", SqlDbType.VarChar).Value = Obj.Venta02_BaseInicial;
                Comando.Parameters.Add("@ImpVen02", SqlDbType.VarChar).Value = Obj.Venta02_Impuesto;
                Comando.Parameters.Add("@Venta03", SqlDbType.VarChar).Value = Obj.Venta03;
                Comando.Parameters.Add("@PorVenta03", SqlDbType.VarChar).Value = Obj.Venta03_Porcentaje;
                Comando.Parameters.Add("@BaseVen03", SqlDbType.VarChar).Value = Obj.Venta03_BaseInicial;
                Comando.Parameters.Add("@ImpVen03", SqlDbType.VarChar).Value = Obj.Venta03_Impuesto;
                Comando.Parameters.Add("@Mayor", SqlDbType.VarChar).Value = Obj.Mayorista;
                Comando.Parameters.Add("@PorVenta04", SqlDbType.VarChar).Value = Obj.Mayorista_Impuesto;
                Comando.Parameters.Add("@BaseVen04", SqlDbType.VarChar).Value = Obj.Mayorista_BaseInicial;
                Comando.Parameters.Add("@ImpVen04", SqlDbType.VarChar).Value = Obj.Mayorista_Impuesto;
                Comando.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Obj.Unidad;
                Comando.Parameters.Add("@Und_Det", SqlDbType.VarChar).Value = Obj.Unidad_Detalle;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Ubicacion", SqlDbType.Structured).Value = Obj.Detalle_Ubicacion;

                //Panel Compuesto -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Compuesto", SqlDbType.Structured).Value = Obj.Detalle_Compuesto;

                //Panel Exterior -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Exterior", SqlDbType.Structured).Value = Obj.Detalle_Exterior;

                //Panel Impuestos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Impuesto", SqlDbType.Structured).Value = Obj.Detalle_Impuesto;

                //Panel Igualdad -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Igualdad", SqlDbType.Structured).Value = Obj.Detalle_Igualdad;

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
                Comando.Parameters.Add("@Fabricado", SqlDbType.Int).Value = Obj.Fabricado;
                Comando.Parameters.Add("@ManComision", SqlDbType.Int).Value = Obj.ManejaComision;
                Comando.Parameters.Add("@ManEmpaque", SqlDbType.Int).Value = Obj.ManejaEmpaque;
                Comando.Parameters.Add("@ManBalanza", SqlDbType.Int).Value = Obj.ManejaBalanza;
                Comando.Parameters.Add("@ManReten", SqlDbType.Int).Value = Obj.ManejaRetencion;

                //Panel Datos Basicos -- Campos NO Obligatorios
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                Comando.Parameters.Add("@Idempaque", SqlDbType.Int).Value = Obj.Idempaque;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("@Referencia", SqlDbType.VarChar).Value = Obj.Referencia;
                Comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = Obj.Presentacion;
                Comando.Parameters.Add("@Comision", SqlDbType.BigInt).Value = Obj.Comision;

                //Panel Precios -- Campos Obligatorios
                Comando.Parameters.Add("@ComProm", SqlDbType.VarChar).Value = Obj.Compra_Promedio;
                Comando.Parameters.Add("@ComFinal", SqlDbType.VarChar).Value = Obj.Compra_Final;

                //Panel Precios -- Campos NO Obligatorios
                Comando.Parameters.Add("@Venta01", SqlDbType.VarChar).Value = Obj.Venta01;
                Comando.Parameters.Add("@PorVenta01", SqlDbType.VarChar).Value = Obj.Venta01_Porcentaje;
                Comando.Parameters.Add("@BaseVen01", SqlDbType.VarChar).Value = Obj.Venta01_BaseInicial;
                Comando.Parameters.Add("@ImpVen01", SqlDbType.VarChar).Value = Obj.Venta01_Impuesto;
                Comando.Parameters.Add("@Venta02", SqlDbType.VarChar).Value = Obj.Venta02;
                Comando.Parameters.Add("@PorVenta02", SqlDbType.VarChar).Value = Obj.Venta02_Porcentaje;
                Comando.Parameters.Add("@BaseVen02", SqlDbType.VarChar).Value = Obj.Venta02_BaseInicial;
                Comando.Parameters.Add("@ImpVen02", SqlDbType.VarChar).Value = Obj.Venta02_Impuesto;
                Comando.Parameters.Add("@Venta03", SqlDbType.VarChar).Value = Obj.Venta03;
                Comando.Parameters.Add("@PorVenta03", SqlDbType.VarChar).Value = Obj.Venta03_Porcentaje;
                Comando.Parameters.Add("@BaseVen03", SqlDbType.VarChar).Value = Obj.Venta03_BaseInicial;
                Comando.Parameters.Add("@ImpVen03", SqlDbType.VarChar).Value = Obj.Venta03_Impuesto;
                Comando.Parameters.Add("@Mayor", SqlDbType.VarChar).Value = Obj.Mayorista;
                Comando.Parameters.Add("@PorVenta04", SqlDbType.VarChar).Value = Obj.Mayorista_Impuesto;
                Comando.Parameters.Add("@BaseVen04", SqlDbType.VarChar).Value = Obj.Mayorista_BaseInicial;
                Comando.Parameters.Add("@ImpVen04", SqlDbType.VarChar).Value = Obj.Mayorista_Impuesto;
                Comando.Parameters.Add("@Unidad", SqlDbType.VarChar).Value = Obj.Unidad;
                Comando.Parameters.Add("@Und_Det", SqlDbType.VarChar).Value = Obj.Unidad_Detalle;

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

        public string Guardar_Ubicacion(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idbodega", SqlDbType.Int).Value = Obj.Idbodega;
                Comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = Obj.Nivel;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Proveedor", SqlDbType.Int).Value = Obj.Auto_Proveedor;

                //Panel Proveedor -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idproveedor", SqlDbType.Int).Value = Obj.Idproveedor;
                Comando.Parameters.Add("@Proveedor", SqlDbType.VarChar).Value = Obj.Proveedor;
                Comando.Parameters.Add("@Proveedor_Documento", SqlDbType.VarChar).Value = Obj.Proveedor_Documento;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Impuesto", SqlDbType.Int).Value = Obj.AutoDet_Impuesto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Idimpuesto", SqlDbType.Int).Value = Obj.Idimpuesto;
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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
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

        public string Guardar_Compuesto(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Compuesto", SqlDbType.Int).Value = Obj.Auto_Compuesto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Compuesto", SqlDbType.VarChar).Value = Obj.Compuesto;
                Comando.Parameters.Add("@Compu_Descripcion", SqlDbType.VarChar).Value = Obj.Compuesto_Descripcion;
                Comando.Parameters.Add("@Compu_Unidad", SqlDbType.VarChar).Value = Obj.Compuesto_Unidad;
                Comando.Parameters.Add("@Compu_Medida", SqlDbType.VarChar).Value = Obj.Compuesto_Medida;

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
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_CodigoDeBarra", SqlDbType.Int).Value = Obj.Codigodebarra_SQL;

                //Panel Codigo De Barra -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Cod_DeBarra", SqlDbType.VarChar).Value = Obj.Codigodebarra;

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

        public string Guardar_Exterior(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Exterior", SqlDbType.Int).Value = Obj.Exterior_SQL;

                //Panel Codigo De Barra -- Campos Obligatorios
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;
                Comando.Parameters.Add("@Cod_DeBarra", SqlDbType.VarChar).Value = Obj.Codigodebarra;

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

        public string Editar_Compuesto(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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

        public string Editar_Exterior(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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

        public string Editar_Ubicacion(Entidad_Productos Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

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
                Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

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

        public string Eliminar_Compuesto(int Idproducto, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Productos.LI_DatosBasicos", SqlCon);
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

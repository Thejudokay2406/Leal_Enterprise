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
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Bodega", SqlCon);
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

        public DataTable AutoDetalle_SQL(string Valor, int auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Bodega", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto", SqlDbType.VarChar).Value = auto;
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
        
        public DataTable AutoComplementar_SQL(string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Bodega", SqlCon);
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

        public DataTable Buscar(string Valor, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Bodega", SqlCon);
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

        public string Guardar_DatosBasicos(Entidad_Bodega Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Bodega.LI_DatosBasicos", SqlCon);
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
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Medidas", SqlDbType.VarChar).Value = Obj.Dimensiones;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Zona", SqlDbType.VarChar).Value = Obj.Zona;

                //Panel Datos de Pago
                Comando.Parameters.Add("@AutorizacionDePagos", SqlDbType.VarChar).Value = Obj.AutorizacionDePagos;
                Comando.Parameters.Add("@InicioHorarioPagos", SqlDbType.VarChar).Value = Obj.InicioHorarioPagos;
                Comando.Parameters.Add("@FinHorarioPagos", SqlDbType.VarChar).Value = Obj.FinHorarioPagos;
                Comando.Parameters.Add("@Lunes_Pagos", SqlDbType.Int).Value = Obj.Lunes_Pagos;
                Comando.Parameters.Add("@Martes_Pagos", SqlDbType.Int).Value = Obj.Martes_Pagos;
                Comando.Parameters.Add("@Miercoles_Pagos", SqlDbType.Int).Value = Obj.Miercoles_Pagos;
                Comando.Parameters.Add("@Jueves_Pagos", SqlDbType.Int).Value = Obj.Jueves_Pagos;
                Comando.Parameters.Add("@Viernes_Pagos", SqlDbType.Int).Value = Obj.Viernes_Pagos;
                Comando.Parameters.Add("@Sabado_Pagos", SqlDbType.Int).Value = Obj.Sabado_Pagos;
                Comando.Parameters.Add("@Domingo_Pagos", SqlDbType.Int).Value = Obj.Domingo_Pagos;
                Comando.Parameters.Add("@Bono", SqlDbType.Int).Value = Obj.Bono;
                Comando.Parameters.Add("@Cheques", SqlDbType.Int).Value = Obj.Cheques;
                Comando.Parameters.Add("@Debito", SqlDbType.Int).Value = Obj.Debito;
                Comando.Parameters.Add("@Credito", SqlDbType.Int).Value = Obj.Credito;
                Comando.Parameters.Add("@Efectivo", SqlDbType.Int).Value = Obj.Efectivo;
                Comando.Parameters.Add("@Sodexo", SqlDbType.Int).Value = Obj.Sodexo;
                Comando.Parameters.Add("@Transferencia", SqlDbType.Int).Value = Obj.Transferencia;
                Comando.Parameters.Add("@Otros", SqlDbType.Int).Value = Obj.Otros;

                //Panel Datos de Recepcion
                Comando.Parameters.Add("@Recepcion", SqlDbType.VarChar).Value = Obj.Recepcion;
                Comando.Parameters.Add("@InicioHorarioRecepcion", SqlDbType.VarChar).Value = Obj.InicioHorarioRecepcion;
                Comando.Parameters.Add("@FinHorarioRecepcion", SqlDbType.VarChar).Value = Obj.FinHorarioRecepcion;
                Comando.Parameters.Add("@Lunes_Recepcion", SqlDbType.Int).Value = Obj.Lunes_Recepcion;
                Comando.Parameters.Add("@Martes_Recepcion", SqlDbType.Int).Value = Obj.Martes_Recepcion;
                Comando.Parameters.Add("@Miercoles_Recepcion", SqlDbType.Int).Value = Obj.Miercoles_Recepcion;
                Comando.Parameters.Add("@Jueves_Recepcion", SqlDbType.Int).Value = Obj.Jueves_Recepcion;
                Comando.Parameters.Add("@Viernes_Recepcion", SqlDbType.Int).Value = Obj.Viernes_Recepcion;
                Comando.Parameters.Add("@Sabado_Recepcion", SqlDbType.Int).Value = Obj.Sabado_Recepcion;
                Comando.Parameters.Add("@Domingo_Recepcion", SqlDbType.Int).Value = Obj.Domingo_Recepcion;
                Comando.Parameters.Add("@Encargado_Recepcion", SqlDbType.VarChar).Value = Obj.Encargado_Recepcion;
                Comando.Parameters.Add("@Observacion_Recepcion", SqlDbType.VarChar).Value = Obj.Observacion_Recepcion;

                //Panel Dias de Despacho
                Comando.Parameters.Add("@Despacho", SqlDbType.VarChar).Value = Obj.Despacho;
                Comando.Parameters.Add("@InicioHorarioDespacho", SqlDbType.VarChar).Value = Obj.InicioHorarioDespacho;
                Comando.Parameters.Add("@FinHorarioDespacho", SqlDbType.VarChar).Value = Obj.FinHorarioDespacho;
                Comando.Parameters.Add("@Lunes_Despacho", SqlDbType.Int).Value = Obj.Lunes_Despacho;
                Comando.Parameters.Add("@Martes_Despacho", SqlDbType.Int).Value = Obj.Martes_Despacho;
                Comando.Parameters.Add("@Miercoles_Despacho", SqlDbType.Int).Value = Obj.Miercoles_Despacho;
                Comando.Parameters.Add("@Jueves_Despacho", SqlDbType.Int).Value = Obj.Jueves_Despacho;
                Comando.Parameters.Add("@Viernes_Despacho", SqlDbType.Int).Value = Obj.Viernes_Despacho;
                Comando.Parameters.Add("@Sabado_Despacho", SqlDbType.Int).Value = Obj.Sabado_Despacho;
                Comando.Parameters.Add("@Domingo_Despacho", SqlDbType.Int).Value = Obj.Domingo_Despacho;
                Comando.Parameters.Add("@Encargado_Despacho", SqlDbType.VarChar).Value = Obj.Encargado_Despacho;
                Comando.Parameters.Add("@Observacion_Despacho", SqlDbType.VarChar).Value = Obj.Observacion_Despacho;

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
                SqlCommand Comando = new SqlCommand("Bodega.LI_DatosBasicos", SqlCon);
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
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Movil;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Obj.Telefono;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Correo;
                Comando.Parameters.Add("@Medidas", SqlDbType.VarChar).Value = Obj.Dimensiones;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Zona", SqlDbType.VarChar).Value = Obj.Zona;

                //Panel Datos de Pago
                Comando.Parameters.Add("@AutorizacionDePagos", SqlDbType.VarChar).Value = Obj.AutorizacionDePagos;
                Comando.Parameters.Add("@InicioHorarioPagos", SqlDbType.VarChar).Value = Obj.InicioHorarioPagos;
                Comando.Parameters.Add("@FinHorarioPagos", SqlDbType.VarChar).Value = Obj.FinHorarioPagos;
                Comando.Parameters.Add("@Lunes_Pagos", SqlDbType.Int).Value = Obj.Lunes_Pagos;
                Comando.Parameters.Add("@Martes_Pagos", SqlDbType.Int).Value = Obj.Martes_Pagos;
                Comando.Parameters.Add("@Miercoles_Pagos", SqlDbType.Int).Value = Obj.Miercoles_Pagos;
                Comando.Parameters.Add("@Jueves_Pagos", SqlDbType.Int).Value = Obj.Jueves_Pagos;
                Comando.Parameters.Add("@Viernes_Pagos", SqlDbType.Int).Value = Obj.Viernes_Pagos;
                Comando.Parameters.Add("@Sabado_Pagos", SqlDbType.Int).Value = Obj.Sabado_Pagos;
                Comando.Parameters.Add("@Domingo_Pagos", SqlDbType.Int).Value = Obj.Domingo_Pagos;
                Comando.Parameters.Add("@Bono", SqlDbType.Int).Value = Obj.Bono;
                Comando.Parameters.Add("@Cheques", SqlDbType.Int).Value = Obj.Cheques;
                Comando.Parameters.Add("@Credito", SqlDbType.Int).Value = Obj.Credito;
                Comando.Parameters.Add("@Debito", SqlDbType.Int).Value = Obj.Debito;
                Comando.Parameters.Add("@Efectivo", SqlDbType.Int).Value = Obj.Efectivo;
                Comando.Parameters.Add("@Sodexo", SqlDbType.Int).Value = Obj.Sodexo;
                Comando.Parameters.Add("@Transferencia", SqlDbType.Int).Value = Obj.Transferencia;
                Comando.Parameters.Add("@Otros", SqlDbType.Int).Value = Obj.Otros;

                //Panel Datos de Recepcion
                Comando.Parameters.Add("@Recepcion", SqlDbType.VarChar).Value = Obj.Recepcion;
                Comando.Parameters.Add("@InicioHorarioRecepcion", SqlDbType.VarChar).Value = Obj.InicioHorarioRecepcion;
                Comando.Parameters.Add("@FinHorarioRecepcion", SqlDbType.VarChar).Value = Obj.FinHorarioRecepcion;
                Comando.Parameters.Add("@Lunes_Recepcion", SqlDbType.Int).Value = Obj.Lunes_Recepcion;
                Comando.Parameters.Add("@Martes_Recepcion", SqlDbType.Int).Value = Obj.Martes_Recepcion;
                Comando.Parameters.Add("@Miercoles_Recepcion", SqlDbType.Int).Value = Obj.Miercoles_Recepcion;
                Comando.Parameters.Add("@Jueves_Recepcion", SqlDbType.Int).Value = Obj.Jueves_Recepcion;
                Comando.Parameters.Add("@Viernes_Recepcion", SqlDbType.Int).Value = Obj.Viernes_Recepcion;
                Comando.Parameters.Add("@Sabado_Recepcion", SqlDbType.Int).Value = Obj.Sabado_Recepcion;
                Comando.Parameters.Add("@Domingo_Recepcion", SqlDbType.Int).Value = Obj.Domingo_Recepcion;
                Comando.Parameters.Add("@Encargado_Recepcion", SqlDbType.VarChar).Value = Obj.Encargado_Recepcion;
                Comando.Parameters.Add("@Observacion_Recepcion", SqlDbType.VarChar).Value = Obj.Observacion_Recepcion;

                //Panel Dias de Despacho
                Comando.Parameters.Add("@Despacho", SqlDbType.VarChar).Value = Obj.Despacho;
                Comando.Parameters.Add("@InicioHorarioDespacho", SqlDbType.VarChar).Value = Obj.InicioHorarioDespacho;
                Comando.Parameters.Add("@FinHorarioDespacho", SqlDbType.VarChar).Value = Obj.FinHorarioDespacho;
                Comando.Parameters.Add("@Lunes_Despacho", SqlDbType.Int).Value = Obj.Lunes_Despacho;
                Comando.Parameters.Add("@Martes_Despacho", SqlDbType.Int).Value = Obj.Martes_Despacho;
                Comando.Parameters.Add("@Miercoles_Despacho", SqlDbType.Int).Value = Obj.Miercoles_Despacho;
                Comando.Parameters.Add("@Jueves_Despacho", SqlDbType.Int).Value = Obj.Jueves_Despacho;
                Comando.Parameters.Add("@Viernes_Despacho", SqlDbType.Int).Value = Obj.Viernes_Despacho;
                Comando.Parameters.Add("@Sabado_Despacho", SqlDbType.Int).Value = Obj.Sabado_Despacho;
                Comando.Parameters.Add("@Domingo_Despacho", SqlDbType.Int).Value = Obj.Domingo_Despacho;
                Comando.Parameters.Add("@Encargado_Despacho", SqlDbType.VarChar).Value = Obj.Encargado_Despacho;
                Comando.Parameters.Add("@Observacion_Despacho", SqlDbType.VarChar).Value = Obj.Observacion_Despacho;

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
                SqlCommand Comando = new SqlCommand("Consulta.Bodega", SqlCon);
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

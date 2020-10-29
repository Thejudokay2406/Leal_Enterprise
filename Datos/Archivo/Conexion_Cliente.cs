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
                SqlCommand Comando = new SqlCommand("Cliente.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llaves Primarias
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;
                
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Dat_Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Dat_Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Dat_Documento;
                Comando.Parameters.Add("@Telefono01", SqlDbType.VarChar).Value = Obj.Dat_Telefono;
                Comando.Parameters.Add("@Telefono02", SqlDbType.VarChar).Value = Obj.Dat_TelefonoAux;
                Comando.Parameters.Add("@Movil01", SqlDbType.VarChar).Value = Obj.Dat_Movil;
                Comando.Parameters.Add("@Movil02", SqlDbType.VarChar).Value = Obj.Dat_MovilAux;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Dat_Correo;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Dat_Ciudad;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Dat_Pais;
                Comando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Obj.Dat_Departamento;
                Comando.Parameters.Add("@Web", SqlDbType.VarChar).Value = Obj.Dat_PaginaWeb;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Dat_Direccion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Dat_Observacion;
                Comando.Parameters.Add("@Efectivo", SqlDbType.Int).Value = Obj.Dat_Efectivo;
                Comando.Parameters.Add("@Credito", SqlDbType.Int).Value = Obj.Dat_Credito;
                Comando.Parameters.Add("@Debito", SqlDbType.Int).Value = Obj.Dat_Debito;
                Comando.Parameters.Add("@Contado", SqlDbType.Int).Value = Obj.Dat_Contado;

                //Variables Para Ejecutar Si o No Las Transacciones
                Comando.Parameters.Add("@Tran_Contacto", SqlDbType.Int).Value = Obj.Tran_Contacto;
                Comando.Parameters.Add("@Tran_Credito", SqlDbType.Int).Value = Obj.Tran_Credito;
                Comando.Parameters.Add("@Tran_Despacho", SqlDbType.Int).Value = Obj.Tran_Despacho;
                Comando.Parameters.Add("@Tran_Facturacion", SqlDbType.Int).Value = Obj.Tran_Facturacion;
                Comando.Parameters.Add("@Tran_Financiera", SqlDbType.Int).Value = Obj.Tran_Financiera;

                //Panel Facturacion -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Facturacion", SqlDbType.Structured).Value = Obj.Det_Facturacion;

                //Panel Envio Despacho -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Despacho", SqlDbType.Structured).Value = Obj.Det_Despacho;

                //Panel Credito -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Credito", SqlDbType.Structured).Value = Obj.Det_Credito;

                //Panel Financiera -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Financiera", SqlDbType.Structured).Value = Obj.Det_Financiera;

                //Panel Contacto -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Contacto", SqlDbType.Structured).Value = Obj.Det_Contacto;

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
                SqlCommand Comando = new SqlCommand("Cliente.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llaves Primarias
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;

                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Dat_Codigo;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Dat_Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Dat_Documento;
                Comando.Parameters.Add("@Telefono01", SqlDbType.VarChar).Value = Obj.Dat_Telefono;
                Comando.Parameters.Add("@Telefono02", SqlDbType.VarChar).Value = Obj.Dat_TelefonoAux;
                Comando.Parameters.Add("@Movil01", SqlDbType.VarChar).Value = Obj.Dat_Movil;
                Comando.Parameters.Add("@Movil02", SqlDbType.VarChar).Value = Obj.Dat_MovilAux;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Dat_Correo;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Dat_Ciudad;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Dat_Pais;
                Comando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = Obj.Dat_Departamento;
                Comando.Parameters.Add("@Web", SqlDbType.VarChar).Value = Obj.Dat_PaginaWeb;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Dat_Direccion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Dat_Observacion;
                Comando.Parameters.Add("@Efectivo", SqlDbType.Int).Value = Obj.Dat_Efectivo;
                Comando.Parameters.Add("@Credito", SqlDbType.Int).Value = Obj.Dat_Credito;
                Comando.Parameters.Add("@Debito", SqlDbType.Int).Value = Obj.Dat_Debito;
                Comando.Parameters.Add("@Contado", SqlDbType.Int).Value = Obj.Dat_Contado;

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

        public string Editar_Ubicacion(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                //SqlCommand Comando = new SqlCommand("Almacen.LI_Cliente", SqlCon);
                //Comando.CommandType = CommandType.StoredProcedure;

                ////Datos Auxiliares
                //Comando.Parameters.Add("@Auto_Ubicacion", SqlDbType.Int).Value = Obj.Auto_Ubicacion;
                //Comando.Parameters.Add("@Idproducto", SqlDbType.Int).Value = Obj.Idproducto;

                ////Panel Ubicaciones -- Campos Obligatorios
                //Comando.Parameters.Add("@Ubicacion_Edi", SqlDbType.VarChar).Value = Obj.Ubicacion;
                //Comando.Parameters.Add("@Estante_Edi", SqlDbType.VarChar).Value = Obj.Estante;
                //Comando.Parameters.Add("@Nivel_Edi", SqlDbType.VarChar).Value = Obj.Nivel;

                //SqlCon.Open();
                //Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Actualizar el Registro";
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

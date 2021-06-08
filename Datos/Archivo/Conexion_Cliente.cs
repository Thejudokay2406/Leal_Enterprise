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

        public DataTable Lista_Facturacion(int Auto, int idcliente)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Facturacion", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente;

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

        public DataTable Lista_Despacho(int Auto, int idcliente)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Despacho", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente;

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

        public DataTable Lista_Financiera(int Auto, int idcliente)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Financiera", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente;

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

        public DataTable Lista_Contacto(int Auto, int idcliente)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro_Contacto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = idcliente;

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

        public DataTable Buscar(string Filtro, int Auto)
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
                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro;

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

        public DataTable Buscar_Facturacion(int auto_impuesto, int Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Factura", SqlDbType.Int).Value = auto_impuesto;
                Comando.Parameters.Add("@Det_Factura", SqlDbType.Int).Value = Filtro;

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

        public DataTable Buscar_Financiera(int auto_Financiera, int Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Financiera", SqlDbType.Int).Value = auto_Financiera;
                Comando.Parameters.Add("@Det_Financiera", SqlDbType.Int).Value = Filtro;

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

        public DataTable Buscar_Contacto(int auto_Contacto, int Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Contacto", SqlDbType.Int).Value = auto_Contacto;
                Comando.Parameters.Add("@Det_Contacto", SqlDbType.Int).Value = Filtro;

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

        public DataTable Buscar_Despacho(int auto_Despacho, int Filtro)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Auto_Despacho", SqlDbType.Int).Value = auto_Despacho;
                Comando.Parameters.Add("@Det_Despacho", SqlDbType.Int).Value = Filtro;

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
                SqlCommand Comando = new SqlCommand("Consulta.Cliente", SqlCon);
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
                Comando.Parameters.Add("@Contacto_AutoSQL", SqlDbType.Int).Value = Obj.Contacto_AutoSQL;
                Comando.Parameters.Add("@Envio_AutoSQL", SqlDbType.Int).Value = Obj.Despacho_AutoSQL;
                Comando.Parameters.Add("@Facturacion_AutoSQL", SqlDbType.Int).Value = Obj.Facturacion_AutoSQL;
                Comando.Parameters.Add("@Financiera_AutoSQL", SqlDbType.Int).Value = Obj.Financiera_AutoSQL;

                Comando.Parameters.Add("@Idgrupo", SqlDbType.Int).Value = Obj.Idgrupo;
                Comando.Parameters.Add("@Idtipo", SqlDbType.Int).Value = Obj.Idtipo;

                //Variables Para Ejecutar Si o No Las Transacciones
                Comando.Parameters.Add("@Tran_Contacto", SqlDbType.Int).Value = Obj.Tran_Contacto;
                Comando.Parameters.Add("@Tran_Envio", SqlDbType.Int).Value = Obj.Tran_Despacho;
                Comando.Parameters.Add("@Tran_Facturacion", SqlDbType.Int).Value = Obj.Tran_Facturacion;
                Comando.Parameters.Add("@Tran_Financiera", SqlDbType.Int).Value = Obj.Tran_Financiera;

                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Dat_Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.BigInt).Value = Obj.Dat_Documento;
                Comando.Parameters.Add("@Telefono01", SqlDbType.BigInt).Value = Obj.Dat_Telefono01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.BigInt).Value = Obj.Dat_Telefono02;
                Comando.Parameters.Add("@Movil01", SqlDbType.BigInt).Value = Obj.Dat_Movil;
                Comando.Parameters.Add("@Movil02", SqlDbType.BigInt).Value = Obj.Dat_Movil02;
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

                //Panel Facturacion -- Campos Obligatorios
                Comando.Parameters.Add("@Det_Facturacion", SqlDbType.Structured).Value = Obj.Det_Facturacion;

                //Panel Envio Despacho -- Campos NO Obligatorios
                Comando.Parameters.Add("@Det_Envio", SqlDbType.Structured).Value = Obj.Det_Despacho;

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

        public string Guardar_Facturacion(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Facturacion", SqlDbType.Int).Value = Obj.AutoDet_Facturacion;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                Comando.Parameters.Add("@Empleado", SqlDbType.VarChar).Value = Obj.Fac_Asesor;
                Comando.Parameters.Add("@CodEmpleado", SqlDbType.VarChar).Value = Obj.Fac_AsesorCodigo;
                Comando.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Obj.Fac_Cliente;
                Comando.Parameters.Add("@DocCliente", SqlDbType.BigInt).Value = Obj.Fac_ClienteDoc;
                Comando.Parameters.Add("@Movil", SqlDbType.BigInt).Value = Obj.Fac_Movil;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Fac_Ciudad;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Fac_Correo;

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

        public string Guardar_Despacho(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Despacho", SqlDbType.Int).Value = Obj.AutoDet_Despacho;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Des_Ciudad;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Des_Receptor;
                Comando.Parameters.Add("@Movil", SqlDbType.BigInt).Value = Obj.Des_Movil;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Des_Direccion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Des_Observacion;

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

        public string Guardar_Financiera(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Financiera", SqlDbType.Int).Value = Obj.AutoDet_Financiera;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                //Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Obj.idban;
                Comando.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = Obj.Fin_Cuenta;
                Comando.Parameters.Add("@NumeroCuenta", SqlDbType.BigInt).Value = Obj.Fin_CuentaNumero;

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

        public string Guardar_Contacto(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Contacto", SqlDbType.Int).Value = Obj.AutoDet_Contacto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Obj.Cont_Contacto;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Cont_Ciudad;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Cont_Direccion;
                Comando.Parameters.Add("@Movil", SqlDbType.BigInt).Value = Obj.Cont_Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Cont_Correo;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Cont_Parentesco;
                
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

                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Dat_Cliente;
                Comando.Parameters.Add("@Documento", SqlDbType.VarChar).Value = Obj.Dat_Documento;
                Comando.Parameters.Add("@Telefono01", SqlDbType.VarChar).Value = Obj.Dat_Telefono01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.VarChar).Value = Obj.Dat_Telefono02;
                Comando.Parameters.Add("@Movil01", SqlDbType.VarChar).Value = Obj.Dat_Movil;
                Comando.Parameters.Add("@Movil02", SqlDbType.VarChar).Value = Obj.Dat_Movil02;
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

        public string Editar_Facturacion(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idfacturacion", SqlDbType.Int).Value = Obj.Idfacturacion;
                Comando.Parameters.Add("@Auto_Facturacion", SqlDbType.Int).Value = Obj.AutoDet_Facturacion;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                Comando.Parameters.Add("@Empleado", SqlDbType.VarChar).Value = Obj.Fac_Asesor;
                Comando.Parameters.Add("@CodEmpleado", SqlDbType.VarChar).Value = Obj.Fac_AsesorCodigo;
                Comando.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = Obj.Fac_Cliente;
                Comando.Parameters.Add("@DocCliente", SqlDbType.VarChar).Value = Obj.Fac_ClienteDoc;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Fac_Movil;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Fac_Ciudad;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Fac_Correo;

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

        public string Editar_Despacho(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Iddespacho", SqlDbType.Int).Value = Obj.Iddespacho;
                Comando.Parameters.Add("@Auto_Despacho", SqlDbType.Int).Value = Obj.AutoDet_Despacho;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Des_Ciudad;
                Comando.Parameters.Add("@Receptor", SqlDbType.VarChar).Value = Obj.Des_Receptor;
                Comando.Parameters.Add("@Movil", SqlDbType.VarChar).Value = Obj.Des_Movil;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Des_Direccion;
                Comando.Parameters.Add("@Observacion", SqlDbType.VarChar).Value = Obj.Des_Observacion;

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

        public string Editar_Financiera(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idfinanciera", SqlDbType.Int).Value = Obj.Idfinanciera;
                Comando.Parameters.Add("@Auto_Financiera", SqlDbType.Int).Value = Obj.AutoDet_Financiera;

                //Panel Ubicaciones -- Campos Obligatorios
                //Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Obj.idban;
                Comando.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = Obj.Fin_Cuenta;
                Comando.Parameters.Add("@NumeroCuenta", SqlDbType.VarChar).Value = Obj.Fin_CuentaNumero;

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

        public string Editar_Contacto(Entidad_Cliente Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Obj.Idcliente;
                Comando.Parameters.Add("@Idcontacto", SqlDbType.Int).Value = Obj.Idcontacto;
                Comando.Parameters.Add("@Auto_Contacto", SqlDbType.Int).Value = Obj.AutoDet_Contacto;

                //Panel Ubicaciones -- Campos Obligatorios
                Comando.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Obj.Cont_Contacto;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Cont_Ciudad;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Obj.Cont_Direccion;
                Comando.Parameters.Add("@Movil", SqlDbType.Int).Value = Obj.Cont_Movil;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Obj.Cont_Correo;
                Comando.Parameters.Add("@Parentesco", SqlDbType.VarChar).Value = Obj.Cont_Parentesco;

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


        public string Eliminar_Facturacion(int Idcliente, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idfacturacion", SqlDbType.Int).Value = Iddetalle;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Idcliente;

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

        public string Eliminar_Despacho(int Idcliente, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Idcliente;
                Comando.Parameters.Add("@Iddespacho", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_Financiera(int Idcliente, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Idcliente;
                Comando.Parameters.Add("@Idfinanciera", SqlDbType.Int).Value = Iddetalle;

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

        public string Eliminar_Contacto(int Idcliente, int Iddetalle, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Cliente.Detalles_Adicional", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idcliente", SqlDbType.Int).Value = Idcliente;
                Comando.Parameters.Add("@Idcontacto", SqlDbType.Int).Value = Iddetalle;

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

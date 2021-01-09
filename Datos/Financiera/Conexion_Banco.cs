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
    public class Conexion_Banco
    {
        public DataTable Lista()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Banco", SqlCon);
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

        public DataTable Existencia_Banco(int Idsql , int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Exis_Banco", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Idsql;

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

        public DataTable Existencia_Contacto(int Idsql, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Exis_Contacto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idcontacto", SqlDbType.Int).Value = Idsql;

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

        public DataTable Lista_Contacto(int Auto, int idbanco)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta_Contacto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = idbanco;

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


        public DataTable Buscar_Contacto(int auto_contacto, string Valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Consulta.Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Consulta_Contacto", SqlDbType.Int).Value = auto_contacto;
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

        public DataTable Buscar(string Filtro, int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.Add("@Filtro", SqlDbType.VarChar).Value = Filtro;
                Comando.Parameters.Add("@Consulta_Banco", SqlDbType.Int).Value = Auto;

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

        public string Guardar_DatosBasicos(Entidad_Banco Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Identificacion", SqlDbType.BigInt).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Area", SqlDbType.VarChar).Value = Obj.Area;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Telefono01", SqlDbType.BigInt).Value = Obj.Telefono01;
                Comando.Parameters.Add("@Extension01", SqlDbType.BigInt).Value = Obj.Extension01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.BigInt).Value = Obj.Telefono02;
                Comando.Parameters.Add("@Extension02", SqlDbType.BigInt).Value = Obj.Extension02;
                Comando.Parameters.Add("@Movil01", SqlDbType.BigInt).Value = Obj.Movil01;
                Comando.Parameters.Add("@Movil02", SqlDbType.BigInt).Value = Obj.Movil02;
                Comando.Parameters.Add("@Pagina", SqlDbType.VarChar).Value = Obj.Pagina;

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

        public string Guardar_Contacto(Entidad_Banco Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto_Contacto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Obj.Idbanco;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Cont_Asesor", SqlDbType.VarChar).Value = Obj.Cont_Asesor;
                Comando.Parameters.Add("@Cont_Cargo", SqlDbType.VarChar).Value = Obj.Cont_Cargo;
                Comando.Parameters.Add("@Cont_Ciudad", SqlDbType.VarChar).Value = Obj.Cont_Ciudad;
                Comando.Parameters.Add("@Cont_Telefono", SqlDbType.BigInt).Value = Obj.Cont_Telefono;
                Comando.Parameters.Add("@Cont_Extension", SqlDbType.BigInt).Value = Obj.Cont_Extension;
                Comando.Parameters.Add("@Cont_Movil", SqlDbType.BigInt).Value = Obj.Cont_Movil;
                Comando.Parameters.Add("@Cont_Area", SqlDbType.VarChar).Value = Obj.Cont_Area;
                Comando.Parameters.Add("@Cont_Observacion", SqlDbType.VarChar).Value = Obj.Cont_Observacion1;

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

        public string Editar_DatosBasicos(Entidad_Banco Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Obj.Idbanco;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@Identificacion", SqlDbType.BigInt).Value = Obj.Identificacion;
                Comando.Parameters.Add("@Pais", SqlDbType.VarChar).Value = Obj.Pais;
                Comando.Parameters.Add("@Ciudad", SqlDbType.VarChar).Value = Obj.Ciudad;
                Comando.Parameters.Add("@Area", SqlDbType.VarChar).Value = Obj.Area;
                Comando.Parameters.Add("@Direccion01", SqlDbType.VarChar).Value = Obj.Direccion01;
                Comando.Parameters.Add("@Direccion02", SqlDbType.VarChar).Value = Obj.Direccion02;
                Comando.Parameters.Add("@Telefono01", SqlDbType.BigInt).Value = Obj.Telefono01;
                Comando.Parameters.Add("@Extension01", SqlDbType.BigInt).Value = Obj.Extension01;
                Comando.Parameters.Add("@Telefono02", SqlDbType.BigInt).Value = Obj.Telefono02;
                Comando.Parameters.Add("@Extension02", SqlDbType.BigInt).Value = Obj.Extension02;
                Comando.Parameters.Add("@Movil01", SqlDbType.BigInt).Value = Obj.Movil01;
                Comando.Parameters.Add("@Movil02", SqlDbType.BigInt).Value = Obj.Movil02;
                Comando.Parameters.Add("@Pagina", SqlDbType.VarChar).Value = Obj.Pagina;

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

        public string Editar_Contacto(Entidad_Banco Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares
                Comando.Parameters.Add("@Auto_Contacto", SqlDbType.Int).Value = Obj.Auto_Contacto;
                Comando.Parameters.Add("@Idcontacto", SqlDbType.Int).Value = Obj.Idcontacto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Obj.Idbanco;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Cont_Asesor", SqlDbType.VarChar).Value = Obj.Cont_Asesor;
                Comando.Parameters.Add("@Cont_Cargo", SqlDbType.VarChar).Value = Obj.Cont_Cargo;
                Comando.Parameters.Add("@Cont_Ciudad", SqlDbType.VarChar).Value = Obj.Cont_Ciudad;
                Comando.Parameters.Add("@Cont_Telefono", SqlDbType.BigInt).Value = Obj.Cont_Telefono;
                Comando.Parameters.Add("@Cont_Extension", SqlDbType.BigInt).Value = Obj.Cont_Extension;
                Comando.Parameters.Add("@Cont_Movil", SqlDbType.BigInt).Value = Obj.Cont_Movil;
                Comando.Parameters.Add("@Cont_Area", SqlDbType.VarChar).Value = Obj.Cont_Area;
                Comando.Parameters.Add("@Cont_Observacion", SqlDbType.VarChar).Value = Obj.Cont_Observacion1;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "Error al Modificar el Registro";
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


        //METODO ELIMINAR
        public string Eliminar(int IDEliminar_Sql, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = IDEliminar_Sql;

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

        public string Eliminar_Contacto(int Idbanco, int Auto)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Financiera.LI_Banco", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Eliminar_Contacto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idbanco", SqlDbType.Int).Value = Idbanco;

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

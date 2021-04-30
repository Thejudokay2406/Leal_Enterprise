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
    public class Conexion_Empleados
    {
        public DataTable AutoIncrementable(int Auto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
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
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
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

        public string Guardar_DatosBasicos(Entidad_Empleados Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idsucurzal", SqlDbType.Int).Value = Obj.Idsucurzal;
                Comando.Parameters.Add("@Idtcontrato", SqlDbType.Int).Value = Obj.Idcontrato;
                Comando.Parameters.Add("@Iddepartamento", SqlDbType.Int).Value = Obj.Iddepartamento;
                
                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Empleado", SqlDbType.VarChar).Value = Obj.Empleado;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Profesion", SqlDbType.VarChar).Value = Obj.Profesion;
                Comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = Obj.Email;
                Comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = Obj.Foto;

                //Datos Contacto Domicialiario
                Comando.Parameters.Add("@PaisDomi", SqlDbType.VarChar).Value = Obj.PaisDom;
                Comando.Parameters.Add("@CiudadDomi", SqlDbType.VarChar).Value = Obj.CiudadDom;
                Comando.Parameters.Add("@FijoDomi", SqlDbType.VarChar).Value = Obj.FijoDom;
                Comando.Parameters.Add("@ExtensionDomi", SqlDbType.VarChar).Value = Obj.ExtensionDom;
                Comando.Parameters.Add("@MovilDomi", SqlDbType.VarChar).Value = Obj.MovilDom;
                Comando.Parameters.Add("@DireccionDomi", SqlDbType.VarChar).Value = Obj.DireccionDom;

                //Datos Contacto Empresarial
                Comando.Parameters.Add("@PaisEmp", SqlDbType.VarChar).Value = Obj.PaisEmp;
                Comando.Parameters.Add("@CiudadEmp", SqlDbType.VarChar).Value = Obj.CiudadEmp;
                Comando.Parameters.Add("@FijoEmp", SqlDbType.VarChar).Value = Obj.FijoEmp;
                Comando.Parameters.Add("@ExtensionEmp", SqlDbType.VarChar).Value = Obj.ExtensionEmp;
                Comando.Parameters.Add("@MovilEmp", SqlDbType.VarChar).Value = Obj.MovilEmp;
                Comando.Parameters.Add("@DireccionEmp", SqlDbType.VarChar).Value = Obj.DireccionEmp;

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
        public string Editar_DatosBasicos(Entidad_Empleados Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion_SQLServer.getInstancia().Conexion();
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Datos Auxiliares y Llave Primaria
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Obj.Auto;
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = Obj.Idempleado;
                Comando.Parameters.Add("@Idsucurzal", SqlDbType.Int).Value = Obj.Idsucurzal;
                Comando.Parameters.Add("@Idtcontrato", SqlDbType.Int).Value = Obj.Idcontrato;
                Comando.Parameters.Add("@Iddepartamento", SqlDbType.Int).Value = Obj.Iddepartamento;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("@Empleado", SqlDbType.VarChar).Value = Obj.Empleado;
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Obj.Documento;
                Comando.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = Obj.Cargo;
                Comando.Parameters.Add("@Profesion", SqlDbType.VarChar).Value = Obj.Profesion;
                Comando.Parameters.Add("@Email", SqlDbType.VarChar).Value = Obj.Email;
                Comando.Parameters.Add("@Imagen", SqlDbType.Image).Value = Obj.Foto;

                //Datos Contacto Domicialiario
                Comando.Parameters.Add("@PaisDomi", SqlDbType.VarChar).Value = Obj.PaisDom;
                Comando.Parameters.Add("@CiudadDomi", SqlDbType.VarChar).Value = Obj.CiudadDom;
                Comando.Parameters.Add("@FijoDomi", SqlDbType.VarChar).Value = Obj.FijoDom;
                Comando.Parameters.Add("@ExtensionDomi", SqlDbType.VarChar).Value = Obj.ExtensionDom;
                Comando.Parameters.Add("@MovilDomi", SqlDbType.VarChar).Value = Obj.MovilDom;
                Comando.Parameters.Add("@DireccionDomi", SqlDbType.VarChar).Value = Obj.DireccionDom;

                //Datos Contacto Empresarial
                Comando.Parameters.Add("@PaisEmp", SqlDbType.VarChar).Value = Obj.PaisEmp;
                Comando.Parameters.Add("@CiudadEmp", SqlDbType.VarChar).Value = Obj.CiudadEmp;
                Comando.Parameters.Add("@FijoEmp", SqlDbType.VarChar).Value = Obj.FijoEmp;
                Comando.Parameters.Add("@ExtensionEmp", SqlDbType.VarChar).Value = Obj.ExtensionEmp;
                Comando.Parameters.Add("@MovilEmp", SqlDbType.VarChar).Value = Obj.MovilEmp;
                Comando.Parameters.Add("@DireccionEmp", SqlDbType.VarChar).Value = Obj.DireccionEmp;

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
                SqlCommand Comando = new SqlCommand("Empleado.LI_DatosBasicos", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                //Panel Datos Basicos
                Comando.Parameters.Add("@Auto", SqlDbType.Int).Value = Auto;
                Comando.Parameters.Add("@Idempleado", SqlDbType.Int).Value = IDEliminar_Sql;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fUsuarios
    {
        public static DataTable Lista()
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            return Datos.Lista();
        }

        public static DataTable Login_SQL(string usuario, string contraseña)
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            return Datos.Login_SQL(usuario, contraseña);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primarias
                int auto, int idempelado,

                //Datos Basicos
                string empleado, string usuario, string contraseña, string descripcion, int estado,

                //Niveles
                int almacen, int financiera, int gestionhumana, int produccion,
                int reporte, int tesoreria, int ventas, int sistema,

                //Permisos
                int guardar, int eliminar, int editar, int consultar

            )
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            Entidad_Usuarios Obj = new Entidad_Usuarios();

            //Llaves Primarias
            Obj.Idempleado = idempelado;

            //Datos Basicos
            Obj.Empleado = empleado;
            Obj.Usuario = usuario;
            Obj.Contraseña = contraseña;
            Obj.Descripcion = descripcion;

            //Niveles
            Obj.Almacen = almacen;
            Obj.Financiera = financiera;
            Obj.GestionHumana = gestionhumana;
            Obj.Produccion = produccion;
            Obj.Reportes = reporte;
            Obj.Tesoreria = tesoreria;
            Obj.Ventas = ventas;
            Obj.Sistema = sistema;

            //Permisos
            Obj.Guardar = guardar;
            Obj.Eliminar = eliminar;
            Obj.Editar = editar;
            Obj.Consultar = consultar;

            //Metodos y Filtros

            Obj.Auto = auto;
            Obj.Estado = estado;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primarias
                int auto, int idempelado,

                //Datos Basicos
                string empleado, string usuario, string contraseña, string descripcion, int estado,

                //Niveles
                int almacen, int financiera, int gestionhumana, int produccion,
                int reporte, int tesoreria, int ventas, int sistema,

                //Permisos
                int guardar, int eliminar, int editar, int consultar
            )
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            Entidad_Usuarios Obj = new Entidad_Usuarios();

            //Llaves Primarias
            Obj.Idempleado = idempelado;

            //Datos Basicos
            Obj.Empleado = empleado;
            Obj.Usuario = usuario;
            Obj.Contraseña = contraseña;
            Obj.Descripcion = descripcion;

            //Niveles
            Obj.Almacen = almacen;
            Obj.Financiera = financiera;
            Obj.GestionHumana = gestionhumana;
            Obj.Produccion = produccion;
            Obj.Reportes = reporte;
            Obj.Tesoreria = tesoreria;
            Obj.Ventas = ventas;
            Obj.Sistema = sistema;

            //Permisos
            Obj.Guardar = guardar;
            Obj.Eliminar = eliminar;
            Obj.Editar = editar;
            Obj.Consultar = consultar;

            //Metodos y Filtros

            Obj.Auto = auto;
            Obj.Estado = estado;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Usuarios Datos = new Conexion_Usuarios();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

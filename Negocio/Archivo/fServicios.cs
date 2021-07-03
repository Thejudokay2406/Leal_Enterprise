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
    public class fServicios
    {
        public static DataTable AutoIncrementable(int auto)
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            return Datos.AutoIncrementable(auto);
        }

        public static DataTable Lista(int auto)
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            return Datos.Lista(auto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idimpuesto,

                //Datos Basicos
                string Codigo, string Servicio, string Descripcion, string Clase, double Costo, double Valor01, double Valor02,double Valor03, Int64 Utilidad, Int64 Ejecucion, string Observacion
            )
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            Entidad_Servicio Obj = new Entidad_Servicio();

            //Datos Auxiliares y Llave Primaria Auxiliares
            Obj.Auto = auto;
            Obj.Idimpuesto = idimpuesto;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Servicio = Servicio;
            Obj.Descripcion = Descripcion;
            Obj.Clase = Clase;
            Obj.Costo = Costo;
            Obj.Valor01 = Valor01;
            Obj.Valor02 = Valor02;
            Obj.Valor03 = Valor03;
            Obj.Utilidad = Utilidad;
            Obj.Ejecucion = Ejecucion;
            Obj.Observacion = Observacion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idservicio, int idimpuesto,

                //Datos Basicos
                string Codigo, string Servicio, string Descripcion, string Clase, double Costo, double Valor01, double Valor02, double Valor03, Int64 Utilidad, Int64 Ejecucion, string Observacion
            )
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            Entidad_Servicio Obj = new Entidad_Servicio();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Llaves Auxiliares y Llave Primaria
            Obj.Idservicio = idservicio;
            Obj.Idimpuesto = idimpuesto;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Servicio = Servicio;
            Obj.Descripcion = Descripcion;
            Obj.Clase = Clase;
            Obj.Costo = Costo;
            Obj.Valor01 = Valor01;
            Obj.Valor02 = Valor02;
            Obj.Valor03 = Valor03;
            Obj.Utilidad = Utilidad;
            Obj.Ejecucion = Ejecucion;
            Obj.Observacion = Observacion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Servicios Datos = new Conexion_Servicios();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

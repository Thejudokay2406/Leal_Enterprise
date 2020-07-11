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
    public class fEquipos
    {
        public static DataTable Lista()
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro)
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            return Datos.Buscar(Filtro);
        }

        public static DataTable Seguridad_SQL(string equipo, string hdd, string macseguridad)
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            return Datos.Seguridad_SQL(equipo, hdd, macseguridad);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Basicos
                string equipo, string hdd, string tipo,
                string mac_seguridad, int estado,

                //Metodos de Operacion
                int auto
            )
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            Entidad_Equipos Obj = new Entidad_Equipos();

            //Datos Basicos
            Obj.Equipo = equipo;
            Obj.HDD = hdd;
            Obj.Tipo = tipo;
            Obj.Mac_Seguridad = mac_seguridad;
            Obj.Estado = estado;

            Obj.Auto = auto;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llave Primaria
                int auto, int idequipo,
                //Datos Basicos
                string equipo, string hdd, string tipo,
                string mac_seguridad, int estado

            )
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            Entidad_Equipos Obj = new Entidad_Equipos();

            Obj.Equipo = equipo;
            Obj.HDD = hdd;
            Obj.Tipo = tipo;
            Obj.Mac_Seguridad = mac_seguridad;
            Obj.Estado = estado;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Equipos Datos = new Conexion_Equipos();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

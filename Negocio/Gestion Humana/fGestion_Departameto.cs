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
    public class fGestion_Departameto
    {
        public static DataTable Lista()
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string Departamento, string AreaPrincipal, string AreaAuxiliar, DateTime Apertura, string Descripcion
            )
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            Entidad_Departamento Obj = new Entidad_Departamento();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Departamento = Departamento;
            Obj.AreaPrincipal = AreaPrincipal;
            Obj.AreaAuxiliar = AreaAuxiliar;
            Obj.Apertura = Apertura;
            Obj.Descripcion = Descripcion;
                    
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int iddepartamento,

                //Datos Basicos
                string Departamento, string AreaPrincipal, string AreaAuxiliar, DateTime Apertura, string Descripcion
            )
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            Entidad_Departamento Obj = new Entidad_Departamento();

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Iddepartamento = iddepartamento;

            //Datos Basicos
            Obj.Departamento = Departamento;
            Obj.AreaPrincipal = AreaPrincipal;
            Obj.AreaAuxiliar = AreaAuxiliar;
            Obj.Apertura = Apertura;
            Obj.Descripcion = Descripcion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Departamento Datos = new Conexion_Departamento();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

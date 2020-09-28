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
    public class fGestion_TipoDeContrato
    {
        public static DataTable Lista()
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                //Datos Basicos
                string Codigo, string Contrato, string Sueldo, string Moneda, string Descripcion
            )
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            Entidad_TipoDeContrato Obj = new Entidad_TipoDeContrato();

            //Datos Auxiliares
            Obj.Auto = auto;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Contrato = Contrato;
            Obj.Sueldo = Sueldo;
            Obj.Moneda = Moneda;
            Obj.Descripcion = Descripcion;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipocontrato,

                //Datos Basicos
                string Codigo, string Contrato, string Sueldo, string Moneda, string Descripcion
            )
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            Entidad_TipoDeContrato Obj = new Entidad_TipoDeContrato();

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Idtcontrato = idtipocontrato;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Contrato = Contrato;
            Obj.Sueldo = Sueldo;
            Obj.Moneda = Moneda;
            Obj.Descripcion = Descripcion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_TipoDeContrato Datos = new Conexion_TipoDeContrato();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

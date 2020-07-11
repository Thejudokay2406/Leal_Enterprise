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
    public class fGestion_Empleados
    {
        public static DataTable Lista()
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int iddepartamento, int idtipodecontrato,

                //Datos Basicos
                string codigo, string empleado, string documento, string pais, string ciudad, string fijo, string movil,
                string email, string direccion, string comision, string descuento, string profesion, string cargo

            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            Obj.Idtipodecontrato = idtipodecontrato;
            Obj.Iddepartamento = iddepartamento;
            Obj.Codigo = codigo;
            Obj.Empleado = empleado;
            Obj.Documento = documento;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Fijo = fijo;
            Obj.Movil = movil;
            Obj.Email = email;
            Obj.Direccion = direccion;
            Obj.Comision = comision;
            Obj.Descuento = descuento;
            Obj.Profesion = profesion;
            Obj.Cargo = cargo;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idempleado, int iddepartamento, int idtipodecontrato,

                //Datos Basicos
                string codigo, string empleado, string documento, string pais, string ciudad, string fijo, string movil,
                string email, string direccion, string comision, string descuento, string profesion, string cargo

            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            Obj.Idempleado = idempleado;

            Obj.Idtipodecontrato = idtipodecontrato;
            Obj.Iddepartamento = iddepartamento;
            Obj.Codigo = codigo;
            Obj.Empleado = empleado;
            Obj.Documento = documento;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Fijo = fijo;
            Obj.Movil = movil;
            Obj.Email = email;
            Obj.Direccion = direccion;
            Obj.Comision = comision;
            Obj.Descuento = descuento;
            Obj.Profesion = profesion;
            Obj.Cargo = cargo;

            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

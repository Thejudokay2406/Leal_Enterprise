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
                int auto, int Iddepartamento, int Idcontrato, int Idsucurzal,

                //Datos Basicos
                string Codigo, string Empleado, string Documento, string Profesion, string Cargo, string Email, string PaisDom, string CiudadDom, string FijoDom, string ExtensionDom, string MovilDom, string DireccionDom, string PaisEmp, string CiudadEmp, string FijoEmp, string ExtensionEmp, string MovilEmp, string DireccionEmp
            )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            //Llaves Primarias Auxiliares
            Obj.Iddepartamento = Iddepartamento;
            Obj.Idcontrato = Idcontrato;
            Obj.Idsucurzal = Idsucurzal;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Empleado = Empleado;
            Obj.Documento = Documento;
            Obj.Profesion = Profesion;
            Obj.Cargo = Cargo;
            Obj.Email = Email;
            Obj.PaisDom = PaisDom;
            Obj.CiudadDom = CiudadDom;
            Obj.FijoDom = FijoDom;
            Obj.ExtensionDom = ExtensionDom;
            Obj.MovilDom = MovilDom;
            Obj.DireccionDom = DireccionDom;

            Obj.PaisEmp = PaisEmp;
            Obj.CiudadEmp = CiudadEmp;
            Obj.FijoEmp = FijoEmp;
            Obj.ExtensionEmp = ExtensionEmp;
            Obj.MovilEmp = MovilEmp;
            Obj.DireccionEmp = DireccionEmp;

            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
        (
            //Datos Auxiliares y Llaves Primaria
            int auto, int idempleado, int Iddepartamento, int Idcontrato, int Idsucurzal,

            //Datos Basicos
            string Codigo, string Empleado, string Documento, string Profesion, string Cargo, string Email, string PaisDom, string CiudadDom, string FijoDom, string ExtensionDom, string MovilDom, string DireccionDom, string PaisEmp, string CiudadEmp, string FijoEmp, string ExtensionEmp, string MovilEmp, string DireccionEmp
        )
        {
            Conexion_Empleados Datos = new Conexion_Empleados();
            Entidad_Empleados Obj = new Entidad_Empleados();

            Obj.Idempleado = idempleado;

            Obj.Iddepartamento = Iddepartamento;
            Obj.Idcontrato = Idcontrato;
            Obj.Idsucurzal = Idsucurzal;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Empleado = Empleado;
            Obj.Documento = Documento;
            Obj.Profesion = Profesion;
            Obj.Cargo = Cargo;
            Obj.Email = Email;
            Obj.PaisDom = PaisDom;
            Obj.CiudadDom = CiudadDom;
            Obj.FijoDom = FijoDom;
            Obj.ExtensionDom = ExtensionDom;
            Obj.MovilDom = MovilDom;
            Obj.DireccionDom = DireccionDom;
            Obj.PaisEmp = PaisEmp;
            Obj.CiudadEmp = CiudadEmp;
            Obj.FijoEmp = FijoEmp;
            Obj.ExtensionEmp = ExtensionEmp;
            Obj.MovilEmp = MovilEmp;
            Obj.DireccionEmp = DireccionEmp;

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

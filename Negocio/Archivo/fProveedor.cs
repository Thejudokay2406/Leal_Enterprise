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
    public class fProveedor

    {
        public static DataTable Lista()
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable BuscarExistencia_SQL(string Filtro)
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            return Datos.BuscarExistencia_SQL(Filtro);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto,

                string tipo, string nombre, string documento, string representante, string pais,
                string ciudad, string nacionalidad, string telefono, string movil, string correo,
                DateTime fechadeinicio,

                //Datos de Envio
                string pais_DE, string ciudad_DE, string direccion_P, string direccion01,
                string direccion02, string telefono_de, string movil_de, string receptor, string observacion,

                //Datos Financieros
                string retencion, string valorretencion, string bancoPrincipal, string bancoauxiliar, string cuenta01,
                string cuenta02, string creditoMin, string creditoMax, string prorroga, int estado
                                
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Tipo = tipo;
            Obj.Nombre = nombre;
            Obj.Documento = documento;
            Obj.Representante = representante;
            Obj.Telefono = telefono;
            Obj.Movil = movil;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Nacionalidad = nacionalidad;
            Obj.Fechadeinicio = fechadeinicio;

            //Datos de Envio
            Obj.Pais_DE = pais_DE;
            Obj.Ciudad_DE = ciudad_DE;
            Obj.Direccion_P = direccion_P;
            Obj.Direccion01 = direccion01;
            Obj.Direccion02 = direccion02;
            Obj.Telefono_DE = telefono_de;
            Obj.Movil__DE = movil_de;
            Obj.Receptor = receptor;
            Obj.Observacion = observacion;

            //Datos Financieros
            Obj.Retencion = retencion;
            Obj.ValorRetencion = valorretencion;
            Obj.BancoPrincipal = bancoPrincipal;
            Obj.BancoAuxiliar = bancoauxiliar;
            Obj.Cuenta01 = cuenta01;
            Obj.Cuenta02 = cuenta02;
            Obj.CreditoMin = creditoMin;
            Obj.CreditoMax = creditoMax;
            Obj.Prorroga = prorroga;

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Estado = estado;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idproveedor,

                string tipo, string nombre, string documento, string representante, string pais,
                string ciudad, string nacionalidad, string telefono, string movil, string correo,
                DateTime fechadeinicio,

                //Datos de Envio
                string pais_DE, string ciudad_DE, string direccion_P, string direccion01,
                string direccion02, string telefono_de, string movil_de, string receptor, string observacion,

                //Datos Financieros
                string retencion, string valorretencion, string bancoPrincipal, string bancoauxiliar, string cuenta01,
                string cuenta02, string creditoMin, string creditoMax, string prorroga, int estado
            )
        {
            Conexion_Proveedor Datos = new Conexion_Proveedor();
            Entidad_Proveedor Obj = new Entidad_Proveedor();

            //Datos Basicos
            Obj.Idproveedor = idproveedor;
            Obj.Tipo = tipo;
            Obj.Nombre = nombre;
            Obj.Documento = documento;
            Obj.Representante = representante;
            Obj.Telefono = telefono;
            Obj.Movil = movil;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Nacionalidad = nacionalidad;
            Obj.Fechadeinicio = fechadeinicio;

            //Datos de Envio
            Obj.Pais_DE = pais_DE;
            Obj.Ciudad_DE = ciudad_DE;
            Obj.Direccion_P = direccion_P;
            Obj.Direccion01 = direccion01;
            Obj.Direccion02 = direccion02;
            Obj.Telefono_DE = telefono_de;
            Obj.Movil__DE = movil_de;
            Obj.Receptor = receptor;
            Obj.Observacion = observacion;

            //Datos Financieros
            Obj.Retencion = retencion;
            Obj.ValorRetencion = valorretencion;
            Obj.BancoPrincipal = bancoPrincipal;
            Obj.BancoAuxiliar = bancoauxiliar;
            Obj.Cuenta01 = cuenta01;
            Obj.Cuenta02 = cuenta02;
            Obj.CreditoMin = creditoMin;
            Obj.CreditoMax = creditoMax;
            Obj.Prorroga = prorroga;

            //Datos Auxiliares
            Obj.Auto = auto;
            Obj.Estado = estado;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

    }
}

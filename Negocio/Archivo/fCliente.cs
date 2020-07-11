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
    public class fCliente
    {
        public static DataTable Lista()
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar(Filtro, auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int estado, int idtipo,

                //Datos Basicos
                string codigo, string nombre, string documento, string telefono, string movil,
                string correo, string pais, string ciudad, string departamento,

                //
                string pais_de, string ciudad_de, string receptor,
                string direccionprincipal_de, string direccion01_de, string direccion02_de,
                string telefono_de, string movil_de, string observacion_de,

                //
                string credito, string limitedecredito, string diasdecredito, string diasdeprorroga,
                string interesesmora, string creditominimo, string creditomaximo,
                int auto
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            Obj.Codigo = codigo;
            Obj.Idtipo = idtipo;
            Obj.Cliente = nombre;
            Obj.Documento = documento;
            Obj.Movil = movil;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Departamento = departamento;

            //
            Obj.Pais_Envios = pais_de;
            Obj.Ciudad_Envios = ciudad_de;
            Obj.Receptor_Envios = receptor;
            Obj.DireccionPrincipal_Envios = direccionprincipal_de;
            Obj.Direccion01_Envios = direccion01_de;
            Obj.Direccion02_Envios = direccion02_de;
            Obj.Telefono_Envios = telefono_de;
            Obj.Movil_Envios = movil_de;
            Obj.Observacion_Envios = observacion_de;

            //
            Obj.Credito = credito;
            Obj.LimiteDeCredito = limitedecredito;
            Obj.DiasDeCredito = diasdecredito;
            Obj.DiasDeProrroga = diasdeprorroga;
            Obj.InteresesPorMora = interesesmora;
            Obj.CreditoMinimo = creditominimo;
            Obj.CreditoMaximo = creditomaximo;
            
            Obj.Estado = estado;
            Obj.Auto = auto;
            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int estado, int idcliente, int idtipo,

                //Datos Basicos
                string codigo, string nombre, string documento, string telefono, string movil,
                string correo, string pais, string ciudad, string departamento,

                //
                string pais_de, string ciudad_de, string receptor,
                string direccionprincipal_de, string direccion01_de, string direccion02_de,
                string telefono_de, string movil_de, string observacion_de,

                //
                string credito, string limitedecredito, string diasdecredito, string diasdeprorroga,
                string interesesmora, string creditominimo, string creditomaximo,
                int auto
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            Obj.Idcliente = idcliente;
            Obj.Codigo = codigo;
            Obj.Idtipo = idtipo;
            Obj.Cliente = nombre;
            Obj.Documento = documento;
            Obj.Movil = movil;
            Obj.Telefono = telefono;
            Obj.Correo = correo;
            Obj.Pais = pais;
            Obj.Ciudad = ciudad;
            Obj.Departamento = departamento;

            //
            Obj.Pais_Envios = pais_de;
            Obj.Ciudad_Envios = ciudad_de;
            Obj.Receptor_Envios = receptor;
            Obj.DireccionPrincipal_Envios = direccionprincipal_de;
            Obj.Direccion01_Envios = direccion01_de;
            Obj.Direccion02_Envios = direccion02_de;
            Obj.Telefono_Envios = telefono_de;
            Obj.Movil_Envios = movil_de;
            Obj.Observacion_Envios = observacion_de;

            //
            Obj.Credito = credito;
            Obj.LimiteDeCredito = limitedecredito;
            Obj.DiasDeCredito = diasdecredito;
            Obj.DiasDeProrroga = diasdeprorroga;
            Obj.InteresesPorMora = interesesmora;
            Obj.CreditoMinimo = creditominimo;
            Obj.CreditoMaximo = creditomaximo;

            Obj.Estado = estado;
            Obj.Auto = auto;
            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

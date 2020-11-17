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

        public static DataTable Lista_Contacto(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Contacto(auto, idcliente);
        }

        public static DataTable Lista_Credito(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Credito(auto, idcliente);
        }

        public static DataTable Lista_Despacho(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Despacho(auto, idcliente);
        }

        public static DataTable Lista_Facturacion(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Facturacion(auto, idcliente);
        }

        public static DataTable Lista_Financiera(int auto, int idcliente)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Lista_Financiera(auto, idcliente);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable Buscar_Contacto(int Auto_Contacto, int Filtro)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar_Contacto(Auto_Contacto, Filtro);
        }
        public static DataTable Buscar_Credito(int Auto_Credito, int Filtro)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar_Credito(Auto_Credito, Filtro);
        }
        public static DataTable Buscar_Despacho(int Auto_Despacho, int Filtro)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar_Despacho(Auto_Despacho, Filtro);
        }
        public static DataTable Buscar_Facturacion(int Auto_Facturacion, int Filtro)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar_Facturacion(Auto_Facturacion, Filtro);
        }
        public static DataTable Buscar_Financiera(int Auto_Financiera, int Filtro)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Buscar_Financiera(Auto_Financiera, Filtro);
        }

        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idtipo, int idgrupo,

                //Datos Basicos
                string codigo, string cliente, Int64 documento, Int64 telefonoprin, Int64 movilprin, Int64 telefonoaux, Int64 movilaux,
                string correo, string pais, string ciudad, string departamento, string paginaweb, string direccion, string observacion,

                //Panel Facturacion
                DataTable detalle_facturacion,

                //Panel Credito
                DataTable detalle_credito,

                //Panel Despacho
                DataTable detalle_despacho,

                //Panel Financiera
                DataTable detalle_financiera,

                //Panel Datos de Contacto
                DataTable detalle_contacto,

                //Datos Auxiliares
                int facturacion_autosql, int credito_autosql, int despacho_autosql, int financiera_autosql, int contacto_autosql,

                //SI VALIDA SI SE REALIZA O NO LA VALIDACION
                int tran_faturacion, int tran_credito, int tran_despacho, int tran_financiera, int tran_contacto,

                //VARIABLES PARA LA VALIDACION DE LOS CHEBOXT DEL PANEL DATOS BASICOS
                int efectivo, int debito, int credito, int contado
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idtipo = idtipo;
            Obj.Idgrupo = idgrupo;

            //Datos Basicos
            Obj.Dat_Codigo = codigo;
            Obj.Dat_Cliente = cliente;
            Obj.Dat_Documento = documento;
            Obj.Dat_Telefono = telefonoprin;
            Obj.Dat_Movil = movilprin;
            Obj.Dat_TelefonoAux = telefonoaux;
            Obj.Dat_MovilAux = movilaux;
            Obj.Dat_Correo = correo;
            Obj.Dat_Pais = pais;
            Obj.Dat_Ciudad = ciudad;
            Obj.Dat_Departamento = departamento;
            Obj.Dat_PaginaWeb = paginaweb;
            Obj.Dat_Direccion = direccion;
            Obj.Dat_Observacion = observacion;

            //Panel Facturacion
            Obj.Det_Facturacion = detalle_facturacion;

            //Panel Credito
            Obj.Det_Credito = detalle_credito;

            //Panel Despacho
            Obj.Det_Despacho = detalle_despacho;

            //Panel Financiera
            Obj.Det_Financiera = detalle_financiera;

            //Panel Datos de Contacto
            Obj.Det_Contacto = detalle_contacto;

            //Datos Auxiliares
            Obj.Facturacion_AutoSQL = facturacion_autosql;
            Obj.Credito_AutoSQL = credito_autosql;
            Obj.Despacho_AutoSQL = despacho_autosql;
            Obj.Financiera_AutoSQL = financiera_autosql;
            Obj.Contacto_AutoSQL = contacto_autosql;

            //SI VALIDA SI SE REALIZA O NO LA VALIDACION
            Obj.Tran_Facturacion = tran_faturacion;
            Obj.Tran_Credito = tran_credito;
            Obj.Tran_Despacho = tran_despacho;
            Obj.Tran_Financiera = tran_financiera;
            Obj.Tran_Contacto = tran_contacto;

            //VARIABLES PARA LA VALIDACION DE LOS CHEBOXT DEL PANEL DATOS BASICOS
            Obj.Dat_Efectivo = efectivo;
            Obj.Dat_Debito = debito;
            Obj.Dat_Credito = credito;
            Obj.Dat_Contado = contado;

            //Variables
            Obj.Auto = auto;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Guardar_Facturacion
            (
                //Ubicacion[]
                int idcliente, int idempleado, string Empleado, string Cod_Empleado, string Cliente, Int64 Doc_Cliente, Int64 Movil, string Pais, string Ciudad, string Departamento, string Correo,

                //Datos Auxiliares
                int autodet_facturacion
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Facturacion
            Obj.Idcliente = idcliente;
            Obj.Idempleado = idempleado;
            Obj.Fac_Asesor = Empleado;
            Obj.Fac_AsesorCodigo = Cod_Empleado;
            Obj.Fac_Cliente = Cliente;
            Obj.Fac_ClienteDoc = Doc_Cliente;
            Obj.Fac_Movil = Movil;
            Obj.Fac_Pais = Pais;
            Obj.Fac_Ciudad = Ciudad;
            Obj.Fac_Departamento = Departamento;
            Obj.Fac_Correo = Correo;

            //Datos Auxiliares
            Obj.AutoDet_Facturacion = autodet_facturacion;

            return Datos.Guardar_Facturacion(Obj);
        }

        public static string Guardar_Credito
            (
                //Ubicacion[]
                int Idcliente, decimal Valor, Int64 CuoMeses, Int64 TasaMensu, Int64 TasaAnual, DateTime Solicitud, DateTime Emision, Int64 Prorroga, Int64 Mora,

                //Datos Auxiliares
                int autodet_credito
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Ubicacion[]
            Obj.Idcliente = Idcliente;
            Obj.Cre_Valor = Valor;
            Obj.Cre_Cuotas = CuoMeses;
            Obj.Cre_TasaMensual = TasaMensu;
            Obj.Cre_TasaAnual = TasaAnual;
            Obj.Cre_Solicitud = Solicitud;
            Obj.Cre_Emision = Emision;
            Obj.Cre_Prorroga = Prorroga;
            Obj.Cre_TasaMora = Mora;

            //Datos Auxiliares
            Obj.AutoDet_Credito = autodet_credito;

            return Datos.Guardar_Credito(Obj);
        }

        public static string Guardar_Despacho
            (
                //Despacho[]
                int Idcliente, string Sucurzal, string Pais, string Ciudad, string Departamento, string Receptor, string Barrio, string Apartamento, Int64 Movil, string Direccion, string Observacion,

                //Datos Auxiliares
                int autodet_despacho
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Despacho[]
            Obj.Idcliente = Idcliente;
            Obj.Des_Sucurzal = Sucurzal;
            Obj.Des_Pais = Pais;
            Obj.Des_Ciudad = Ciudad;
            Obj.Des_Departamento = Departamento;
            Obj.Des_Receptor = Receptor;
            Obj.Des_Barrio = Barrio;
            Obj.Des_Apartamento = Apartamento;
            Obj.Des_Movil = Movil;
            Obj.Des_Direccion = Direccion;
            Obj.Des_Observacion = Observacion;

            //Datos Auxiliares
            Obj.AutoDet_Despacho = autodet_despacho;

            return Datos.Guardar_Despacho(Obj);
        }

        public static string Guardar_Financiera
            (
                //Ubicacion[]
                int idcliente, int Idbanco, string Cuenta, Int64 Numerodecuenta,

                //Datos Auxiliares
                int autodet_financiera
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Financiera[]
            Obj.Idcliente = idcliente;
            Obj.Idbanco = Idbanco;
            Obj.Fin_Cuenta = Cuenta;
            Obj.Fin_CuentaNumero = Numerodecuenta;

            //Datos Auxiliares
            Obj.AutoDet_Financiera = autodet_financiera;

            return Datos.Guardar_Financiera(Obj);
        }

        public static string Guardar_Contacto
            (
                //Ubicacion[]
                int Idcliente, string Contacto, string Ciudad, string Direccion, Int64 Telefono, Int64 Movil, string Correo, string Parentesco,

                //Datos Auxiliares
                int autodet_contacto
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Contacto[]
            Obj.Idcliente = Idcliente;
            Obj.Cont_Contacto = Contacto;
            Obj.Cont_Ciudad = Ciudad;
            Obj.Cont_Direccion = Direccion;
            Obj.Cont_Telefono = Telefono;
            Obj.Cont_Movil = Movil;
            Obj.Cont_Correo = Correo;
            Obj.Cont_Parentesco = Parentesco;

            //Datos Auxiliares
            Obj.AutoDet_Contacto = autodet_contacto;

            return Datos.Guardar_Contacto(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Datos Auxiliares y Llaves Primaria
                int auto, int idcliente, int idtipo, int idgrupo,

                //Datos Basicos
                string codigo, string cliente, Int64 documento, Int64 telefonoprin, Int64 movilprin, Int64 telefonoaux, Int64 movilaux,
                string correo, string pais, string ciudad, string departamento, string paginaweb, string direccion, string observacion
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idcliente = idcliente;
            Obj.Idcliente = idcliente;
            Obj.Idtipo = idtipo;
            Obj.Idgrupo = idgrupo;

            //Datos Basicos
            Obj.Dat_Codigo = codigo;
            Obj.Dat_Cliente = cliente;
            Obj.Dat_Documento = documento;
            Obj.Dat_Telefono = telefonoprin;
            Obj.Dat_Movil = movilprin;
            Obj.Dat_TelefonoAux = telefonoaux;
            Obj.Dat_MovilAux = movilaux;
            Obj.Dat_Correo = correo;
            Obj.Dat_Pais = pais;
            Obj.Dat_Ciudad = ciudad;
            Obj.Dat_Departamento = departamento;
            Obj.Dat_PaginaWeb = paginaweb;
            Obj.Dat_Direccion = direccion;
            Obj.Dat_Observacion = observacion;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Editar_Facturacion
            (
                //Facturacion[]
                int idfacturacion, int idcliente, int idempleado, string Empleado, string Cod_Empleado, string Cliente, Int64 Doc_Cliente, Int64 Movil, string Pais, string Ciudad, string Departamento, string Correo,

                //Datos Auxiliares
                int autodet_facturacion
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Facturacion
            Obj.Idfacturacion = idfacturacion;
            Obj.Idcliente = idcliente;
            Obj.Idempleado = idempleado;
            Obj.Fac_Asesor = Empleado;
            Obj.Fac_AsesorCodigo = Cod_Empleado;
            Obj.Fac_Cliente = Cliente;
            Obj.Fac_ClienteDoc = Doc_Cliente;
            Obj.Fac_Movil = Movil;
            Obj.Fac_Pais = Pais;
            Obj.Fac_Ciudad = Ciudad;
            Obj.Fac_Departamento = Departamento;
            Obj.Fac_Correo = Correo;

            //Datos Auxiliares
            Obj.AutoDet_Facturacion = autodet_facturacion;

            return Datos.Editar_Facturacion(Obj);
        }

        public static string Editar_Credito
            (
                //Credito[]
                int idcredito, int Idcliente, decimal Valor, Int64 CuoMeses, Int64 TasaMensu, Int64 TasaAnual, DateTime Solicitud, DateTime Emision, Int64 Prorroga, Int64 Mora,

                //Datos Auxiliares
                int autodet_credito
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Ubicacion[]
            Obj.Idcredito = idcredito;
            Obj.Idcliente = Idcliente;
            Obj.Cre_Valor = Valor;
            Obj.Cre_Cuotas = CuoMeses;
            Obj.Cre_TasaMensual = TasaMensu;
            Obj.Cre_TasaAnual = TasaAnual;
            Obj.Cre_Solicitud = Solicitud;
            Obj.Cre_Emision = Emision;
            Obj.Cre_Prorroga = Prorroga;
            Obj.Cre_TasaMora = Mora;

            //Datos Auxiliares
            Obj.AutoDet_Credito = autodet_credito;

            return Datos.Editar_Credito(Obj);
        }

        public static string Editar_Despacho
            (
                //Despacho[]
                int iddespacho, int Idcliente, string Sucurzal, string Pais, string Ciudad, string Departamento, string Receptor, string Barrio, string Apartamento, Int64 Movil, string Direccion, string Observacion,

                //Datos Auxiliares
                int autodet_despacho
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Despacho[]
            Obj.Iddespacho = iddespacho;
            Obj.Idcliente = Idcliente;
            Obj.Des_Sucurzal = Sucurzal;
            Obj.Des_Pais = Pais;
            Obj.Des_Ciudad = Ciudad;
            Obj.Des_Departamento = Departamento;
            Obj.Des_Receptor = Receptor;
            Obj.Des_Barrio = Barrio;
            Obj.Des_Apartamento = Apartamento;
            Obj.Des_Movil = Movil;
            Obj.Des_Direccion = Direccion;
            Obj.Des_Observacion = Observacion;

            //Datos Auxiliares
            Obj.AutoDet_Despacho = autodet_despacho;

            return Datos.Editar_Despacho(Obj);
        }

        public static string Editar_Financiera
            (
                //Financiera[]
                int idfinanciera, int idcliente, int Idbanco, string Cuenta, Int64 Numerodecuenta,

                //Datos Auxiliares
                int autodet_financiera
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Financiera[]
            Obj.Idfinanciera = idfinanciera;
            Obj.Idcliente = idcliente;
            Obj.Idbanco = Idbanco;
            Obj.Fin_Cuenta = Cuenta;
            Obj.Fin_CuentaNumero = Numerodecuenta;

            //Datos Auxiliares
            Obj.AutoDet_Financiera = autodet_financiera;

            return Datos.Editar_Financiera(Obj);
        }

        public static string Editar_Contacto
            (
                //Contacto[]
                int idcontacto, int Idcliente, string Contacto, string Ciudad, string Direccion, Int64 Telefono, Int64 Movil, string Correo, string Parentesco,

                //Datos Auxiliares
                int autodet_contacto
            )
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            Entidad_Cliente Obj = new Entidad_Cliente();

            //Contacto[]
            Obj.Idcontacto = idcontacto;
            Obj.Idcliente = Idcliente;
            Obj.Cont_Contacto = Contacto;
            Obj.Cont_Ciudad = Ciudad;
            Obj.Cont_Direccion = Direccion;
            Obj.Cont_Telefono = Telefono;
            Obj.Cont_Movil = Movil;
            Obj.Cont_Correo = Correo;
            Obj.Cont_Parentesco = Parentesco;

            //Datos Auxiliares
            Obj.AutoDet_Contacto = autodet_contacto;

            return Datos.Editar_Contacto(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }

        public static string Eliminar_Contacto(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Contacto(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Credito(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Credito(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Despacho(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Despacho(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Facturacion(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Facturacion(Idcliente, Iddetalle, Auto);
        }

        public static string Eliminar_Financiera(int Idcliente, int Iddetalle, int Auto)
        {
            Conexion_Cliente Datos = new Conexion_Cliente();
            return Datos.Eliminar_Financiera(Idcliente, Iddetalle, Auto);
        }


    }
}

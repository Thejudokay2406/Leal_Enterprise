using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Cliente
    {
        //Llave primaria y Auxiliares
        private int _Idcliente;
        private int _Idtipo;
        private int _Idgrupo;
        private int _Idempleado;
        private int _Idbanco;

        private int _Idfacturacion;
        private int _Iddespacho;
        private int _Idfinanciera;
        private int _Idcontacto;

        //Datos Basicos
        private string _Dat_Cliente;
        private Int64 _Dat_Documento;
        private Int64 _Dat_Telefono01;
        private Int64 _Dat_Telefono02;
        private Int64 _Dat_Movil;
        private Int64 _Dat_Movil02;
        private string _Dat_Correo;
        private string _Dat_Pais;
        private string _Dat_Ciudad;
        private string _Dat_Departamento;
        private string _Dat_PaginaWeb;
        private string _Dat_Direccion;
        private string _Dat_Observacion;
        private int _Dat_Contado;
        private int _Dat_Debito;
        private int _Dat_Credito;
        private int _Dat_Efectivo;

        //Datos de Facturacion
        private string _Fac_Asesor;
        private string _Fac_AsesorCodigo;
        private string _Fac_Cliente;
        private Int64 _Fac_ClienteDoc;
        private Int64 _Fac_Movil;
        private string _Fac_Ciudad;
        private string _Fac_Correo;

        //Datos de Envios
        private string _Des_Receptor;
        private string _Des_Ciudad;
        private Int64 _Des_Movil;
        private string _Des_Direccion;
        private string _Des_Observacion;
                
        //Datos de Financiera
        private string _Fin_Banco;
        private string _Fin_BancoCodigo;
        private string _Fin_Cuenta;
        private Int64 _Fin_CuentaNumero;

        //Datos de Contacto
        private string _Cont_Contacto;
        private string _Cont_Ciudad;
        private string _Cont_Direccion;
        private Int64 _Cont_Movil;
        private string _Cont_Correo;
        private string _Cont_Parentesco;
        
        //Datos Auxiliares para Registrar y Editar los Detalles
        private int _AutoDet_Facturacion;
        private int _AutoDet_Despacho;
        private int _AutoDet_Financiera;
        private int _AutoDet_Contacto;

        //Datos Para Filtrar los Multiples registro del Cliente Como Facturacion, Despachos ETC
        private int _Filtro_Facturacion;
        private int _Filtro_Despacho;
        private int _Filtro_Financiera;
        private int _Filtro_Contacto;

        private DataTable _Det_Facturacion;
        private DataTable _Det_Despacho;
        private DataTable _Det_Financiera;
        private DataTable _Det_Contacto;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Facturacion_AutoSQL;
        private int _Despacho_AutoSQL;
        private int _Financiera_AutoSQL;
        private int _Contacto_AutoSQL;

        //
        private int _Tran_Facturacion;
        private int _Tran_Despacho;
        private int _Tran_Financiera;
        private int _Tran_Contacto;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtipo { get => _Idtipo; set => _Idtipo = value; }
        public int Idgrupo { get => _Idgrupo; set => _Idgrupo = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idbanco { get => _Idbanco; set => _Idbanco = value; }
        public int Idfacturacion { get => _Idfacturacion; set => _Idfacturacion = value; }
        public int Iddespacho { get => _Iddespacho; set => _Iddespacho = value; }
        public int Idfinanciera { get => _Idfinanciera; set => _Idfinanciera = value; }
        public int Idcontacto { get => _Idcontacto; set => _Idcontacto = value; }
        public string Dat_Cliente { get => _Dat_Cliente; set => _Dat_Cliente = value; }
        public long Dat_Documento { get => _Dat_Documento; set => _Dat_Documento = value; }
        public long Dat_Telefono01 { get => _Dat_Telefono01; set => _Dat_Telefono01 = value; }
        public long Dat_Telefono02 { get => _Dat_Telefono02; set => _Dat_Telefono02 = value; }
        public long Dat_Movil { get => _Dat_Movil; set => _Dat_Movil = value; }
        public long Dat_Movil02 { get => _Dat_Movil02; set => _Dat_Movil02 = value; }
        public string Dat_Correo { get => _Dat_Correo; set => _Dat_Correo = value; }
        public string Dat_Pais { get => _Dat_Pais; set => _Dat_Pais = value; }
        public string Dat_Ciudad { get => _Dat_Ciudad; set => _Dat_Ciudad = value; }
        public string Dat_Departamento { get => _Dat_Departamento; set => _Dat_Departamento = value; }
        public string Dat_PaginaWeb { get => _Dat_PaginaWeb; set => _Dat_PaginaWeb = value; }
        public string Dat_Direccion { get => _Dat_Direccion; set => _Dat_Direccion = value; }
        public string Dat_Observacion { get => _Dat_Observacion; set => _Dat_Observacion = value; }
        public int Dat_Contado { get => _Dat_Contado; set => _Dat_Contado = value; }
        public int Dat_Debito { get => _Dat_Debito; set => _Dat_Debito = value; }
        public int Dat_Efectivo { get => _Dat_Efectivo; set => _Dat_Efectivo = value; }
        public string Fac_Asesor { get => _Fac_Asesor; set => _Fac_Asesor = value; }
        public string Fac_AsesorCodigo { get => _Fac_AsesorCodigo; set => _Fac_AsesorCodigo = value; }
        public string Fac_Cliente { get => _Fac_Cliente; set => _Fac_Cliente = value; }
        public long Fac_ClienteDoc { get => _Fac_ClienteDoc; set => _Fac_ClienteDoc = value; }
        public long Fac_Movil { get => _Fac_Movil; set => _Fac_Movil = value; }
        public string Fac_Ciudad { get => _Fac_Ciudad; set => _Fac_Ciudad = value; }
        public string Fac_Correo { get => _Fac_Correo; set => _Fac_Correo = value; }
        public string Des_Receptor { get => _Des_Receptor; set => _Des_Receptor = value; }
        public string Des_Ciudad { get => _Des_Ciudad; set => _Des_Ciudad = value; }
        public long Des_Movil { get => _Des_Movil; set => _Des_Movil = value; }
        public string Des_Direccion { get => _Des_Direccion; set => _Des_Direccion = value; }
        public string Des_Observacion { get => _Des_Observacion; set => _Des_Observacion = value; }
        public string Fin_Banco { get => _Fin_Banco; set => _Fin_Banco = value; }
        public string Fin_BancoCodigo { get => _Fin_BancoCodigo; set => _Fin_BancoCodigo = value; }
        public string Fin_Cuenta { get => _Fin_Cuenta; set => _Fin_Cuenta = value; }
        public long Fin_CuentaNumero { get => _Fin_CuentaNumero; set => _Fin_CuentaNumero = value; }
        public string Cont_Contacto { get => _Cont_Contacto; set => _Cont_Contacto = value; }
        public string Cont_Ciudad { get => _Cont_Ciudad; set => _Cont_Ciudad = value; }
        public string Cont_Direccion { get => _Cont_Direccion; set => _Cont_Direccion = value; }
        public long Cont_Movil { get => _Cont_Movil; set => _Cont_Movil = value; }
        public string Cont_Correo { get => _Cont_Correo; set => _Cont_Correo = value; }
        public string Cont_Parentesco { get => _Cont_Parentesco; set => _Cont_Parentesco = value; }
        public int Filtro_Facturacion { get => _Filtro_Facturacion; set => _Filtro_Facturacion = value; }
        public int Filtro_Despacho { get => _Filtro_Despacho; set => _Filtro_Despacho = value; }
        public int Filtro_Financiera { get => _Filtro_Financiera; set => _Filtro_Financiera = value; }
        public int Filtro_Contacto { get => _Filtro_Contacto; set => _Filtro_Contacto = value; }
        public DataTable Det_Facturacion { get => _Det_Facturacion; set => _Det_Facturacion = value; }
        public DataTable Det_Despacho { get => _Det_Despacho; set => _Det_Despacho = value; }
        public DataTable Det_Financiera { get => _Det_Financiera; set => _Det_Financiera = value; }
        public DataTable Det_Contacto { get => _Det_Contacto; set => _Det_Contacto = value; }
        public int Facturacion_AutoSQL { get => _Facturacion_AutoSQL; set => _Facturacion_AutoSQL = value; }
        public int Despacho_AutoSQL { get => _Despacho_AutoSQL; set => _Despacho_AutoSQL = value; }
        public int Financiera_AutoSQL { get => _Financiera_AutoSQL; set => _Financiera_AutoSQL = value; }
        public int Contacto_AutoSQL { get => _Contacto_AutoSQL; set => _Contacto_AutoSQL = value; }
        public int Tran_Facturacion { get => _Tran_Facturacion; set => _Tran_Facturacion = value; }
        public int Tran_Despacho { get => _Tran_Despacho; set => _Tran_Despacho = value; }
        public int Tran_Financiera { get => _Tran_Financiera; set => _Tran_Financiera = value; }
        public int Tran_Contacto { get => _Tran_Contacto; set => _Tran_Contacto = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Dat_Credito { get => _Dat_Credito; set => _Dat_Credito = value; }
        public int AutoDet_Facturacion { get => _AutoDet_Facturacion; set => _AutoDet_Facturacion = value; }
        public int AutoDet_Despacho { get => _AutoDet_Despacho; set => _AutoDet_Despacho = value; }
        public int AutoDet_Financiera { get => _AutoDet_Financiera; set => _AutoDet_Financiera = value; }
        public int AutoDet_Contacto { get => _AutoDet_Contacto; set => _AutoDet_Contacto = value; }
    }
}

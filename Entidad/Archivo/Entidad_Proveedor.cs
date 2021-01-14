using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Entidad
{
    public class Entidad_Proveedor
    {
        //Llave primaria
        private int _Idbanco;
        private int _Idproveedor;
        private int _Idsucurzal;

        //Datos Basicos
        private string _Tipo;
        private string _Nombre;
        private string _Documento;
        private string _Representante;
        private string _Pais;
        private string _Ciudad;
        private string _Nacionalidad;
        private string _Telefono;
        private string _Movil;
        private string _Correo;
        private DateTime _Fechadeinicio;

        //Datos de Envio
        private DataTable _Detalle_Envio;
        private string _Env_Receptor;
        private string _Env_Pais;
        private string _Env_Ciudad;
        private string _Env_Direccion;
        private string _Env_Telefono;
        private string _Env_Movil;
        private string _Env_Observacion;

        //Datos Bancarios
        private DataTable _Detalle_Banco;
        private string _Banco;
        private string _Banco_Documento;
        private string _Cuenta;
        private Int64 _Numerodecuenta;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Envio_AutoSQL;
        private int _Banco_AutoSQL;

        //
        private int _Tran_Envio;
        private int _Tran_Banco;

        //Datos Para Filtrar los Multiples registro del Producto Como Ubicacion, Lotes ETC
        private int _Auto_Banco;
        private int _Auto_Envio;
        private int _Consulta_Banco;
        private int _Consulta_Envio;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Representante { get => _Representante; set => _Representante = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Nacionalidad { get => _Nacionalidad; set => _Nacionalidad = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public DateTime Fechadeinicio { get => _Fechadeinicio; set => _Fechadeinicio = value; }
        public DataTable Detalle_Envio { get => _Detalle_Envio; set => _Detalle_Envio = value; }
        public DataTable Detalle_Banco { get => _Detalle_Banco; set => _Detalle_Banco = value; }
        public int Envio_AutoSQL { get => _Envio_AutoSQL; set => _Envio_AutoSQL = value; }
        public int Banco_AutoSQL { get => _Banco_AutoSQL; set => _Banco_AutoSQL = value; }
        public int Tran_Envio { get => _Tran_Envio; set => _Tran_Envio = value; }
        public int Tran_Banco { get => _Tran_Banco; set => _Tran_Banco = value; }
        public int Auto_Banco { get => _Auto_Banco; set => _Auto_Banco = value; }
        public int Auto_Envio { get => _Auto_Envio; set => _Auto_Envio = value; }
        public int Consulta_Banco { get => _Consulta_Banco; set => _Consulta_Banco = value; }
        public int Consulta_Envio { get => _Consulta_Envio; set => _Consulta_Envio = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Idbanco { get => _Idbanco; set => _Idbanco = value; }
        public string Env_Receptor { get => _Env_Receptor; set => _Env_Receptor = value; }
        public string Env_Pais { get => _Env_Pais; set => _Env_Pais = value; }
        public string Env_Ciudad { get => _Env_Ciudad; set => _Env_Ciudad = value; }
        public string Env_Direccion { get => _Env_Direccion; set => _Env_Direccion = value; }
        public string Env_Telefono { get => _Env_Telefono; set => _Env_Telefono = value; }
        public string Env_Movil { get => _Env_Movil; set => _Env_Movil = value; }
        public string Env_Observacion { get => _Env_Observacion; set => _Env_Observacion = value; }
        public string Cuenta { get => _Cuenta; set => _Cuenta = value; }
        public long Numerodecuenta { get => _Numerodecuenta; set => _Numerodecuenta = value; }
        public int Idsucurzal { get => _Idsucurzal; set => _Idsucurzal = value; }
        public string Banco { get => _Banco; set => _Banco = value; }
        public string Banco_Documento { get => _Banco_Documento; set => _Banco_Documento = value; }
    }
}

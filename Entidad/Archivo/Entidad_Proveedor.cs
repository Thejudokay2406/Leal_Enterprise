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
        private int _Idproveedor;

        //Datos Basicos
        private int _Estado;
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
        private string _Pais_DE;
        private string _Ciudad_DE;
        private string _Direccion_P;
        private string _Direccion01;
        private string _Direccion02;
        private string _Telefono_DE;
        private string _Movil__DE;
        private string _Receptor;
        private string _Observacion;

        //Datos Financieros
        private string _Retencion;
        private string _ValorRetencion;
        private string _BancoPrincipal;
        private string _BancoAuxiliar;
        private string _Cuenta01;
        private string _Cuenta02;
        private string _CreditoMin;
        private string _CreditoMax;
        private string _Prorroga;

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
        public string Pais_DE { get => _Pais_DE; set => _Pais_DE = value; }
        public string Ciudad_DE { get => _Ciudad_DE; set => _Ciudad_DE = value; }
        public string Direccion_P { get => _Direccion_P; set => _Direccion_P = value; }
        public string Direccion01 { get => _Direccion01; set => _Direccion01 = value; }
        public string Direccion02 { get => _Direccion02; set => _Direccion02 = value; }
        public string Receptor { get => _Receptor; set => _Receptor = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public string Retencion { get => _Retencion; set => _Retencion = value; }
        public string ValorRetencion { get => _ValorRetencion; set => _ValorRetencion = value; }
        public string BancoPrincipal { get => _BancoPrincipal; set => _BancoPrincipal = value; }
        public string BancoAuxiliar { get => _BancoAuxiliar; set => _BancoAuxiliar = value; }
        public string Cuenta01 { get => _Cuenta01; set => _Cuenta01 = value; }
        public string Cuenta02 { get => _Cuenta02; set => _Cuenta02 = value; }
        public string CreditoMin { get => _CreditoMin; set => _CreditoMin = value; }
        public string CreditoMax { get => _CreditoMax; set => _CreditoMax = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Telefono_DE { get => _Telefono_DE; set => _Telefono_DE = value; }
        public string Movil__DE { get => _Movil__DE; set => _Movil__DE = value; }
        public string Prorroga { get => _Prorroga; set => _Prorroga = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Cliente
    {
        //Llave primaria y Auxiliares
        private int _Idcliente;
        private int _Idtipo;

        //Datos Basicos
        private string _Codigo;
        private string _Cliente;
        private string _Documento;
        private string _Telefono;
        private string _Movil;
        private string _Correo;
        private string _Pais;
        private string _Ciudad;
        private string _Departamento;
        private int _Estado;

        //Envios
        private string _Pais_Envios;
        private string _Ciudad_Envios;
        private string _DireccionPrincipal_Envios;
        private string _Direccion01_Envios;
        private string _Direccion02_Envios;
        private string _Receptor_Envios;
        private string _Telefono_Envios;
        private string _Movil_Envios;
        private string _Observacion_Envios;

        //Financiera
        private string _Credito;
        private string _LimiteDeCredito;
        private string _DiasDeCredito;
        private string _DiasDeProrroga;
        private string _InteresesPorMora;
        private string _CreditoMinimo;
        private string _CreditoMaximo;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtipo { get => _Idtipo; set => _Idtipo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Cliente { get => _Cliente; set => _Cliente = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Departamento { get => _Departamento; set => _Departamento = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Pais_Envios { get => _Pais_Envios; set => _Pais_Envios = value; }
        public string Ciudad_Envios { get => _Ciudad_Envios; set => _Ciudad_Envios = value; }
        public string DireccionPrincipal_Envios { get => _DireccionPrincipal_Envios; set => _DireccionPrincipal_Envios = value; }
        public string Direccion01_Envios { get => _Direccion01_Envios; set => _Direccion01_Envios = value; }
        public string Direccion02_Envios { get => _Direccion02_Envios; set => _Direccion02_Envios = value; }
        public string Receptor_Envios { get => _Receptor_Envios; set => _Receptor_Envios = value; }
        public string Telefono_Envios { get => _Telefono_Envios; set => _Telefono_Envios = value; }
        public string Movil_Envios { get => _Movil_Envios; set => _Movil_Envios = value; }
        public string Observacion_Envios { get => _Observacion_Envios; set => _Observacion_Envios = value; }
        public string Credito { get => _Credito; set => _Credito = value; }
        public string LimiteDeCredito { get => _LimiteDeCredito; set => _LimiteDeCredito = value; }
        public string DiasDeCredito { get => _DiasDeCredito; set => _DiasDeCredito = value; }
        public string DiasDeProrroga { get => _DiasDeProrroga; set => _DiasDeProrroga = value; }
        public string InteresesPorMora { get => _InteresesPorMora; set => _InteresesPorMora = value; }
        public string CreditoMinimo { get => _CreditoMinimo; set => _CreditoMinimo = value; }
        public string CreditoMaximo { get => _CreditoMaximo; set => _CreditoMaximo = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

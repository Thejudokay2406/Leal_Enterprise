using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Empleados
    {
        //Llaves primarias       
        private int _Idempleado;

        //Llaves Primarias Auxiliares
        private int _Iddepartamento;
        private int _Idtipodecontrato;

        //Datos Basicos
        private string _Codigo;
        private string _Empleado;
        private string _Documento;
        private string _Pais;
        private string _Ciudad;
        private string _Fijo;
        private string _Movil;
        private string _Email;
        private string _Direccion;
        private string _Comision;
        private string _Descuento;
        private string _Profesion;
        private string _Cargo;
                
        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Iddepartamento { get => _Iddepartamento; set => _Iddepartamento = value; }
        public int Idtipodecontrato { get => _Idtipodecontrato; set => _Idtipodecontrato = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Empleado { get => _Empleado; set => _Empleado = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Fijo { get => _Fijo; set => _Fijo = value; }
        public string Movil { get => _Movil; set => _Movil = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Comision { get => _Comision; set => _Comision = value; }
        public string Descuento { get => _Descuento; set => _Descuento = value; }
        public string Profesion { get => _Profesion; set => _Profesion = value; }
        public string Cargo { get => _Cargo; set => _Cargo = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

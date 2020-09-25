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
        private int _Idcontrato;
        private int _Idsucurzal;

        //Datos Basicos
        private string _Codigo;
        private string _Empleado;
        private string _Documento;
        private string _Profesion;
        private string _Cargo;
        private string _Email;
        private string _PaisDom;
        private string _CiudadDom;
        private string _FijoDom;
        private string _ExtensionDom;
        private string _MovilDom;
        private string _DireccionDom;

        private string _PaisEmp;
        private string _CiudadEmp;
        private string _FijoEmp;
        private string _ExtensionEmp;
        private string _MovilEmp;
        private string _DireccionEmp;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Iddepartamento { get => _Iddepartamento; set => _Iddepartamento = value; }
        public int Idcontrato { get => _Idcontrato; set => _Idcontrato = value; }
        public int Idsucurzal { get => _Idsucurzal; set => _Idsucurzal = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Empleado { get => _Empleado; set => _Empleado = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Profesion { get => _Profesion; set => _Profesion = value; }
        public string Cargo { get => _Cargo; set => _Cargo = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string PaisDom { get => _PaisDom; set => _PaisDom = value; }
        public string CiudadDom { get => _CiudadDom; set => _CiudadDom = value; }
        public string FijoDom { get => _FijoDom; set => _FijoDom = value; }
        public string ExtensionDom { get => _ExtensionDom; set => _ExtensionDom = value; }
        public string MovilDom { get => _MovilDom; set => _MovilDom = value; }
        public string DireccionDom { get => _DireccionDom; set => _DireccionDom = value; }
        public string PaisEmp { get => _PaisEmp; set => _PaisEmp = value; }
        public string CiudadEmp { get => _CiudadEmp; set => _CiudadEmp = value; }
        public string FijoEmp { get => _FijoEmp; set => _FijoEmp = value; }
        public string ExtensionEmp { get => _ExtensionEmp; set => _ExtensionEmp = value; }
        public string MovilEmp { get => _MovilEmp; set => _MovilEmp = value; }
        public string DireccionEmp { get => _DireccionEmp; set => _DireccionEmp = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Sucurzal
    {
        //Llaves primarias y Datos Auxiliares
        private int _Idsucurzal;
        private int _Auto;

        //Datos Basicos
        private string _Codigo;
        private string _Sucurzal;
        private string _Nit;
        private string _Descripcion;
        private string _Gerente;
        private string _Pais;
        private string _Ciudad;
        private string _Direccion;
        private int _Estado;

        public int Idsucurzal { get => _Idsucurzal; set => _Idsucurzal = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Sucurzal { get => _Sucurzal; set => _Sucurzal = value; }
        public string Nit { get => _Nit; set => _Nit = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Gerente { get => _Gerente; set => _Gerente = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Bodega
    {
        //Llave primaria
        private int _Idbodega;

        //Llaves Auxiliares
        private int _Idsucurzal;

        //Datos Basicos
        private string _Bodega;
        private string _Documento;
        private string _Descripcion;
        private string _Director;
        private string _Ciudad;
        private string _Telefono01;
        private string _Extension01;
        private string _Telefono02;
        private string _Extension02;
        private string _Movil01;
        private string _Movil02;
        private string _Correo;
        private string _Medida;
        private string _Direccion01;
        private string _Direccion02; 

        //Datos Auxiliares
        private int _Auto;
        private string _Filtro;

        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
        public int Idsucurzal { get => _Idsucurzal; set => _Idsucurzal = value; }
        public string Bodega { get => _Bodega; set => _Bodega = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Director { get => _Director; set => _Director = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Telefono01 { get => _Telefono01; set => _Telefono01 = value; }
        public string Extension01 { get => _Extension01; set => _Extension01 = value; }
        public string Telefono02 { get => _Telefono02; set => _Telefono02 = value; }
        public string Extension02 { get => _Extension02; set => _Extension02 = value; }
        public string Movil01 { get => _Movil01; set => _Movil01 = value; }
        public string Movil02 { get => _Movil02; set => _Movil02 = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Medida { get => _Medida; set => _Medida = value; }
        public string Direccion01 { get => _Direccion01; set => _Direccion01 = value; }
        public string Direccion02 { get => _Direccion02; set => _Direccion02 = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

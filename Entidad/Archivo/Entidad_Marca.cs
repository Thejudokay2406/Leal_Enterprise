using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Marca
    {
        //Llave primaria
        private int _Idmarca;

        //Datos Basicos
        private string _Marca;
        private string _Descripcion;
        private string _Referencia;
        private string _Observacion;
        private int _Estado;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Referencia { get => _Referencia; set => _Referencia = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

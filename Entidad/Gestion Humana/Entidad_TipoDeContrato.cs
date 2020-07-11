using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_TipoDeContrato
    {
        //Llave primaria
        private int _Idtcontrato;

        //Datos Basicos
        private string _Nombre;
        private string _Duracion;
        private string _Descripcion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idtcontrato { get => _Idtcontrato; set => _Idtcontrato = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Duracion { get => _Duracion; set => _Duracion = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

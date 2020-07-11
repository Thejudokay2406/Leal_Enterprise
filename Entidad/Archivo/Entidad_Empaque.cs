using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Empaque
    {
        //Llave primaria
        private int _Idempaque;

        //Datos Basicos
        private string _Empaque;
        private string _Descripcion;
        private string _Observacion;
        private int _Estado;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idempaque { get => _Idempaque; set => _Idempaque = value; }
        public string Empaque { get => _Empaque; set => _Empaque = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

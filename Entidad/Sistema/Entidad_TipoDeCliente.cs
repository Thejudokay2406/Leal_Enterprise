using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_TipoDeCliente
    {
        //Llave primaria
        private int _Idtipodecliente;

        //Datos Basicos
        private string _Codigo;
        private string _Tipo;
        private string _Descripcion;
        private string _Observacion;
        private int _Estado;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idtipodecliente { get => _Idtipodecliente; set => _Idtipodecliente = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

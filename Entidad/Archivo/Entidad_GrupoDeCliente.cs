using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_GrupoDeProductoDeCliente
    {
        //Llave primaria y Auxiliares
        private int _Idgrupo;
        private int _Auto;

        //Datos Basicos
        private string _Grupo;
        private string _Descripcion;
        private string _Observacion;
        private int _Estado;

        public int Idgrupo { get => _Idgrupo; set => _Idgrupo = value; }
        public string Grupo { get => _Grupo; set => _Grupo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Departamento
    {
        //Llaves primaria
        private int _Iddepartamento;
        private int _Idempleado;

        //Datos Basicos
        private string _Departamento;
        private string _AreaPrincipal;
        private string _AreaAuxiliar;
        private DateTime _Apertura;
        private string _Descripcion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Iddepartamento { get => _Iddepartamento; set => _Iddepartamento = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public string Departamento { get => _Departamento; set => _Departamento = value; }
        public string AreaPrincipal { get => _AreaPrincipal; set => _AreaPrincipal = value; }
        public string AreaAuxiliar { get => _AreaAuxiliar; set => _AreaAuxiliar = value; }
        public DateTime Apertura { get => _Apertura; set => _Apertura = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

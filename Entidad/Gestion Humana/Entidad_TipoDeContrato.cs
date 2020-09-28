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
        private string _Codigo;
        private string _Contrato;
        private string _Sueldo;
        private string _Moneda;
        private string _Descripcion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idtcontrato { get => _Idtcontrato; set => _Idtcontrato = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Contrato { get => _Contrato; set => _Contrato = value; }
        public string Sueldo { get => _Sueldo; set => _Sueldo = value; }
        public string Moneda { get => _Moneda; set => _Moneda = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

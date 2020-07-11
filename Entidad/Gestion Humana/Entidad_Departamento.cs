using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Departamento
    {
        //Llave primaria
        private int _Iddepartamento;

        //Datos Basicos
        private string _Nombre;
        private string _Jefe;
        private string _Apertura;
        private string _Funcion;
        private string _Descripcion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Iddepartamento { get => _Iddepartamento; set => _Iddepartamento = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Jefe { get => _Jefe; set => _Jefe = value; }
        public string Apertura { get => _Apertura; set => _Apertura = value; }
        public string Funcion { get => _Funcion; set => _Funcion = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

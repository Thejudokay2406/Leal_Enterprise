using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Equipos
    {
        private int _Idequipo;
        private string _Equipo;
        private string _HDD;
        private string _Tipo;
        private string _Mac_Seguridad;
        private int _Estado;

        //Metodos
        private int _Auto;
        private string _Filtro;

        public int Idequipo { get => _Idequipo; set => _Idequipo = value; }
        public string Equipo { get => _Equipo; set => _Equipo = value; }
        public string HDD { get => _HDD; set => _HDD = value; }
        public string Tipo { get => _Tipo; set => _Tipo = value; }
        public string Mac_Seguridad { get => _Mac_Seguridad; set => _Mac_Seguridad = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

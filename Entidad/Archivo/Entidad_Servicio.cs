using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Servicio
    {
        //Llave primaria
        private int _Idservicio;

        //
        private int _Idimpuesto;

        //Datos Basicos
        private string _Codigo;
        private string _Servicio;
        private string _Descripcion;
        private string _Clase;
        private double _Costo;
        private double _Valor01;
        private double _Valor02;
        private double _Valor03;
        private Int64 _Utilidad;
        private Int64 _Ejecucion;
        private string _Observacion;
        
        //Datos Auxiliares
        private int _Auto;
        private string _Filtro;

        public int Idservicio { get => _Idservicio; set => _Idservicio = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Servicio { get => _Servicio; set => _Servicio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Clase { get => _Clase; set => _Clase = value; }
        public double Costo { get => _Costo; set => _Costo = value; }
        public double Valor01 { get => _Valor01; set => _Valor01 = value; }
        public double Valor02 { get => _Valor02; set => _Valor02 = value; }
        public double Valor03 { get => _Valor03; set => _Valor03 = value; }
        public long Utilidad { get => _Utilidad; set => _Utilidad = value; }
        public long Ejecucion { get => _Ejecucion; set => _Ejecucion = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Idimpuesto { get => _Idimpuesto; set => _Idimpuesto = value; }
    }
}

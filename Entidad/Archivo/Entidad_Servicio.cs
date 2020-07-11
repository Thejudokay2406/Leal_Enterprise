using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Servicio
    {
        //Llaves primarias       
        private int _Idservicio;

        //Datos Basicos
        private string _Codigo;
        private string _Servicio;
        private string _Descripcion;
        private string _Clase;
        private string _Retencion;
        private string _Costo;
        private string _Valor01;
        private string _Valor02;
        private string _Valor03;
        private string _Comision;
        private string _Venta;
        private int _IDImpuesto;
        private int _Estado;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idservicio { get => _Idservicio; set => _Idservicio = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Servicio { get => _Servicio; set => _Servicio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Clase { get => _Clase; set => _Clase = value; }
        public string Retencion { get => _Retencion; set => _Retencion = value; }
        public string Costo { get => _Costo; set => _Costo = value; }
        public string Valor01 { get => _Valor01; set => _Valor01 = value; }
        public string Valor02 { get => _Valor02; set => _Valor02 = value; }
        public string Valor03 { get => _Valor03; set => _Valor03 = value; }
        public string Comision { get => _Comision; set => _Comision = value; }
        public string Venta { get => _Venta; set => _Venta = value; }
        public int IDImpuesto { get => _IDImpuesto; set => _IDImpuesto = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

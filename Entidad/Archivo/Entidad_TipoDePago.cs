using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_TipoDePago
    {
        //Llave primaria
        private int _Idtipodepago;

        //Datos Basicos
        private string _Nombre;
        private int _Compra;
        private int _Venta;
        private int _Inventario;
        private string _Decripcion;

        //Datos Auxiliares
        private int _Auto;

        public int Idtipodepago { get => _Idtipodepago; set => _Idtipodepago = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Compra { get => _Compra; set => _Compra = value; }
        public int Venta { get => _Venta; set => _Venta = value; }
        public int Inventario { get => _Inventario; set => _Inventario = value; }
        public string Decripcion { get => _Decripcion; set => _Decripcion = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
    }
}

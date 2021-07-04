using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Impuesto
    {
        //Llaves primarias       
        private int _Idimpuesto;

        //Datos Basicos
        private string _Impuesto;
        private string _Valor;
        private string _Descripcion;
        private string _MontoDeCompra;
        private string _MontoDeVenta;
        private string _MontoDeServicio;
        private int _Compra;
        private int _Venta;
        private int _Servicio;
        private int _ImpuestoGravado;
        private int _ImpuestoRetencion;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idimpuesto { get => _Idimpuesto; set => _Idimpuesto = value; }
        public string Impuesto { get => _Impuesto; set => _Impuesto = value; }
        public string Valor { get => _Valor; set => _Valor = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string MontoDeCompra { get => _MontoDeCompra; set => _MontoDeCompra = value; }
        public string MontoDeVenta { get => _MontoDeVenta; set => _MontoDeVenta = value; }
        public string MontoDeServicio { get => _MontoDeServicio; set => _MontoDeServicio = value; }
        public int Compra { get => _Compra; set => _Compra = value; }
        public int Venta { get => _Venta; set => _Venta = value; }
        public int Servicio { get => _Servicio; set => _Servicio = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int ImpuestoGravado { get => _ImpuestoGravado; set => _ImpuestoGravado = value; }
        public int ImpuestoRetencion { get => _ImpuestoRetencion; set => _ImpuestoRetencion = value; }
    }
}

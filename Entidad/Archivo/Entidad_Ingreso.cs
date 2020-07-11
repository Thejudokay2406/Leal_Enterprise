using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Ingreso
    {
        private int _Idingreso;
        private int _Idempleado;
        private int _Idproveedor;
        private int _Idbodega;
        private int _Idcomprobante;
        private string _Nº_Comprobante;
        private DateTime _Fecha_de_Ingreso;
        private string _Lote;
        private string _Estado;

        private DataTable _Detalles;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public int Idbodega { get => _Idbodega; set => _Idbodega = value; }
        public int Idcomprobante { get => _Idcomprobante; set => _Idcomprobante = value; }
        public string Nº_Comprobante { get => _Nº_Comprobante; set => _Nº_Comprobante = value; }
        public DateTime Fecha_de_Ingreso { get => _Fecha_de_Ingreso; set => _Fecha_de_Ingreso = value; }
        public string Lote { get => _Lote; set => _Lote = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public DataTable Detalles { get => _Detalles; set => _Detalles = value; }
    }
}

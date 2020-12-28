using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Entidad
{
    public class Entidad_Banco
    {
        //Llaves primarias       
        private int _Idbanco;
        private int _Idcontacto;

        //Llaves Auxiliares de los Detalles
        private int _Contacto_SQL;

        //Datos Auxiliares para Editar los Detalles
        private int _AutoDet_Contacto;

        //Datos Basicos
        private string _Nombre;
        private Int64 _Identificacion;
        private string _Pais;
        private string _Ciudad;
        private string _Area;
        private string _Direccion01;
        private string _Direccion02;
        private Int64 _Telefono01;
        private Int64 _Extension01;
        private Int64 _Telefono02;
        private Int64 _Extension02;
        private Int64 _Movil01;
        private Int64 _Movil02;
        private string _Pagina;

        //Datos de Contacto
        private string _Cont_Asesor;
        private string _Cont_Cargo;
        private string _Cont_Ciudad;
        private Int64 _Cont_Telefono;
        private Int64 _Cont_Extension;
        private Int64 _Cont_Movil;
        private string _Cont_Area;
        private string Cont_Observacion;

        //Detalles de Productos
        private DataTable _Detalle_Contacto;

        //Datos para Ejecutar las Transacciones en SQL
        private int _Contacto_AutoSQL;

        //
        private int _Tran_Contacto;
        
        //Datos Para Filtrar los Multiples registro del Producto Como Contacto, Lotes ETC
        private int _Auto_Contacto;

        private int _Det_Contacto;

        //Datos Auxiliares
        private int _Auto;
        private int _Eliminar;
        private string _Filtro;

        public int Idbanco { get => _Idbanco; set => _Idbanco = value; }
        public int Idcontacto { get => _Idcontacto; set => _Idcontacto = value; }
        public int Contacto_SQL { get => _Contacto_SQL; set => _Contacto_SQL = value; }
        public int AutoDet_Contacto { get => _AutoDet_Contacto; set => _AutoDet_Contacto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public long Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Area { get => _Area; set => _Area = value; }
        public string Direccion01 { get => _Direccion01; set => _Direccion01 = value; }
        public string Direccion02 { get => _Direccion02; set => _Direccion02 = value; }
        public long Telefono01 { get => _Telefono01; set => _Telefono01 = value; }
        public long Extension01 { get => _Extension01; set => _Extension01 = value; }
        public long Telefono02 { get => _Telefono02; set => _Telefono02 = value; }
        public long Extension02 { get => _Extension02; set => _Extension02 = value; }
        public long Movil01 { get => _Movil01; set => _Movil01 = value; }
        public long Movil02 { get => _Movil02; set => _Movil02 = value; }
        public string Pagina { get => _Pagina; set => _Pagina = value; }
        public string Cont_Asesor { get => _Cont_Asesor; set => _Cont_Asesor = value; }
        public string Cont_Cargo { get => _Cont_Cargo; set => _Cont_Cargo = value; }
        public string Cont_Ciudad { get => _Cont_Ciudad; set => _Cont_Ciudad = value; }
        public long Cont_Telefono { get => _Cont_Telefono; set => _Cont_Telefono = value; }
        public long Cont_Extension { get => _Cont_Extension; set => _Cont_Extension = value; }
        public long Cont_Movil { get => _Cont_Movil; set => _Cont_Movil = value; }
        public string Cont_Area { get => _Cont_Area; set => _Cont_Area = value; }
        public string Cont_Observacion1 { get => Cont_Observacion; set => Cont_Observacion = value; }
        public DataTable Detalle_Contacto { get => _Detalle_Contacto; set => _Detalle_Contacto = value; }
        public int Contacto_AutoSQL { get => _Contacto_AutoSQL; set => _Contacto_AutoSQL = value; }
        public int Tran_Contacto { get => _Tran_Contacto; set => _Tran_Contacto = value; }
        public int Auto_Contacto { get => _Auto_Contacto; set => _Auto_Contacto = value; }
        public int Det_Contacto { get => _Det_Contacto; set => _Det_Contacto = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entidad_Usuarios
    {
        //Llaves Primarias
        private int _Idusuario;
        private int _Idempleado;
        private int _Idpermiso;
        private int _Idnivel;

        //Datos Basicos
        private string _Empleado;
        private string _Usuario;
        private string _Contraseña;
        private string _Descripcion;
        private int _Estado;

        //Niveles
        private int _Almacen;
        private int _Financiera;
        private int _GestionHumana;
        private int _Produccion;
        private int _Remision;
        private int _Reportes;
        private int _Tesoreria;
        private int _Sistema;
        private int _Ventas;

        //Permisos
        private int _Consultar;
        private int _Guardar;
        private int _Eliminar;
        private int _Editar;

        //Filtros y Metodos
        private int _Auto;
        private string _Filtro;

        private int _Permisos;
        private int _Nivel;

        public int Idusuario { get => _Idusuario; set => _Idusuario = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idpermiso { get => _Idpermiso; set => _Idpermiso = value; }
        public int Idnivel { get => _Idnivel; set => _Idnivel = value; }
        public string Empleado { get => _Empleado; set => _Empleado = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public int Almacen { get => _Almacen; set => _Almacen = value; }
        public int Financiera { get => _Financiera; set => _Financiera = value; }
        public int GestionHumana { get => _GestionHumana; set => _GestionHumana = value; }
        public int Produccion { get => _Produccion; set => _Produccion = value; }
        public int Remision { get => _Remision; set => _Remision = value; }
        public int Reportes { get => _Reportes; set => _Reportes = value; }
        public int Tesoreria { get => _Tesoreria; set => _Tesoreria = value; }
        public int Sistema { get => _Sistema; set => _Sistema = value; }
        public int Ventas { get => _Ventas; set => _Ventas = value; }
        public int Consultar { get => _Consultar; set => _Consultar = value; }
        public int Guardar { get => _Guardar; set => _Guardar = value; }
        public int Eliminar { get => _Eliminar; set => _Eliminar = value; }
        public int Editar { get => _Editar; set => _Editar = value; }
        public int Auto { get => _Auto; set => _Auto = value; }
        public string Filtro { get => _Filtro; set => _Filtro = value; }
        public int Permisos { get => _Permisos; set => _Permisos = value; }
        public int Nivel { get => _Nivel; set => _Nivel = value; }
    }
}

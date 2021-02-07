using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidad;
using System.Data;

namespace Negocio
{
    public class fProducto_Inventario
    {
        public static DataTable Lista()
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista();
        }

        public static DataTable Lista_Compuesto(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Compuesto(auto, idproducto);
        }

        public static DataTable Lista_Exterior(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Exterior(auto, idproducto);
        }

        public static DataTable Lista_CodigoDeBarra(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_CodigoDeBarra(auto, idproducto);
        }

        public static DataTable Lista_Igualdad(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Igualdad(auto, idproducto);
        }

        public static DataTable Lista_Impuesto(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Impuesto(auto, idproducto);
        }

        public static DataTable Lista_Lote(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Lote(auto, idproducto);
        }

        public static DataTable Lista_Proveedor(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Proveedor(auto, idproducto);
        }

        public static DataTable Lista_Ubicacion(int auto, int idproducto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista_Ubicacion(auto, idproducto);
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable Buscar_Igualdad(int Auto_Igualdad, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Igualdad(Auto_Igualdad, Filtro);
        }

        public static DataTable Buscar_Impuesto(int Auto_Impuesto, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Impuesto(Auto_Impuesto, Filtro);
        }

        public static DataTable Buscar_Proveedor(int Auto_Proveedor, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Proveedor(Auto_Proveedor, Filtro);
        }

        public static DataTable Buscar_Lote(int Auto_Lote, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Lote(Auto_Lote, Filtro);
        }

        public static DataTable Buscar_Ubicacion(int Auto_Ubicacion, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Ubicacion(Auto_Ubicacion, Filtro);
        }

        public static DataTable Buscar_CodigoDeBarra(int Auto_CodigoDeBarra, int Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_CodigoDeBarra(Auto_CodigoDeBarra, Filtro);
        }

        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Llaves Auxiliares Datos Basicos
                int Auto, int Idmarca, int Idgrupo, int Idtipo, int Idempaque,

                //Datos para Ejecutar las Transacciones en SQL
                int Tran_Ubicacion, int Tran_Igualdad, int Tran_Impuesto, int Tran_Proveedor, int Tran_CodBarra, int Tran_Lote, int Tran_Compuesto, int Tran_Exterior,

                //Datos Basicos
                string Codigo, string Producto, string Referencia, string Descripcion, string Presentacion, Int64 Comision, int ManejaVencimiento, int ManejaImpuesto, int Importado, int Exportado, int Ofertable, int ManejaComision, int ManejaEmpaque, int ManejaBalanza, int ManejaRetencion,

                //Valores
                double Compra_Promedio, double Compra_Final, double Venta01, double Venta02, double Venta03, double Mayorista, double Venta01_Porcentaje, double Venta02_Porcentaje, double Venta03_Porcentaje, double Mayorista_Porcentaje, double Venta01_BaseInicial, double Venta02_BaseInicial, double Venta03_BaseInicial, double Mayorista_BaseInicial, double Venta01_Impuesto, double Venta02_Impuesto, double Venta03_Impuesto, double Mayorista_Impuesto,

                string Unidad, string Unidad_Detalle, double Unidad01, double Unidad02, double Unidad03, double Unidad01_Porcentaje, double Unidad02_Porcentaje, double Unidad03_Porcentaje, double Unidad01_BaseInicial, double Unidad02_BaseInicial, double Unidad03_BaseInicial, double Unidad01_Impuesto, double Unidad02_Impuesto, double Unidad03_Impuesto,

                //Panel - Fabricacion
                double Material_Principal, double Material_Secundario, double Material_Terciario, double Material_OtroMaterial, double ManoDeObra, double Materiales, double Envio, double Almacenamiento, double Maquinaria, double Herramientas_Manuales, double CostoFabricacion,

                //Detalles de Productos
                DataTable Detalle_Lote, DataTable Detalle_Impuesto, DataTable Detalle_Igualdad, DataTable Detalle_Proveedor, DataTable Detalle_Ubicacion, DataTable Detalle_CodigoDeBarra, DataTable Detalle_Exterior, DataTable Detalle_Compuesto,

                //Panel de Imagenes
                byte[] Imagen
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Llaves Auxiliares Datos Basicos
            Obj.Auto = Auto;
            Obj.Idmarca = Idmarca;
            Obj.Idgrupo = Idgrupo;
            Obj.Idtipo = Idtipo;
            Obj.Idempaque = Idempaque;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Producto = Producto;
            Obj.Referencia = Referencia;
            Obj.Descripcion = Descripcion;
            Obj.Presentacion = Presentacion;
            Obj.Comision = Comision;

            Obj.ManejaVencimiento = ManejaVencimiento;
            Obj.ManejaImpuesto = ManejaImpuesto;
            Obj.Importado = Importado;
            Obj.Exportado = Exportado;
            Obj.Ofertable = Ofertable;
            Obj.ManejaComision = ManejaComision;
            Obj.ManejaEmpaque = ManejaEmpaque;
            Obj.ManejaBalanza = ManejaBalanza;
            Obj.ManejaRetencion = ManejaRetencion;

            //Valores
            Obj.Compra_Promedio = Compra_Promedio;
            Obj.Compra_Final = Compra_Final;
            Obj.Venta01 = Venta01;
            Obj.Venta02 = Venta02;
            Obj.Venta03 = Venta03;
            Obj.Mayorista = Mayorista;
            Obj.Venta01_Porcentaje = Venta01_Porcentaje;
            Obj.Venta02_Porcentaje = Venta02_Porcentaje;
            Obj.Venta03_Porcentaje = Venta03_Porcentaje;
            Obj.Mayorista_Porcentaje = Mayorista_Porcentaje;
            Obj.Venta01_BaseInicial = Venta01_BaseInicial;
            Obj.Venta02_BaseInicial = Venta02_BaseInicial;
            Obj.Venta03_BaseInicial = Venta03_BaseInicial;
            Obj.Mayorista_BaseInicial = Mayorista_BaseInicial;
            Obj.Venta01_Impuesto = Venta01_Impuesto;
            Obj.Venta02_Impuesto = Venta02_Impuesto;
            Obj.Venta03_Impuesto = Venta03_Impuesto;
            Obj.Mayorista_Impuesto = Mayorista_Impuesto;

            Obj.Unidad = Unidad;
            Obj.Unidad_Detalle = Unidad_Detalle;
            Obj.Unidad01 = Unidad01;
            Obj.Unidad02 = Unidad02;
            Obj.Unidad03 = Unidad03;
            Obj.Unidad01_Porcentaje = Unidad01_Porcentaje;
            Obj.Unidad02_Porcentaje = Unidad02_Porcentaje;
            Obj.Unidad03_Porcentaje = Unidad03_Porcentaje;
            Obj.Unidad01_BaseInicial = Unidad01_BaseInicial;
            Obj.Unidad02_BaseInicial = Unidad02_BaseInicial;
            Obj.Unidad03_BaseInicial = Unidad03_BaseInicial;
            Obj.Unidad01_Impuesto = Unidad01_Impuesto;
            Obj.Unidad02_Impuesto = Unidad02_Impuesto;
            Obj.Unidad03_Impuesto = Unidad03_Impuesto;

            //Panel - Fabricacion
            Obj.Material_Principal = Material_Principal;
            Obj.Material_Secundario = Material_Secundario;
            Obj.Material_Terciario = Material_Terciario;
            Obj.Material_OtroMaterial = Material_OtroMaterial;
            Obj.ManoDeObra = ManoDeObra;
            Obj.Materiales = Materiales;
            Obj.Envio = Envio;
            Obj.Almacenamiento = Almacenamiento;
            Obj.Maquinaria = Maquinaria;
            Obj.Herramientas_Manuales = Herramientas_Manuales;
            Obj.CostoFabricacion = CostoFabricacion;

            //Detalles de Productos
            Obj.Detalle_Lote = Detalle_Lote;
            Obj.Detalle_Impuesto = Detalle_Impuesto;
            Obj.Detalle_Igualdad = Detalle_Igualdad;
            Obj.Detalle_Proveedor = Detalle_Proveedor;
            Obj.Detalle_Ubicacion = Detalle_Ubicacion;
            Obj.Detalle_CodigoDeBarra = Detalle_CodigoDeBarra;
            Obj.Detalle_Exterior = Detalle_Exterior;
            Obj.Detalle_Compuesto = Detalle_Compuesto;

            //Panel de Imagenes
            Obj.Imagen = Imagen;

            //Datos para Ejecutar las Transacciones en SQL
            Obj.Tran_Ubicacion = Tran_Ubicacion;
            Obj.Tran_Igualdad = Tran_Igualdad;
            Obj.Tran_Impuesto = Tran_Impuesto;
            Obj.Tran_Proveedor = Tran_Proveedor;
            Obj.Tran_CodBarra = Tran_CodBarra;
            Obj.Tran_Lote = Tran_Lote;
            Obj.Tran_Compuesto = Tran_Compuesto;
            Obj.Tran_Exterior = Tran_Exterior;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Llaves Auxiliares Datos Basicos
                int Auto, int Idproducto, int Idmarca, int Idgrupo, int Idtipo, int Idempaque,

                //Datos para Ejecutar las Transacciones en SQL
                int Tran_Ubicacion, int Tran_Igualdad, int Tran_Impuesto, int Tran_Proveedor, int Tran_CodBarra, int Tran_Lote, int Tran_Compuesto, int Tran_Exterior,

                //Datos Basicos
                string Codigo, string Producto, string Referencia, string Descripcion, string Presentacion, Int64 Comision, int ManejaVencimiento, int ManejaImpuesto, int Importado, int Exportado, int Ofertable, int ManejaComision, int ManejaEmpaque, int ManejaBalanza, int ManejaRetencion,

                //Valores
                double Compra_Promedio, double Compra_Final, double Venta01, double Venta02, double Venta03, double Mayorista, double Venta01_Porcentaje, double Venta02_Porcentaje, double Venta03_Porcentaje, double Mayorista_Porcentaje, double Venta01_BaseInicial, double Venta02_BaseInicial, double Venta03_BaseInicial, double Mayorista_BaseInicial, double Venta01_Impuesto, double Venta02_Impuesto, double Venta03_Impuesto, double Mayorista_Impuesto,

                string Unidad, string Unidad_Detalle, double Unidad01, double Unidad02, double Unidad03, double Unidad01_Porcentaje, double Unidad02_Porcentaje, double Unidad03_Porcentaje, double Unidad01_BaseInicial, double Unidad02_BaseInicial, double Unidad03_BaseInicial, double Unidad01_Impuesto, double Unidad02_Impuesto, double Unidad03_Impuesto,

                //Panel - Fabricacion
                double Material_Principal, double Material_Secundario, double Material_Terciario, double Material_OtroMaterial, double ManoDeObra, double Materiales, double Envio, double Almacenamiento, double Maquinaria, double Herramientas_Manuales, double CostoFabricacion,

                //Panel de Imagenes
                byte[] Imagen
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Llaves Auxiliares Datos Basicos
            Obj.Auto = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idmarca = Idmarca;
            Obj.Idgrupo = Idgrupo;
            Obj.Idtipo = Idtipo;
            Obj.Idempaque = Idempaque;

            //Datos Basicos
            Obj.Codigo = Codigo;
            Obj.Producto = Producto;
            Obj.Referencia = Referencia;
            Obj.Descripcion = Descripcion;
            Obj.Presentacion = Presentacion;
            Obj.Comision = Comision;

            Obj.ManejaVencimiento = ManejaVencimiento;
            Obj.ManejaImpuesto = ManejaImpuesto;
            Obj.Importado = Importado;
            Obj.Exportado = Exportado;
            Obj.Ofertable = Ofertable;
            Obj.ManejaComision = ManejaComision;
            Obj.ManejaEmpaque = ManejaEmpaque;
            Obj.ManejaBalanza = ManejaBalanza;
            Obj.ManejaRetencion = ManejaRetencion;

            //Valores
            Obj.Compra_Promedio = Compra_Promedio;
            Obj.Compra_Final = Compra_Final;
            Obj.Venta01 = Venta01;
            Obj.Venta02 = Venta02;
            Obj.Venta03 = Venta03;
            Obj.Mayorista = Mayorista;
            Obj.Venta01_Porcentaje = Venta01_Porcentaje;
            Obj.Venta02_Porcentaje = Venta02_Porcentaje;
            Obj.Venta03_Porcentaje = Venta03_Porcentaje;
            Obj.Mayorista_Porcentaje = Mayorista_Porcentaje;
            Obj.Venta01_BaseInicial = Venta01_BaseInicial;
            Obj.Venta02_BaseInicial = Venta02_BaseInicial;
            Obj.Venta03_BaseInicial = Venta03_BaseInicial;
            Obj.Mayorista_BaseInicial = Mayorista_BaseInicial;
            Obj.Venta01_Impuesto = Venta01_Impuesto;
            Obj.Venta02_Impuesto = Venta02_Impuesto;
            Obj.Venta03_Impuesto = Venta03_Impuesto;
            Obj.Mayorista_Impuesto = Mayorista_Impuesto;

            Obj.Unidad = Unidad;
            Obj.Unidad_Detalle = Unidad_Detalle;
            Obj.Unidad01 = Unidad01;
            Obj.Unidad02 = Unidad02;
            Obj.Unidad03 = Unidad03;
            Obj.Unidad01_Porcentaje = Unidad01_Porcentaje;
            Obj.Unidad02_Porcentaje = Unidad02_Porcentaje;
            Obj.Unidad03_Porcentaje = Unidad03_Porcentaje;
            Obj.Unidad01_BaseInicial = Unidad01_BaseInicial;
            Obj.Unidad02_BaseInicial = Unidad02_BaseInicial;
            Obj.Unidad03_BaseInicial = Unidad03_BaseInicial;
            Obj.Unidad01_Impuesto = Unidad01_Impuesto;
            Obj.Unidad02_Impuesto = Unidad02_Impuesto;
            Obj.Unidad03_Impuesto = Unidad03_Impuesto;

            //Panel - Fabricacion
            Obj.Material_Principal = Material_Principal;
            Obj.Material_Secundario = Material_Secundario;
            Obj.Material_Terciario = Material_Terciario;
            Obj.Material_OtroMaterial = Material_OtroMaterial;
            Obj.ManoDeObra = ManoDeObra;
            Obj.Materiales = Materiales;
            Obj.Envio = Envio;
            Obj.Almacenamiento = Almacenamiento;
            Obj.Maquinaria = Maquinaria;
            Obj.Herramientas_Manuales = Herramientas_Manuales;
            Obj.CostoFabricacion = CostoFabricacion;

            //Panel de Imagenes
            Obj.Imagen = Imagen;

            return Datos.Editar_DatosBasicos(Obj);
        }

        //************************************** SE PROCEDE A EDITAR LOS MULTIPLEX DETALLES COMO UBICACION, LOTE, PROVEEDOR ETC **************************************

        public static string Editar_CodigoDeBarra
            (
                //Panel - Codigo de Barra
                int Auto, int Idproducto, int Idcodigodebarra, string Codigodebarra
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel - Codigo de Barra
            Obj.CodBarra_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idcodigodebarra = Idcodigodebarra;
            Obj.Codigodebarra = Codigodebarra;

            return Datos.Editar_CodigoDeBarra(Obj);
        }

        public static string Editar_Compuesto
            (
                //Panel Compuesto
                int Auto, int Idproducto, int Idcompuesto, string Compuesto, string Compuesto_Descripcion, string Compuesto_Medida, string Compuesto_MedodaDescripcion
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Compuesto
            Obj.Compuesto_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idcompuesto = Idcompuesto;
            Obj.Compuesto = Compuesto;
            Obj.Compuesto_Descripcion = Compuesto_Descripcion;
            Obj.Compuesto_Medida = Compuesto_Medida;
            Obj.Compuesto_MedodaDescripcion = Compuesto_MedodaDescripcion;

            return Datos.Editar_Compuesto(Obj);
        }

        public static string Editar_Exterior
            (
                //Panel - Exterior
                int Auto, int Idproducto, int Idexterior, double Ext_Aduana, double Ext_Comision, double Ext_Documento, double Ext_Adicional, double Ext_Exportacion, double Ext_Importacion, double Ext_Seguridad, double Ext_Aduana_Moneda, double Ext_Comision_Moneda, double Ext_Documento_Moneda, double Ext_Adicional_Moneda, double Ext_Exportacion_Moneda, double Ext_Importacion_Moneda, double Ext_Seguridad_Moneda
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel - Exterior
            Obj.Exterior_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idexterior = Idexterior;
            Obj.Ext_Aduana = Ext_Aduana;
            Obj.Ext_Comision = Ext_Comision;
            Obj.Ext_Documento = Ext_Documento;
            Obj.Ext_Adicional = Ext_Adicional;
            Obj.Ext_Exportacion = Ext_Exportacion;
            Obj.Ext_Importacion = Ext_Importacion;
            Obj.Ext_Seguridad = Ext_Seguridad;
            Obj.Ext_Aduana_Moneda = Ext_Aduana_Moneda;
            Obj.Ext_Comision_Moneda = Ext_Comision_Moneda;
            Obj.Ext_Documento_Moneda = Ext_Documento_Moneda;
            Obj.Ext_Adicional_Moneda = Ext_Adicional_Moneda;
            Obj.Ext_Exportacion_Moneda = Ext_Exportacion_Moneda;
            Obj.Ext_Importacion_Moneda = Ext_Importacion_Moneda;
            Obj.Ext_Seguridad_Moneda = Ext_Seguridad_Moneda;

            return Datos.Editar_Exterior(Obj);
        }

        public static string Editar_Igualdad
            (
                //Panel Igualdad
                int Auto, int Idproducto, int Idigualdad, string Igualdad_Codigo, string Igualdad_Producto, string Igualdad_Marca
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Igualdad
            Obj.Igualdad_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idigualdad = Idigualdad;
            Obj.Igualdad_Codigo = Igualdad_Codigo;
            Obj.Igualdad_Producto = Igualdad_Producto;
            Obj.Igualdad_Marca = Igualdad_Marca;

            return Datos.Editar_Igualdad(Obj);
        }

        public static string Editar_Impuesto
            (
                //Panel Impuesto
                int Auto, int Idproducto, int Idimpuesto, string Impuesto, string Impuesto_Descripcion, string Impuesto_Valor
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Impuesto
            Obj.Impuesto_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idimpuesto = Idimpuesto;
            Obj.Impuesto = Impuesto;
            Obj.Impuesto_Descripcion = Impuesto_Descripcion;
            Obj.Impuesto_Valor = Impuesto_Valor;

            return Datos.Editar_Impuesto(Obj);
        }

        public static string Editar_Lote
            (
                //Panel Lotes
                int Auto, int Idproducto, int Idlote, string Lote, string Lote_Compra, string Lote_Venta, string Lote_Cantidad, DateTime Lote_Fecha
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Lotes
            Obj.Lote_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idlote = Idlote;
            Obj.Lote = Lote;
            Obj.Lote_Compra = Lote_Compra;
            Obj.Lote_Venta = Lote_Venta;
            Obj.Lote_Cantidad = Lote_Cantidad;
            Obj.Lote_Fecha = Lote_Fecha;

            return Datos.Editar_Lote(Obj);
        }

        public static string Editar_Proveedor
            (
                //Panel Proveedor
                int Auto, int Idproducto, int Idproveedor, string Proveedor, string Proveedor_Documento
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Proveedor
            Obj.Proveedor_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idproveedor = Idproveedor;
            Obj.Proveedor = Proveedor;
            Obj.Proveedor_Documento = Proveedor_Documento;

            return Datos.Editar_Proveedor(Obj);
        }

        public static string Editar_Ubicacion
            (
                //Panel Ubicacion
                int Auto, int Idproducto, int Idubicacion, int Idbodega, string Ubicacion, string Estante, string Nivel
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Ubicacion
            Obj.Ubicacion_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idubicacion = Idubicacion;
            Obj.Idbodega = Idbodega;
            Obj.Ubicacion = Ubicacion;
            Obj.Estante = Estante;
            Obj.Nivel = Nivel;

            return Datos.Editar_Ubicacion(Obj);
        }

        //************************************** SE PROCEDE AGREGAR LOS REGISTROS ADICIONALES DE LOS DETALLES COMO UBICACION, LOTE, PROVEEDOR ETC **************************************

        public static string Guardar_CodigoDeBarra
            (
                //Panel - Codigo de Barra
                int Auto, int Idproducto, string Codigodebarra
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel - Codigo de Barra
            Obj.CodBarra_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Codigodebarra = Codigodebarra;

            return Datos.Guardar_CodigoDeBarra(Obj);
        }

        public static string Guardar_Compuesto
            (
                //Panel Compuesto
                int Auto, int Idproducto, string Compuesto, string Compuesto_Descripcion, string Compuesto_Medida, string Compuesto_MedodaDescripcion
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Compuesto
            Obj.Compuesto_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Compuesto = Compuesto;
            Obj.Compuesto_Descripcion = Compuesto_Descripcion;
            Obj.Compuesto_Medida = Compuesto_Medida;
            Obj.Compuesto_MedodaDescripcion = Compuesto_MedodaDescripcion;

            return Datos.Guardar_Compuesto(Obj);
        }

        public static string Guardar_Exterior
            (
                //Panel - Exterior
                int Auto, int Idproducto, double Ext_Aduana, double Ext_Comision, double Ext_Documento, double Ext_Adicional, double Ext_Exportacion, double Ext_Importacion, double Ext_Seguridad, double Ext_Aduana_Moneda, double Ext_Comision_Moneda, double Ext_Documento_Moneda, double Ext_Adicional_Moneda, double Ext_Exportacion_Moneda, double Ext_Importacion_Moneda, double Ext_Seguridad_Moneda
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel - Exterior
            Obj.Impuesto_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Ext_Aduana = Ext_Aduana;
            Obj.Ext_Comision = Ext_Comision;
            Obj.Ext_Documento = Ext_Documento;
            Obj.Ext_Adicional = Ext_Adicional;
            Obj.Ext_Exportacion = Ext_Exportacion;
            Obj.Ext_Importacion = Ext_Importacion;
            Obj.Ext_Seguridad = Ext_Seguridad;
            Obj.Ext_Aduana_Moneda = Ext_Aduana_Moneda;
            Obj.Ext_Comision_Moneda = Ext_Comision_Moneda;
            Obj.Ext_Documento_Moneda = Ext_Documento_Moneda;
            Obj.Ext_Adicional_Moneda = Ext_Adicional_Moneda;
            Obj.Ext_Exportacion_Moneda = Ext_Exportacion_Moneda;
            Obj.Ext_Importacion_Moneda = Ext_Importacion_Moneda;
            Obj.Ext_Seguridad_Moneda = Ext_Seguridad_Moneda;

            return Datos.Guardar_Exterior(Obj);
        }

        public static string Guardar_Igualdad
            (
                //Panel Igualdad
                int Auto ,int Idproducto, string Igualdad_Codigo, string Igualdad_Producto, string Igualdad_Marca
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Igualdad
            Obj.Igualdad_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Igualdad_Codigo = Igualdad_Codigo;
            Obj.Igualdad_Producto = Igualdad_Producto;
            Obj.Igualdad_Marca = Igualdad_Marca;

            return Datos.Guardar_Igualdad(Obj);
        }

        public static string Guardar_Impuesto
            (
                //Panel Impuesto
                int Auto, int Idproducto, int Idimpuesto, string Impuesto, string Impuesto_Descripcion, string Impuesto_Valor
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Impuesto
            Obj.Impuesto_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idimpuesto = Idimpuesto;
            Obj.Impuesto = Impuesto;
            Obj.Impuesto_Descripcion = Impuesto_Descripcion;
            Obj.Impuesto_Valor = Impuesto_Valor;

            return Datos.Guardar_Impuestos(Obj);
        }

        public static string Guardar_Lote
            (
                //Panel Lotes
                int Auto, int Idproducto, string Lote, string Lote_Compra, string Lote_Venta, string Lote_Cantidad, DateTime Lote_Fecha
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Lotes
            Obj.Lote_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Lote = Lote;
            Obj.Lote_Compra = Lote_Compra;
            Obj.Lote_Venta = Lote_Venta;
            Obj.Lote_Cantidad = Lote_Cantidad;
            Obj.Lote_Fecha = Lote_Fecha;

            return Datos.Guardar_Lote(Obj);
        }

        public static string Guardar_Proveedor
            (
                //Panel Proveedor
                int Auto, int Idproducto, int Idproveedor, string Proveedor, string Proveedor_Documento
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Proveedor
            Obj.Proveedor_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idproveedor = Idproveedor;
            Obj.Proveedor = Proveedor;
            Obj.Proveedor_Documento = Proveedor_Documento;

            return Datos.Guardar_Proveedor(Obj);
        }

        public static string Guardar_Ubicacion
            (
                //Panel Ubicacion
                int Auto, int Idproducto, int Idbodega, string Ubicacion, string Estante, string Nivel
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Panel Ubicacion
            Obj.Ubicacion_AutoSQL = Auto;
            Obj.Idproducto = Idproducto;
            Obj.Idbodega = Idbodega;
            Obj.Ubicacion = Ubicacion;
            Obj.Estante = Estante;
            Obj.Nivel = Nivel;

            return Datos.Guardar_Ubicacion(Obj);
        }

        public static string Eliminar(int Idproducto, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar(Idproducto, Auto);
        }

        public static string Eliminar_CodigoDeBara(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_CodigoDeBara(Idproducto, Iddetalle, Auto);
        }

        public static string Eliminar_Igualdad(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_Igualdad(Idproducto, Iddetalle, Auto);
        }

        public static string Eliminar_Lote(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_Lote(Idproducto, Iddetalle, Auto);
        }

        public static string Eliminar_Proveedor(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_Proveedor(Idproducto, Iddetalle, Auto);
        }

        public static string Eliminar_Ubicacion(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_Ubicacion(Idproducto, Iddetalle, Auto);
        }

        public static string Eliminar_Impuesto(int Idproducto, int Iddetalle, int Auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar_Impuesto(Idproducto, Iddetalle, Auto);
        }
    }
}

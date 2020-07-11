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
    public class fProductos
    {
        public static DataTable Lista()
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Lista();
        }

        public static DataTable Buscar(string Filtro, int auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar(Filtro, auto);
        }

        public static DataTable Buscar_Igualdad(string Filtro)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Buscar_Igualdad(Filtro);
        }

        public static DataTable AutoComplementar_SQL(int auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.AutoComplementar_SQL(auto);
        }

        public static string Guardar_DatosBasicos
            (
                //Datos Basicos
                int idmarca, int idempaque, int idgrupo, int idtipo, string codigo, string producto, string referencia, string descripcion,
                string presentacion, string unidad, string comision, int comision_porcentaje, int manejavencimiento, int manejaimpuesto,
                int importado, int exportado, int ofertable, int manejacomision,

                //Valores
                string compra_promedio, string Compra_final, string Venta_excento, string venta_noexcento, string venta_mayorista,
                string fabricacion, string materiales, string exportacion, string importacion, string seguro, string gastos,

                //Cantidades
                string venta_minimacliente, string venta_maximacliente, string venta_minimamayorista, string venta_maximamayorista,
                string compra_minimacliente, string compra_maximacliente, string compra_minimamayorista, string compra_maximamayorista,

                //Panel Lote
                DataTable detalle_lote,

                //Panel Impuestos
                DataTable detalle_impuesto,

                //Panel Igualdad
                DataTable detalle_igualdad,

                //Panel Proveedor
                DataTable detalle_proveedor,

                //Ubicacion[]
                DataTable detalle_ubicacion,

                //Panel Codigo de Barra
                DataTable detalle_codigodebarra,

                //Panel Imagen
                Byte[] imagen,

                //Datos Auxiliares
                int lote_autosql, int codbarra_autosql, int igualdad_autosql, int impuesto_autosql, int ubicacion_autosql, int proveedor_autosql,

                //
                int tran_ubicacion, int tran_igualdad, int tran_impuesto, int tran_proveedor, int tran_codBarra, int tran_lote,

                //Variables
                int auto
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idmarca = idmarca;
            Obj.Idempaque = idempaque;
            Obj.Idgrupo = idgrupo;
            Obj.Idtipo = idtipo;
            //Obj.Producto_AutoSQL = producto_autosql;

            //Datos Basicos
            Obj.Codigo = codigo;
            Obj.Producto = producto;
            Obj.Referencia = referencia;
            Obj.Descripcion = descripcion;
            Obj.Presentacion = presentacion;
            Obj.Unidad = unidad;
            Obj.Comision = comision;
            Obj.Comision_Porcentaje = comision_porcentaje;

            Obj.ManejaVencimiento = manejavencimiento;
            Obj.ManejaImpuesto = manejaimpuesto;
            Obj.Importado = importado;
            Obj.Exportado = exportado;
            Obj.Ofertable = ofertable;
            Obj.ManejaComision = manejacomision;

            //Valores
            Obj.Compra_Promedio = compra_promedio;
            Obj.Compra_Final = Compra_final;
            Obj.Venta_Excento = Venta_excento;
            Obj.Venta_NoExcento = venta_noexcento;
            Obj.Venta_Mayorista = venta_mayorista;
            Obj.Fabricacion = fabricacion;
            Obj.Materiales = materiales;
            Obj.Exportacion = exportacion;
            Obj.Importacion = importacion;
            Obj.Seguro = seguro;
            Obj.Gastos = gastos;

            //Cantidades
            Obj.Venta_MinimaCliente = venta_minimacliente;
            Obj.Venta_MaximaCliente = venta_maximacliente;
            Obj.Venta_MinimaMayorista = venta_minimamayorista;
            Obj.Venta_MaximaMayorista = venta_maximamayorista;
            Obj.Compra_MinimaCliente = compra_minimacliente;
            Obj.Compra_MaximaCliente = compra_maximacliente;
            Obj.Compra_MinimaMayorista = compra_minimamayorista;
            Obj.Compra_MaximaMayorista = compra_maximamayorista;

            //Panel Lote
            Obj.Detalle_Lote = detalle_lote;

            //Panel Impuestos
            Obj.Detalle_Impuesto = detalle_impuesto;

            //Panel Igualdad
            Obj.Detalle_Igualdad = detalle_igualdad;

            //Panel Proveedor
            Obj.Detalle_Proveedor = detalle_proveedor;

            //Ubicacion[]
            Obj.Detalle_Ubicacion = detalle_ubicacion;

            //Panel Codigo de Barra
            Obj.Detalle_CodigoDeBarra = detalle_codigodebarra;

            //Panel Imagen
            Obj.Imagen = imagen;

            //Datos Auxiliares
            Obj.Auto = auto;

            Obj.Tran_Ubicacion = tran_ubicacion;
            Obj.Tran_Igualdad = tran_igualdad;
            Obj.Tran_Impuesto = tran_impuesto;
            Obj.Tran_Proveedor = tran_proveedor;
            Obj.Tran_CodBarra = tran_codBarra;
            Obj.Tran_Lote = tran_lote;

            Obj.Lote_AutoSQL = lote_autosql;
            Obj.CodBarra_AutoSQL = codbarra_autosql;
            Obj.Igualdad_AutoSQL = igualdad_autosql;
            Obj.Impuesto_AutoSQL = impuesto_autosql;
            Obj.Ubicacion_AutoSQL = ubicacion_autosql;
            Obj.Proveedor_AutoSQL = proveedor_autosql;

            return Datos.Guardar_DatosBasicos(Obj);
        }

        public static string Editar_DatosBasicos
            (
                //Llave Primaria
                int idproducto,

                //Datos Basicos
                int idmarca, int idempaque, int idgrupo, int idtipo, string codigo, string producto, string referencia, string descripcion,
                string presentacion, string unidad, string comision, int comision_porcentaje, int manejavencimiento, int manejaimpuesto,
                int importado, int exportado, int ofertable, int manejacomision,

                //Valores
                string compra_promedio, string Compra_final, string Venta_excento, string venta_noexcento, string venta_mayorista,
                string fabricacion, string materiales, string exportacion, string importacion, string seguro, string gastos,

                //Cantidades
                string venta_minimacliente, string venta_maximacliente, string venta_minimamayorista, string venta_maximamayorista,
                string compra_minimacliente, string compra_maximacliente, string compra_minimamayorista, string compra_maximamayorista,

                //Panel Lote
                DataTable detalle_lote,

                //Panel Impuestos
                DataTable detalle_impuesto,

                //Panel Igualdad
                DataTable detalle_igualdad,

                //Panel Proveedor
                DataTable detalle_proveedor,

                //Ubicacion[]
                DataTable detalle_ubicacion,

                //Panel Codigo de Barra
                DataTable detalle_codigodebarra,

                //Panel Imagen
                Byte[] imagen,

                //Datos Auxiliares
                int auto
            )
        {
            Conexion_Producto Datos = new Conexion_Producto();
            Entidad_Productos Obj = new Entidad_Productos();

            //Datos Auxiliares y Llaves Primaria
            Obj.Idproducto = idproducto;
            Obj.Idmarca = idmarca;
            Obj.Idempaque = idempaque;
            Obj.Idgrupo = idgrupo;
            Obj.Idtipo = idtipo;

            //Datos Basicos
            Obj.Codigo = codigo;
            Obj.Producto = producto;
            Obj.Referencia = referencia;
            Obj.Descripcion = descripcion;
            Obj.Presentacion = presentacion;
            Obj.Unidad = unidad;
            Obj.Comision = comision;
            Obj.Comision_Porcentaje = comision_porcentaje;

            Obj.ManejaVencimiento = manejavencimiento;
            Obj.ManejaImpuesto = manejaimpuesto;
            Obj.Importado = importado;
            Obj.Exportado = exportado;
            Obj.Ofertable = ofertable;
            Obj.ManejaComision = manejacomision;

            //Valores
            Obj.Compra_Promedio = compra_promedio;
            Obj.Compra_Final = Compra_final;
            Obj.Venta_Excento = Venta_excento;
            Obj.Venta_NoExcento = venta_noexcento;
            Obj.Venta_Mayorista = venta_mayorista;
            Obj.Fabricacion = fabricacion;
            Obj.Materiales = materiales;
            Obj.Exportacion = exportacion;
            Obj.Importacion = importacion;
            Obj.Seguro = seguro;
            Obj.Gastos = gastos;

            //Cantidades
            Obj.Venta_MinimaCliente = venta_minimacliente;
            Obj.Venta_MaximaCliente = venta_maximacliente;
            Obj.Venta_MinimaMayorista = venta_minimamayorista;
            Obj.Venta_MaximaMayorista = venta_maximamayorista;
            Obj.Compra_MinimaCliente = compra_minimacliente;
            Obj.Compra_MaximaCliente = compra_maximacliente;
            Obj.Compra_MinimaMayorista = compra_minimamayorista;
            Obj.Compra_MaximaMayorista = compra_maximamayorista;

            //Panel Lote
            Obj.Detalle_Lote = detalle_lote;

            //Panel Impuestos
            Obj.Detalle_Impuesto = detalle_impuesto;

            //Panel Igualdad
            Obj.Detalle_Igualdad = detalle_igualdad;

            //Panel Proveedor
            Obj.Detalle_Proveedor = detalle_proveedor;

            //Ubicacion[]
            Obj.Detalle_Ubicacion = detalle_ubicacion;

            //Panel Codigo de Barra
            Obj.Detalle_CodigoDeBarra = detalle_codigodebarra;

            //Panel Imagen
            Obj.Imagen = imagen;

            //Datos Auxiliares
            Obj.Auto = auto;

            return Datos.Editar_DatosBasicos(Obj);
        }

        public static string Eliminar(int IDEliminar_SQL, int auto)
        {
            Conexion_Producto Datos = new Conexion_Producto();
            return Datos.Eliminar(IDEliminar_SQL, auto);
        }
    }
}

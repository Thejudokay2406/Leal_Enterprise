using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmInventario_Inicial : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmInventario_Inicial _Instancia;

        public static frmInventario_Inicial GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmInventario_Inicial();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //
        private DataTable DtDetalle = new DataTable();

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo_Obligatorio = "Campo Obligatorio";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        public frmInventario_Inicial()
        {
            InitializeComponent();
        }

        private void frmInventario_Inicial_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBCodigo.Select();

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;
            this.TBIdbodega.Visible = false;
            this.TBIdproveedor.Visible = false;
            this.TBIdsaldoinicial.Visible = false;
            this.TBIddetalle.Visible = false;
        }


        private void Habilitar()
        {
            //Panel - Datos Basicos

            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCodigo_Proveedor.ReadOnly = false;
            this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.Enabled = false;
            this.TBBodega.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCodigo_Bodega.ReadOnly = false;
            this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBProducto.Enabled = false;
            this.TBProducto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCodigo_Producto.ReadOnly = false;
            this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Datos - Parte Inferior del Formulario
            //this.TBCompraPromedio.Enabled = false;
            //this.TBCompraPromedio.BackColor = Color.FromArgb(72, 209, 204);

            //this.TBCompraFinal.Enabled = false;
            //this.TBCompraFinal.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBValorVenta_SinImpuesto.Enabled = false;
            //this.TBValorVenta_SinImpuesto.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBValorVenta.Enabled = false;
            //this.TBValorVenta.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBVentaMayorista.Enabled = false;
            //this.TBVentaMayorista.BackColor = Color.FromArgb(72, 209, 204);

            ////
            //this.TBUbicacion.Enabled = false;
            //this.TBUbicacion.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBMarca.Enabled = false;
            //this.TBMarca.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBEstante.Enabled = false;
            //this.TBEstante.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBNivel.Enabled = false;
            //this.TBNivel.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBUnidad.Enabled = false;
            //this.TBUnidad.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBUnidad_Valor.Enabled = false;
            //this.TBUnidad_Valor.BackColor = Color.FromArgb(72, 209, 204);
            //this.TBUnidad_Valor.ForeColor = Color.FromArgb(255, 255, 255);

            ////
            //this.TBValorPromedio_Final.Enabled = false;
            //this.TBValorPromedio_Final.BackColor = Color.FromArgb(224, 255, 255);
            //this.TBValorCompra_Final.Enabled = false;
            //this.TBValorCompra_Final.BackColor = Color.FromArgb(224, 255, 255);
            //this.TBValorFinalExcento_Final.Enabled = false;
            //this.TBValorFinalExcento_Final.BackColor = Color.FromArgb(224, 255, 255);
            this.TBValorVenta_Final.Enabled = false;
            this.TBValorVenta_Final.BackColor = Color.FromArgb(224, 255, 255);

            //Texboxt de Consulta
            //this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            if (!Digitar)
            {
                //Panel - Datos Basicos

                //this.CBProveedor.SelectedIndex = 0;
                //this.CBComprobante.SelectedIndex = 0;

                //this.TBComprobante.Clear();
                //this.TBValorDeCompra.Clear();
                //this.TBStockInicial.Clear();
                //this.TBStockActual.Clear();

                //Se habilitan los botones a su estado por DEFAULT
                this.Digitar = true;
                this.Botones();
                this.Habilitar();

                //Se realiza el FOCUS al panel y campo de texto iniciales
                this.TBIdproducto.Focus();
            }
        }

        private void Botones()
        {
            if (Digitar)
            {
                ////El boton btnGuardar Mantendra su imagen original
                //this.btnGuardar.Enabled = true;
                //this.btnGuardar.Image = Properties.Resources.BV_Guardar;

                this.btnEliminar.Enabled = false;
                this.btnImprimir.Enabled = false;
            }
            else if (!Digitar)
            {
                ////El boton btnGuardar cambiara su imagen original de Guardar a Editar
                //this.btnGuardar.Enabled = true;
                //this.btnGuardar.Image = Properties.Resources.BV_Editar;

                this.btnEliminar.Enabled = false;
                this.btnImprimir.Enabled = false;
            }
        }

        private void CrearTabla()
        {
            try
            {
                this.DtDetalle.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Descripcion", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Referencia", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Medida", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cajas", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("Unidades", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("Precio de Compra", System.Type.GetType("System.String"));

                //Medidas de las Columnas
                this.DGDetalleDeIngreso.DataSource = this.DtDetalle;

                this.DGDetalleDeIngreso.Columns[0].Visible = false;
                this.DGDetalleDeIngreso.Columns[0].HeaderText = "Idproducto";
                this.DGDetalleDeIngreso.Columns[0].Width = 50;
                this.DGDetalleDeIngreso.Columns[1].HeaderText = "Codigo";
                this.DGDetalleDeIngreso.Columns[1].Width = 150;
                this.DGDetalleDeIngreso.Columns[2].HeaderText = "Descripcion";
                this.DGDetalleDeIngreso.Columns[2].Width = 385;
                this.DGDetalleDeIngreso.Columns[3].HeaderText = "Referencia";
                this.DGDetalleDeIngreso.Columns[3].Width = 150;
                this.DGDetalleDeIngreso.Columns[4].HeaderText = "Medida";
                this.DGDetalleDeIngreso.Columns[4].Width = 74;
                this.DGDetalleDeIngreso.Columns[5].HeaderText = "Cajas";
                this.DGDetalleDeIngreso.Columns[5].Width = 90;
                this.DGDetalleDeIngreso.Columns[6].HeaderText = "Unidades";
                this.DGDetalleDeIngreso.Columns[6].Width = 90;
                this.DGDetalleDeIngreso.Columns[7].HeaderText = "Precio de Compra";
                this.DGDetalleDeIngreso.Columns[7].Width = 140;

                //Se Desabilita las columnas especificadas para evitar la edicion
                //Del Campo por parte del Usuario
                this.DGDetalleDeIngreso.Columns[0].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[1].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[2].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[3].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[4].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[7].ReadOnly = true;

                //Formato de Celdas
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Format = "##,##0.00";
                //this.DGDetalleDeIngreso.Columns[8].DefaultCellStyle.Format = "##,##0.00";
                //this.DGDetalleDeIngreso.Columns[10].DefaultCellStyle.Format = "##,##0.00";
                //this.DGDetalleDeIngreso.Columns[11].DefaultCellStyle.Format = "##,##0.00";

                //Aliniacion de las Celdas de Cada Columna
                this.DGDetalleDeIngreso.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Alineacion de los Encabezados de Cada Columna
                this.DGDetalleDeIngreso.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setProducto(string idproducto, string producto)
        {
            this.TBCodigo_Producto.Text = idproducto;
            this.TBProducto.Text = producto;
        }

        public void setProveedor(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBCodigo_Proveedor.Text = documento;
        }

        public void setBodega(string idbodega, string bodega, string documento)
        {
            this.TBIdbodega.Text = idbodega;
            this.TBBodega.Text = bodega;
            this.TBCodigo_Bodega.Text = documento;
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Agregar_Detalle(int idproducto, string codigo, string nombre, string unidad, string valor_compra)
        {
            try
            {
                bool Agregar = true;
                foreach (DataRow FilaTemporal in DtDetalle.Rows)
                {
                    if (Convert.ToInt32(FilaTemporal["Idproducto"]) == idproducto)
                    {
                        Agregar = false;
                        this.MensajeError("El Producto ya se encuentra agregado en la lista.");
                    }
                }

                if (Agregar)
                {
                    DataRow Fila = DtDetalle.NewRow();
                    Fila["Idproducto"] = idproducto;
                    Fila["Codigo"] = codigo;
                    Fila["Descripcion"] = nombre;
                    Fila["Medida"] = unidad;
                    Fila["Precio de Compra"] = valor_compra;
                    this.DtDetalle.Rows.Add(Fila);

                    //this.Calculo_Totales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Calculo_Totales()
        {
            try
            {
                int Total = 0;
                decimal SubTotal = 0;

                if (DGDetalleDeIngreso.Rows.Count == 0)
                {
                    Total = 0;
                }
                else
                {
                    foreach (DataRow FilaTemporal in DtDetalle.Rows)
                    {
                        Total = Total + Convert.ToInt32(FilaTemporal["Total"]);
                    }

                    //SubTotal = Total/(1+tbimpuesto.text));
                    this.TBValorVenta_Final.Text = Total.ToString("#0.00#");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Guardar_SQL()
        {
            try
            {
                //string rptaDatosBasicos = "";

                //// <<<<<<------ Panel Datos Basicos ------>>>>>

                //if (this.TBTipo.Text == Campo)
                //{
                //    MensajeError("Ingrese el tipo del Cliente a registrar");
                //}
                //else if (this.TBDescripcion.Text == Campo)
                //{
                //    MensajeError("Ingrese la descripcion del Cliente a registrar");
                //}
                //else if (this.TBCodigo.Text == Campo)
                //{
                //    MensajeError("Ingrese el Codigo del tipo de Cliente");
                //}

                //else
                //{
                //    if (this.Digitar)
                //    {
                //        rptaDatosBasicos = fTipoDeCliente.Guardar_DatosBasicos

                //            (
                //                 //Datos Auxiliares
                //                 1,

                //                 //Panel Datos Basicos
                //                 this.TBCodigo.Text, this.TBTipo.Text, this.TBDescripcion.Text, this.TBObservacion.Text,

                //                 //
                //                 1
                //            );
                //    }

                //    else
                //    {
                //        rptaDatosBasicos = fTipoDeCliente.Editar_DatosBasicos

                //            (
                //                 //Datos Auxiliares
                //                 2, Convert.ToInt32(this.TBIdtipodecliente.Text),

                //                 //Panel Datos Basicos
                //                 this.TBCodigo.Text, this.TBTipo.Text, this.TBDescripcion.Text, this.TBObservacion.Text,

                //                 //
                //                 1
                //            );
                //    }

                //    if (rptaDatosBasicos.Equals("OK"))
                //    {
                //        if (this.Digitar)
                //        {
                //            this.MensajeOk("Registro Exitoso");
                //        }

                //        else
                //        {
                //            this.MensajeOk("Registro Actualizado");
                //        }
                //    }

                //    else
                //    {
                //        this.MensajeError(rptaDatosBasicos);
                //    }

                //    //Llamada de Clase
                //    this.Digitar = false;
                //    this.Limpiar_Datos();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }


        private void frmInventario_Inicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}

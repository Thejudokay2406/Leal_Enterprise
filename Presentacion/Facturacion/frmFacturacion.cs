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
    public partial class frmFacturacion : Form
    {
        private DataTable DtDetalle = new DataTable();

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar = "";
        public string Editar = "";
        public string Consultar = "";
        public string Eliminar = "";
        public string Imprimir = "";
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.CrearTabla();

            //Focus a Texboxt y Combobox
            this.TBCodigoID.Focus();

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;
        }
        
        private void Habilitar()
        {
            //Panel - Datos Basicos

            this.TBCodigoID.ReadOnly = false;
            this.TBCodigoID.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Proveedor.ReadOnly = false;
            this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCodigo_Bodega.ReadOnly = false;
            this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.Enabled = false;
            this.TBBodega.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCodigo_Producto.ReadOnly = false;
            this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);
            this.CBMoneda.Enabled = true;
            this.CBMoneda.BackColor = Color.FromArgb(3, 155, 229);
            this.CBComprobante.Enabled = false;
            this.CBComprobante.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
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
                this.btnCancelar.Enabled = false;
                this.btnImprimir.Enabled = false;
            }
            else if (!Digitar)
            {
                ////El boton btnGuardar cambiara su imagen original de Guardar a Editar
                //this.btnGuardar.Enabled = true;
                //this.btnGuardar.Image = Properties.Resources.BV_Editar;

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
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
                this.DtDetalle.Columns.Add("Medida", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cajas", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("U. Cajas", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("U. Total", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("P. Compra", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("P. Venta", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("Descuento", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("P. Descontado", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("P. Total", System.Type.GetType("System.Int32"));

                //Medidas de las Columnas
                this.DGDetalleDeIngreso.DataSource = this.DtDetalle;

                this.DGDetalleDeIngreso.Columns[0].Visible = false;
                this.DGDetalleDeIngreso.Columns[0].HeaderText = "Idproducto";
                this.DGDetalleDeIngreso.Columns[0].Width = 70;
                this.DGDetalleDeIngreso.Columns[1].HeaderText = "Codigo";
                this.DGDetalleDeIngreso.Columns[1].Width = 130;
                this.DGDetalleDeIngreso.Columns[2].HeaderText = "Descripcion";
                this.DGDetalleDeIngreso.Columns[2].Width = 300;
                this.DGDetalleDeIngreso.Columns[3].HeaderText = "Medida";
                this.DGDetalleDeIngreso.Columns[3].Width = 55;
                this.DGDetalleDeIngreso.Columns[4].HeaderText = "Cajas";
                this.DGDetalleDeIngreso.Columns[4].Width = 65;
                this.DGDetalleDeIngreso.Columns[5].HeaderText = "U. Cajas";
                this.DGDetalleDeIngreso.Columns[5].Width = 80;
                this.DGDetalleDeIngreso.Columns[6].HeaderText = "U. Total";
                this.DGDetalleDeIngreso.Columns[6].Width = 80;
                this.DGDetalleDeIngreso.Columns[7].HeaderText = "P. Compra";
                this.DGDetalleDeIngreso.Columns[7].Width = 90;
                this.DGDetalleDeIngreso.Columns[8].HeaderText = "P. Venta";
                this.DGDetalleDeIngreso.Columns[8].Width = 90;
                this.DGDetalleDeIngreso.Columns[9].HeaderText = "Descuento";
                this.DGDetalleDeIngreso.Columns[9].Width = 65;
                this.DGDetalleDeIngreso.Columns[10].HeaderText = "P. Descontado";
                this.DGDetalleDeIngreso.Columns[10].Width = 110;
                this.DGDetalleDeIngreso.Columns[11].HeaderText = "P. Total";
                this.DGDetalleDeIngreso.Columns[11].Width = 85;

                //Se Desabilita las columnas especificadas para evitar la edicion
                //Del Campo por parte del Usuario
                this.DGDetalleDeIngreso.Columns[0].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[1].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[2].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[3].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[6].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[10].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[11].ReadOnly = true;

                //Formato de Celdas
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalleDeIngreso.Columns[8].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalleDeIngreso.Columns[10].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalleDeIngreso.Columns[11].DefaultCellStyle.Format = "##,##0.00";

                //Aliniacion de las Celdas de Cada Columna
                this.DGDetalleDeIngreso.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Alineacion de los Encabezados de Cada Columna
                this.DGDetalleDeIngreso.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setProducto(string Idproducto)
        {
            this.TBCodigo_Producto.Text = Idproducto;
        }

        public void setProveedor(string idproveedor, string proveedor, string documento)
        {
            this.TBIdproveedor.Text = idproveedor;
            this.TBProveedor.Text = proveedor;
            this.TBCodigo_Proveedor.Text = documento;
        }

        public void setBodega(string idbodega, string bodega)
        {
            this.TBIdbodega.Text = idbodega;
            this.TBBodega.Text = bodega;
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


        public void Agregar_Detalle(int idproducto, string codigo, string nombre, string unidad, string valor_compra, string valor_venta)
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
                    Fila["P. Compra"] = valor_compra;
                    Fila["P. Venta"] = valor_venta;
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
                    lblTotalIngresado.Text = Total.ToString("#0.00#");
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


        private void DGDetalleDeIngreso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int cantidad = 0;
                int Descuento = 0;
                int Porcentaje = 0;
                decimal precio_unit = 0;
                decimal precio_total = 0;
                decimal Sub_Total = 0;
                decimal General_Total = 0;
                decimal Precio_Venta = 0;
                decimal Porcentaje_Total = 0;
                decimal Divisor = 100;

                if (DGDetalleDeIngreso.Columns[e.ColumnIndex].Name == "U. Cajas")
                {
                    try
                    {
                        cantidad = int.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[4].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Debe ingresar una cantidad !");
                    }
                    try
                    {
                        precio_unit = decimal.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Debe ingresar un precio !");
                    }
                    if (!(cantidad == 0) && !(precio_unit == 0))
                    {
                        precio_total = cantidad * precio_unit;
                        DGDetalleDeIngreso.Rows[e.RowIndex].Cells[6].Value = precio_total;
                    }
                }

                if (DGDetalleDeIngreso.Columns[e.ColumnIndex].Name == "Descuento")
                {
                    try
                    {
                        Descuento = int.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[9].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ingrese un descuento si este llega aplicar");
                    }

                    try
                    {
                        Precio_Venta = decimal.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[8].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Debe Ingresar el Valor de Venta al Publico");
                    }

                    //Si la columna descuento tiene algun valor aplicado es decir 
                    //Un descuento o porcentaje aplicado se realizara la siguiente validacion

                    if (Descuento != 0)
                    {
                        Porcentaje_Total = Precio_Venta * Descuento / Divisor;
                        Sub_Total = Precio_Venta - Porcentaje_Total;

                        DGDetalleDeIngreso.Rows[e.RowIndex].Cells[11].Value = Sub_Total;

                        // Se calcula el valor total final 
                        General_Total = Precio_Venta - Sub_Total;

                        DGDetalleDeIngreso.Rows[e.RowIndex].Cells[10].Value = General_Total;

                    }

                    else if (Descuento == 0)
                    {
                        DGDetalleDeIngreso.Rows[e.RowIndex].Cells[10].Value = Precio_Venta;

                        if (Sub_Total == 0)
                        {

                            //Si no se aplica ningun descuento se realizara lo siguiente. Lo cual es un calculo total sin descuento alguno
                            General_Total = Precio_Venta - Descuento;

                            DGDetalleDeIngreso.Rows[e.RowIndex].Cells[11].Value = General_Total;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

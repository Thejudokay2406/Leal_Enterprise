using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;

namespace Presentacion
{
    public partial class frmInventario_Ingreso : Form
    {
        private static frmInventario_Ingreso _Instancia;

        public static frmInventario_Ingreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmInventario_Ingreso();
            }
            return _Instancia;
        }

        private DataTable DtDetalle = new DataTable();

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        public frmInventario_Ingreso()
        {
            InitializeComponent();
        }

        private void frmInventario_Ingreso_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.CrearTabla();

            this.TBValorPromedio_Final.ForeColor = Color.White;

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
            this.TBCompraPromedio.Enabled = false;
            this.TBCompraPromedio.BackColor = Color.FromArgb(72, 209, 204);
            
            this.TBCompraFinal.Enabled = false;
            this.TBCompraFinal.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorVenta_SinImpuesto.Enabled = false;
            this.TBValorVenta_SinImpuesto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorVenta.Enabled = false;
            this.TBValorVenta.BackColor = Color.FromArgb(72, 209, 204);
            this.TBVentaMayorista.Enabled = false;
            this.TBVentaMayorista.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBUbicacion.Enabled = false;
            this.TBUbicacion.BackColor = Color.FromArgb(72, 209, 204);
            this.TBMarca.Enabled = false;
            this.TBMarca.BackColor = Color.FromArgb(72, 209, 204);
            this.TBEstante.Enabled = false;
            this.TBEstante.BackColor = Color.FromArgb(72, 209, 204);
            this.TBNivel.Enabled = false;
            this.TBNivel.BackColor = Color.FromArgb(72, 209, 204);
            this.TBUnidad.Enabled = false;
            this.TBUnidad.BackColor = Color.FromArgb(72, 209, 204);
            this.TBUnidad_Valor.Enabled = false;
            this.TBUnidad_Valor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBUnidad_Valor.ForeColor = Color.FromArgb(255, 255, 255);

            //
            this.TBValorPromedio_Final.Enabled = false;
            this.TBValorPromedio_Final.BackColor = Color.FromArgb(224, 255, 255);
            this.TBValorCompra_Final.Enabled = false;
            this.TBValorCompra_Final.BackColor = Color.FromArgb(224, 255, 255);
            this.TBValorFinalExcento_Final.Enabled = false;
            this.TBValorFinalExcento_Final.BackColor = Color.FromArgb(224, 255, 255);
            this.TBValorVenta_Final.Enabled = false;
            this.TBValorVenta_Final.BackColor = Color.FromArgb(224, 255, 255);
            
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

        
        private void TBProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode==Keys.Enter)
                //{
                //    DataTable Tabla = new DataTable();
                //    Tabla = fProductos.Buscar(this.TBProducto.Text.Trim(), 4);
                //    if (Tabla.Rows.Count <= 0)
                //    {
                //        this.MensajeError("no existe");
                //    }
                //    else
                //    {
                //        this.Agregar_Detalle
                //            (
                //                Convert.ToInt32(Tabla.Rows[0][1]),
                //                Convert.ToString(Tabla.Rows[0][2]),
                //                Convert.ToInt32(Tabla.Rows[0][3])
                //                //Convert.ToInt32(Tabla.Rows[0][3]),
                //                //Convert.ToInt32(Tabla.Rows[0][4])
                //            ); 
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (Guardar == "1")
                    {
                        frmGastosDeIngreso frmGastosDeIngreso = new frmGastosDeIngreso();
                        frmGastosDeIngreso.ShowDialog();
                        //Metodo Guardar y editar
                        //this.Guardar_SQL();
                    }

                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = false;
                        this.Limpiar_Datos();
                    }
                }

                else
                {
                    if (Editar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Digitar = false;
                        this.Limpiar_Datos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Proveedor_Click(object sender, EventArgs e)
        {
            frmFiltro_Proveedor frmFiltro_Proveedor = new frmFiltro_Proveedor();
            frmFiltro_Proveedor.ShowDialog();
        }

        private void btnExaminar_Bodega_Click(object sender, EventArgs e)
        {
            frmFiltro_Bodega frmFiltro_Bodega = new frmFiltro_Bodega();
            frmFiltro_Bodega.Show();
        }

        private void btnExaminar_Producto_Click(object sender, EventArgs e)
        {
            frmFiltro_Producto frmFiltro_Producto = new frmFiltro_Producto();
            frmFiltro_Producto.ShowDialog();
        }

        private void btnExaminar_Moneda_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Comprobante_Click(object sender, EventArgs e)
        {

        }

        private void TBCodigo_Moneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (e.KeyChar == Convert.ToChar(Keys.Enter))
                //{
                //    DataTable Tabla = new DataTable();
                //    Tabla = fProductos.Buscar(this.TBCodigo_Producto.Text.Trim(), 4);
                //    if (Tabla.Rows.Count <= 0)
                //    {
                //        this.MensajeError("El producto el cual desea agregar no se encuentra registrado en su Base de Datos");
                //    }
                //    else
                //    {
                //        this.Agregar_Detalle
                //            (
                //                Convert.ToInt32(Tabla.Rows[0][0]),
                //                Convert.ToString(Tabla.Rows[0][1]),
                //                Convert.ToString(Tabla.Rows[0][2]),
                //                Convert.ToInt32(Tabla.Rows[0][3])
                //            );
                //        this.TBCodigo_Producto.Clear();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCodigo_Producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    DataTable Tabla = new DataTable();
                    Tabla = fProductos.Buscar(this.TBCodigo_Producto.Text.Trim(), 4);
                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("El producto el cual desea agregar no se encuentra registrado en su Base de Datos");
                    }
                    else
                    {
                        this.Agregar_Detalle
                            (
                                Convert.ToInt32(Tabla.Rows[0][0]),
                                Convert.ToString(Tabla.Rows[0][1]),
                                Convert.ToString(Tabla.Rows[0][2]),
                                Convert.ToString(Tabla.Rows[0][3]),
                                Convert.ToString(Tabla.Rows[0][4])
                            );

                        lblTotal.Text = "Productos Ingresados: " + Convert.ToString(DGDetalleDeIngreso.Rows.Count);

                        //Se procede a sumar la columna de valor de compra promedio

                        double total = 0;
                        foreach (DataGridViewRow row in DGDetalleDeIngreso.Rows)
                        {
                            total += Convert.ToDouble(row.Cells[7].Value);
                        }
                        TBValorPromedio_Final.Text = Convert.ToString(total);

                        //Se procede a limpiar los campos de texto utilizados para el Filtro

                        this.TBCodigo_Producto.Clear();
                        this.TBProducto.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCodigoID_Enter(object sender, EventArgs e)
        {
            this.TBCodigoID.BackColor = Color.Azure;
        }

        private void TBCodigo_Proveedor_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Proveedor.BackColor = Color.Azure;
        }

        private void TBCodigo_Bodega_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Bodega.BackColor = Color.Azure;
        }

        private void TBCodigo_Producto_Enter(object sender, EventArgs e)
        {
            this.TBCodigo_Producto.BackColor = Color.Azure;
        }

        private void TBProveedor_Enter(object sender, EventArgs e)
        {
            this.TBProveedor.BackColor = Color.Azure;
        }

        private void TBBodega_Enter(object sender, EventArgs e)
        {
            this.TBBodega.BackColor = Color.Azure;
        }
      
        private void TBCodigo_Proveedor_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigoID_Leave(object sender, EventArgs e)
        {
            this.TBCodigoID.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBProveedor_Leave(object sender, EventArgs e)
        {
            this.TBProveedor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBodega_Leave(object sender, EventArgs e)
        {
            this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_Bodega_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_Producto_Leave(object sender, EventArgs e)
        {
            this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void frmInventario_Ingreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void DGDetalleDeIngreso_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.Calculo_Totales();
        }

        private void TBCodigo_Proveedor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    DataTable Tabla = new DataTable();
                    Tabla = fProveedor.Buscar(this.TBCodigo_Bodega.Text.Trim(), 1);
                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("El proveedor que desea agregar no se encuentra registrada en su Base de Datos");
                    }
                    else
                    {
                        //Captura de Valores en la Base de Datos
                        this.TBProveedor.Text = Convert.ToString(Tabla.Rows[0][1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCodigo_Bodega_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    DataTable Tabla = new DataTable();
                    Tabla = fBodega.Buscar(this.TBCodigo_Bodega.Text.Trim(), 1);
                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("La Bodega que desea agregar no se encuentra registrada en su Base de Datos");
                    }
                    else
                    {
                        this.TBBodega.Text = Convert.ToString(Tabla.Rows[0][1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGDetalleDeIngreso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TBUnidad.Text = DGDetalleDeIngreso.CurrentRow.Cells[4].Value.ToString();
                this.TBCompraPromedio.Text = DGDetalleDeIngreso.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCompraPromedio_Leave(object sender, EventArgs e)
        {
            
        }

        private void TBCompraPromedio_Enter(object sender, EventArgs e)
        {
            this.TBCompraPromedio.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}

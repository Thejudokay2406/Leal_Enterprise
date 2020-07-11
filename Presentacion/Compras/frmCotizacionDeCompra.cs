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
    public partial class frmCotizacionDeCompra : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmCotizacionDeCompra _Instancia;

        public static frmCotizacionDeCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmCotizacionDeCompra();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variable para Agregar los Detalles a la Base de Datos
        private DataTable DtDetalle = new DataTable();

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo = "Campo Obligatorio";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        public frmCotizacionDeCompra()
        {
            InitializeComponent();
        }

        private void frmCotizacionDeCompra_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.CrearTabla();
            this.AutoCompletar_Combobox();

            //Focus a Texboxt y Combobox
            this.TBCodigo.Select();

            //Ocultacion de Texboxt
            //this.TBIdproducto.Visible = false;
            //this.TBIdbodega.Visible = false;
            //this.TBIdproveedor.Visible = false;
            this.TBIddetalle.Visible = false;
        }


        private void Habilitar()
        {

            //Panel - Datos Basicos

            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo.Text = Campo;
            this.TBCodigo_Proveedor.ReadOnly = false;
            this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Proveedor.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo_Proveedor.Text = Campo;
            this.TBCodigo_Producto.ReadOnly = false;
            this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Producto.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo_Producto.Text = Campo;
            this.TBCodigo_Bodega.ReadOnly = false;
            this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo_Bodega.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo_Bodega.Text = Campo;
            this.TBCodigo_Almacen.Enabled = false;
            this.TBCodigo_Almacen.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBOrdendecompra.Enabled = false;
            this.TBOrdendecompra.BackColor = Color.FromArgb(72, 209, 204);
            this.TBBodega.Enabled = false;
            this.TBBodega.BackColor = Color.FromArgb(72, 209, 204);
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBProducto.Enabled = false;
            this.TBProducto.BackColor = Color.FromArgb(72, 209, 204);
            this.TBAlmacen.Enabled = false;
            this.TBAlmacen.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCreditoEnMora.ReadOnly = false;
            this.TBCreditoEnMora.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCreditoDisponible.ReadOnly = false;
            this.TBCreditoDisponible.BackColor = Color.FromArgb(3, 155, 229);

            //Valores Finales
            this.TBSubTotal.Enabled = false;
            this.TBSubTotal.BackColor = Color.FromArgb(255, 255, 255);
            this.TBDescuento.ReadOnly = false;
            this.TBDescuento.BackColor = Color.FromArgb(255, 255, 255);
            this.TBValorFinal.Enabled = false;
            this.TBValorFinal.BackColor = Color.FromArgb(255, 255, 255);

            //
            this.TBDescuento.Text = "0";
        }

        private void Limpiar_Datos()
        {
            if (!Digitar)
            {
                //Panel - Datos Basicos

                this.TBIdbodega.Clear();
                this.TBIddetalle.Clear();
                this.TBIdproducto.Clear();
                this.TBIdproveedor.Clear();

                this.TBCodigo.Clear();
                this.TBCodigo.Text = Campo;
                this.TBCodigo_Bodega.Clear();
                this.TBCodigo_Bodega.Text = Campo;
                this.TBCodigo_Producto.Clear();
                this.TBCodigo_Producto.Text = Campo;
                this.TBCodigo_Proveedor.Clear();
                this.TBCodigo_Proveedor.Text = Campo;
                this.TBCodigo_Almacen.Clear();
                this.TBAlmacen.Clear();
                this.TBBodega.Clear();
                this.TBOrdendecompra.Clear();
                this.TBProducto.Clear();
                this.TBProveedor.Clear();
                this.TBCreditoEnMora.Clear();
                this.TBCreditoDisponible.Clear();

                //
                this.TBSubTotal.Clear();
                this.TBValorFinal.Clear();

                //Se procede a limpiar la Tabla de Detalles
                this.DGDetalles.DataSource = null;

                //Se habilitan los botones a su estado por DEFAULT
                this.Digitar = true;
                this.Botones();
                this.Habilitar();

                //Se realiza el FOCUS al panel y campo de texto iniciales
                this.TBCodigo.Select();
            }
        }

        private void Botones()
        {
            if (Digitar)
            {
                //Se procede a habilitar los botones de operacion para realizar registros en el sistema
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnCancelar.Enabled = false;
                this.btnImprimir.Enabled = false;
            }
            else if (!Digitar)
            {
                //Se procede a habilitar los botones de operacion para Editar registros en el sistema
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnCancelar.Enabled = true;
                this.btnEliminar_Detalles.Enabled = true;
            }
        }

        private void AutoCompletar_Combobox()
        {
            try
            {
                this.CBTipodepago.DataSource = fTipoDePago.Lista();
                this.CBTipodepago.ValueMember = "Codigo";
                this.CBTipodepago.DisplayMember = "Tipo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Auto_CodigoAlmacen()
        {
            try
            {
                DataTable Datos = Negocio.fBodega.Buscar(this.TBCodigo_Bodega.Text.Trim(), 4);
                if (Datos.Rows.Count <= 0)
                {
                    this.MensajeError("La Bodega que desea agregar no se encuentra registrada en su Base de Datos");
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    this.TBIdbodega.Text = Datos.Rows[0][0].ToString();
                    this.TBBodega.Text = Datos.Rows[0][1].ToString();
                    this.TBCodigo_Almacen.Text = Datos.Rows[0][2].ToString();
                    this.TBAlmacen.Text = Datos.Rows[0][3].ToString();
                    this.TBCodigo_Almacen.Text = Datos.Rows[0][4].ToString();

                    this.lblTotal_Detalles.Text = "Productos Agregados: " + Convert.ToString(DGDetalles.Rows.Count);

                    //Se procede a limpiar los campos de texto utilizados para el Filtro

                    this.TBCodigo_Producto.Clear();
                    this.TBProducto.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CrearTabla()
        {
            try
            {
                this.DGDetalles.DataSource = this.DtDetalle;

                this.DtDetalle.Columns.Add("Idproducto", System.Type.GetType("System.Int32"));
                this.DtDetalle.Columns.Add("Codigo", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Descripción", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Medida", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cajas", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Unidad", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("V. Compra", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Total", System.Type.GetType("System.String"));

                //Medidas de las Columnas
                this.DGDetalles.Columns[0].Visible = false;
                this.DGDetalles.Columns[1].Visible = false;
                this.DGDetalles.Columns[0].HeaderText = "Idproducto";
                this.DGDetalles.Columns[1].HeaderText = "Codigo";
                this.DGDetalles.Columns[2].HeaderText = "Descripción";
                this.DGDetalles.Columns[2].Width = 280;
                this.DGDetalles.Columns[3].HeaderText = "Medida";
                this.DGDetalles.Columns[3].Width = 60;
                this.DGDetalles.Columns[4].HeaderText = "Cajas";
                this.DGDetalles.Columns[4].Width = 60;
                this.DGDetalles.Columns[5].HeaderText = "Unidad";
                this.DGDetalles.Columns[5].Width = 60;
                this.DGDetalles.Columns[6].HeaderText = "Cantidad";
                this.DGDetalles.Columns[6].Width = 60;
                this.DGDetalles.Columns[7].HeaderText = "V. Compra";
                this.DGDetalles.Columns[7].Width = 110;
                this.DGDetalles.Columns[8].HeaderText = "Total";
                this.DGDetalles.Columns[8].Width = 110;

                //Se Desabilita las columnas especificadas para evitar la edicion
                //Del Campo por parte del Usuario
                this.DGDetalles.Columns[0].ReadOnly = true;
                this.DGDetalles.Columns[1].ReadOnly = true;
                this.DGDetalles.Columns[2].ReadOnly = true;
                this.DGDetalles.Columns[3].ReadOnly = true;
                this.DGDetalles.Columns[4].ReadOnly = false;
                this.DGDetalles.Columns[5].ReadOnly = false;
                this.DGDetalles.Columns[6].ReadOnly = true;
                this.DGDetalles.Columns[7].ReadOnly = false;
                this.DGDetalles.Columns[8].ReadOnly = true;

                //Formato de Celdas
                this.DGDetalles.Columns[7].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalles.Columns[8].DefaultCellStyle.Format = "##,##0.00";

                //Aliniacion de las Celdas de Cada Columna
                this.DGDetalles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Alineacion de los Encabezados de Cada Columna
                this.DGDetalles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalles.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


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

        public void Auto_Texboxt()
        {
            try
            {
                //Variables Para Los Filtros
                string subtotal, descuento, valorgeneral, creditomora, creditodisponible;
                
                //
                frmTotalizar_CotizacionDeCompra form = frmTotalizar_CotizacionDeCompra.GetInstancia();
                subtotal = this.TBSubTotal.Text;
                descuento = this.TBDescuento.Text;
                valorgeneral = this.TBValorFinal.Text;
                creditomora = this.TBCreditoEnMora.Text;
                creditodisponible = this.TBCreditoDisponible.Text;
                form.setFiltro(subtotal, descuento, valorgeneral, creditomora, creditodisponible);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void Agregar_Detalle(int idproducto, string codigo, string nombre, string medida, string valor_compra)
        {
            try
            {
                //
                double Cantidad = 0;
                double Valor_Compra = 0;
                double Operacion = 0;
                double Caja = 0;
                double Unidad = 0;

                bool Agregar = true;
                foreach (DataRow FilaTemporal in DtDetalle.Rows)
                {
                    if (Convert.ToInt32(FilaTemporal["Idproducto"]) == idproducto)
                    {
                        Agregar = false;
                        this.MensajeError("El Producto ya se encuentra agregado en la lista.");
                    }
                }

                Operacion = Cantidad * Valor_Compra;

                if (Agregar)
                {
                    DataRow Fila = DtDetalle.NewRow();
                    Fila["Idproducto"] = idproducto;
                    Fila["Codigo"] = codigo;
                    Fila["Descripción"] = nombre;
                    Fila["Medida"] = medida;
                    Fila["Cajas"] = Caja;
                    Fila["Unidad"] = Unidad;
                    Fila["Cantidad"] = Cantidad;
                    Fila["V. Compra"] = valor_compra;
                    Fila["Total"] = Operacion;
                    this.DtDetalle.Rows.Add(Fila);

                    //
                    this.Calculo_Totales();
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
                double SubTotal = 0;
                double Descuento = 0;
                double Operacion = 0;
                double Porcentaje = 0;

                //Se procede a sumar la columna de valor de compra promedio

                foreach (DataGridViewRow row in DGDetalles.Rows)
                {
                    SubTotal += Convert.ToDouble(row.Cells[7].Value);
                }
                
                //
                this.TBSubTotal.Text= Convert.ToString(SubTotal);

                Descuento = Convert.ToDouble(this.TBDescuento.Text);
                Porcentaje = SubTotal * Descuento / 100;
                Operacion = SubTotal - Porcentaje;

                //Se les da Formato a los campo de texto en este caso con Miles y Dos Decimales
                this.TBSubTotal.Text = Operacion.ToString("##,##0.00");
                this.TBValorFinal.Text = Operacion.ToString("##,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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
        
        public void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Por favor ingrese el Codigo de la Cotizacion a Registrar");
                }
                else if (this.TBCodigo_Bodega.Text == Campo)
                {
                    MensajeError("Por favor ingrese La Bodega de Almacenamiento");
                }
                else if (this.TBCodigo_Proveedor.Text == Campo)
                {
                    MensajeError("Por favor ingreso el nombre del Proveedor");
                }

                else
                {
                    if (this.Digitar)
                    {
                        if (TBIdordendecompra.Text == string.Empty)
                        {
                            this.TBIdordendecompra.Text = "0";
                        }

                        //Se establece la variable para poder utilizar los campos de texto del segundo formulario
                        frmTotalizar_CotizacionDeCompra frmTotCoti = frmTotalizar_CotizacionDeCompra.GetInstancia();

                        rptaDatosBasicos = fCotizacion_Compra.Guardar_DatosBasicos

                            (
                                 //Panel Datos Basicos
                                 Convert.ToInt32(this.TBIdbodega.Text), Convert.ToInt32(this.TBIdproveedor.Text), Convert.ToInt32(this.CBTipodepago.SelectedValue),Idempleado, this.TBCodigo.Text, this.TBCodigo_Almacen.Text, this.TBAlmacen.Text,

                                 //Formulario de Totalizacion
                                 frmTotCoti.TBSubTotal.Text, frmTotCoti.TBDescuento_Porcentaje.Text, frmTotCoti.TBDescuento.Text, frmTotCoti.TBImpuesto_Valor.Text, frmTotCoti.TBValorGeneral.Text, frmTotCoti.TBCreditoMora.Text, frmTotCoti.TBCreditoDisponible.Text, frmTotCoti.TBValorDeEnvio.Text, frmTotCoti.TBTipoDePago.Text, frmTotCoti.TBDiasDeEntrega.Text, Convert.ToInt32(frmTotCoti.Vencimiento), frmTotCoti.dateTimePicker3.Value, DtDetalle,

                                 //Datos Auxiliares
                                 1
                            );
                    }

                    //else
                    //{
                    //    rptaDatosBasicos = fCotizacion_Compra.Editar_DatosBasicos

                    //        (
                    //             Datos Auxiliares
                    //             2, Convert.ToInt32(this.TBIdtipodecliente.Text),

                    //             Panel Datos Basicos
                    //             this.TBCodigo.Text, this.TBTipo.Text, this.TBDescripcion.Text, this.TBObservacion.Text,


                    //             1
                    //        );
                    //}

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Registro Exitoso");
                        }

                        //else
                        //{
                        //    this.MensajeOk("Registro Actualizado");
                        //}
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = false;
                    this.Limpiar_Datos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fCotizacion_Compra.Buscar(this.TBBuscar.Text, 1);
                        this.DGResultados.Columns[0].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar_Resultados.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {
                        this.Limpiar_Datos();

                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
                        this.DGResultados.Enabled = false;
                        this.lblTotal.Text = "Datos Registrados: 0";

                        this.btnEliminar_Resultados.Enabled = false;
                        this.btnImprimir.Enabled = false;
                    }
                }

                else
                {
                    MessageBox.Show(" El Usuario Iniciado no Contiene Permisos Para Realizar Consultas", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBFechas_CheckedChanged(object sender, EventArgs e)
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
            frmFiltro_Bodega.ShowDialog();
        }

        private void btnExaminar_Producto_Click(object sender, EventArgs e)
        {
            frmFiltro_Producto frmFiltro_Producto = new frmFiltro_Producto();
            frmFiltro_Producto.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Por favor ingrese el Codigo de la Cotizacion a Registrar");
                }
                else if (this.TBCodigo_Bodega.Text == Campo)
                {
                    MensajeError("Por favor ingrese La Bodega de Almacenamiento");
                }
                else if (this.TBCodigo_Proveedor.Text == Campo)
                {
                    MensajeError("Por favor ingreso el nombre del Proveedor");
                }

                else
                {
                    if (Digitar)
                    {
                        if (Guardar == "1")
                        {
                            frmTotalizar_CotizacionDeCompra frmTotalizar_CotizacionDeCompra = frmTotalizar_CotizacionDeCompra.GetInstancia();
                            frmTotalizar_CotizacionDeCompra.ShowDialog();

                            ////Metodo Guardar y editar
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


                        //if (Editar == "1")
                        //{
                        //    //Metodo Guardar y editar
                        //    this.Guardar_SQL();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //    //Llamada de Clase
                        //    this.Digitar = false;
                        //    this.Limpiar_Datos();
                        //}
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

        private void btnEliminar_Detalles_Click(object sender, EventArgs e)
        {
            try
            {
                DGDetalles.Rows.RemoveAt(DGDetalles.CurrentRow.Index);

                this.Calculo_Totales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

                        lblTotal_Detalles.Text = "Productos Agregados: " + Convert.ToString(DGDetalles.Rows.Count);

                        //Se procede a limpiar los campos de texto utilizados para el Filtro

                        this.TBCodigo.Clear();
                        this.TBOrdendecompra.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCodigo_Proveedor_KeyPress(object sender, KeyPressEventArgs e)
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

                        lblTotal_Detalles.Text = "Productos Agregados: " + Convert.ToString(DGDetalles.Rows.Count);

                        //Se procede a limpiar los campos de texto utilizados para el Filtro

                        this.TBCodigo_Proveedor.Clear();
                        this.TBProveedor.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCodigo_Bodega_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    this.Auto_CodigoAlmacen();
                }
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

                        lblTotal_Detalles.Text = "Productos Agregados: " + Convert.ToString(DGDetalles.Rows.Count);

                        ////Se procede a sumar la columna de valor de compra promedio

                        //double total = 0;
                        //foreach (DataGridViewRow row in DGDetalles.Rows)
                        //{
                        //    total += Convert.ToDouble(row.Cells[6].Value);
                        //}

                        //this.TBValorFinal.Text = total.ToString("##,##0.00");

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

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo.Text == Campo)
            {
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCodigo_Proveedor_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo_Proveedor.Text == Campo)
            {
                this.TBCodigo_Proveedor.BackColor = Color.Azure;
                this.TBCodigo_Proveedor.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo_Proveedor.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo_Proveedor.BackColor = Color.Azure;
                this.TBCodigo_Proveedor.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCodigo_Bodega_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo_Bodega.Text == Campo)
            {
                this.TBCodigo_Bodega.BackColor = Color.Azure;
                this.TBCodigo_Bodega.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo_Bodega.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo_Bodega.BackColor = Color.Azure;
                this.TBCodigo_Bodega.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCodigo_Producto_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo_Producto.Text == Campo)
            {
                this.TBCodigo_Producto.BackColor = Color.Azure;
                this.TBCodigo_Producto.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo_Producto.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo_Producto.BackColor = Color.Azure;
                this.TBCodigo_Producto.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDescripcion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBOrdendecompra.Text == Campo)
            {
                this.TBOrdendecompra.BackColor = Color.Azure;
                this.TBOrdendecompra.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBOrdendecompra.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBOrdendecompra.BackColor = Color.Azure;
                this.TBOrdendecompra.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            if (TBCodigo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo.Text = Campo;
                this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCodigo_Proveedor_Leave(object sender, EventArgs e)
        {
            if (TBCodigo_Proveedor.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo_Proveedor.Text = Campo;
                this.TBCodigo_Proveedor.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCodigo_Proveedor.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCodigo_Bodega_Leave(object sender, EventArgs e)
        {
            if (TBCodigo_Bodega.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo_Bodega.Text = Campo;
                this.TBCodigo_Bodega.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCodigo_Bodega.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBCodigo_Producto_Leave(object sender, EventArgs e)
        {
            if (TBCodigo_Producto.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo_Producto.Text = Campo;
                this.TBCodigo_Producto.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCodigo_Producto.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            if (TBOrdendecompra.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBOrdendecompra.BackColor = Color.FromArgb(3, 155, 229);
                this.TBOrdendecompra.Text = Campo;
                this.TBOrdendecompra.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBOrdendecompra.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void frmCotizacionDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void DGDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //
                int cantidad = 0;
                double precio_unit = 0;
                double precio_total = 0;
                
                if (DGDetalles.Columns[e.ColumnIndex].Name == "Cantidad")
                {
                    try
                    {
                        cantidad = int.Parse(DGDetalles.Rows[e.RowIndex].Cells[4].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese la Cantidad a Cotizar");
                    }

                    try
                    {
                        precio_unit = double.Parse(DGDetalles.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese el Valor de Compra");
                    }

                    if (!(cantidad == 0) && !(precio_unit == 0))
                    {
                        precio_total = cantidad * precio_unit;
                        this.DGDetalles.Rows[e.RowIndex].Cells[6].Value = precio_total.ToString("##,##0.00");

                        this.Calculo_Totales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    double SubTotal;
                    double Descuento;
                    double Operacion = 0;
                    double Porcentaje;

                    //
                    Descuento = Convert.ToDouble(this.TBDescuento.Text);
                    SubTotal = Convert.ToDouble(this.TBSubTotal.Text);
                    Porcentaje = SubTotal * Descuento / 100;
                    Operacion = SubTotal - Porcentaje;

                    //Se les da Formato a los campo de texto en este caso con Miles y Dos Decimales
                    //this.TBSubTotal.Text = Operacion.ToString("##,##0.00");
                    this.TBValorFinal.Text = Operacion.ToString("##,##0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Auto_CodigoAlmacen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBDescuento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDescuento.Text == "0")
            {
                this.TBDescuento.BackColor = Color.Azure;
                this.TBDescuento.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDescuento.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDescuento.BackColor = Color.Azure;
                this.TBDescuento.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDescuento_Leave(object sender, EventArgs e)
        {
            if (TBDescuento.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDescuento.BackColor = Color.FromArgb(255, 255, 255);
                this.TBDescuento.Text = "0";
                //this.TBDescuento.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBDescuento.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void btnEliminar_Resultados_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void DGDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

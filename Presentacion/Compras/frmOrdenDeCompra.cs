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
    public partial class frmOrdenDeCompra : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmOrdenDeCompra _Instancia;

        public static frmOrdenDeCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmOrdenDeCompra();
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
        private string Campo = "Campo Obligatorio";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Variable para Filtrar los Datos de los Productos en SQL *******************************
        private string Marca, Grupo, Referencia, Stock = "";
        private string ValorPromedio, ValorCompra, ValorVenta = "";

        public frmOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void frmOrdenDeCompra_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.CrearTabla();
            this.AutoCompletar_Combobox();

            //Focus a Texboxt y Combobox
            this.TBCodigo.Select();

            //Ocultacion de Texboxt
            this.TBIdbodega.Visible = false;
            this.TBIddetalle.Visible = false;
            this.TBIdproducto.Visible = false;
            this.TBIdproveedor.Visible = false;
            this.TBIdcotizacion.Visible = false;
            this.TBIdordendecompra.Visible = false;
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
            this.TBCreditoEnMora.ReadOnly = false;
            this.TBCreditoEnMora.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCreditoDisponible.ReadOnly = false;
            this.TBCreditoDisponible.BackColor = Color.FromArgb(3, 155, 229);

            //
            //this.TBCotizacion.Enabled = false;
            //this.TBCotizacion.BackColor = Color.FromArgb(72, 209, 204);
            this.TBBodega.Enabled = false;
            this.TBBodega.BackColor = Color.FromArgb(72, 209, 204);
            this.TBProveedor.Enabled = false;
            this.TBProveedor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBProducto.Enabled = false;
            this.TBProducto.BackColor = Color.FromArgb(72, 209, 204);

            //Texboxt de Datos - Parte Inferior del Formulario

            this.TBMarca.Enabled = false;
            this.TBMarca.BackColor = Color.FromArgb(72, 209, 204);
            this.TBStock.Enabled = false;
            this.TBStock.BackColor = Color.FromArgb(72, 209, 204);
            this.TBGrupo.Enabled = false;
            this.TBGrupo.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorPromedio.Enabled = false;
            this.TBValorPromedio.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorCompra.Enabled = false;
            this.TBValorCompra.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorVenta.Enabled = false;
            this.TBValorVenta.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBValorCotizado.Enabled = false;
            this.TBValorCotizado.BackColor = Color.FromArgb(255, 255, 255);
            this.TBValorCompra_Final.Enabled = false;
            this.TBValorCompra_Final.BackColor = Color.FromArgb(255, 255, 255);
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
                this.TBCotizacion.Clear();
                this.TBProducto.Clear();
                this.TBProveedor.Clear();

                //Panel Datos Basicos - Parte Inferior
                this.TBStock.Clear();

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
                this.btnEliminar.Enabled = true;
                this.btnImprimir.Enabled = false;
            }
            else if (!Digitar)
            {
                //Se procede a habilitar los botones de operacion para Editar registros en el sistema
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnCancelar.Enabled = true;
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
                this.DtDetalle.Columns.Add("Medida", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cajas", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Unidades", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Val. Cotizado", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Val. Compra", System.Type.GetType("System.String"));
                this.DtDetalle.Columns.Add("Total", System.Type.GetType("System.String"));

                //Medidas de las Columnas
                this.DGDetalleDeIngreso.DataSource = this.DtDetalle;

                this.DGDetalleDeIngreso.Columns[0].Visible = false;
                this.DGDetalleDeIngreso.Columns[0].HeaderText = "Idproducto";
                this.DGDetalleDeIngreso.Columns[1].HeaderText = "Codigo";
                this.DGDetalleDeIngreso.Columns[1].Width = 65;
                this.DGDetalleDeIngreso.Columns[2].HeaderText = "Descripcion";
                this.DGDetalleDeIngreso.Columns[2].Width = 270;
                this.DGDetalleDeIngreso.Columns[3].HeaderText = "Medida";
                this.DGDetalleDeIngreso.Columns[3].Width = 55;
                this.DGDetalleDeIngreso.Columns[4].HeaderText = "Cajas";
                this.DGDetalleDeIngreso.Columns[4].Width = 50;
                this.DGDetalleDeIngreso.Columns[5].HeaderText = "Unidades";
                this.DGDetalleDeIngreso.Columns[5].Width = 60;
                this.DGDetalleDeIngreso.Columns[6].HeaderText = "Cantidad";
                this.DGDetalleDeIngreso.Columns[6].Width = 55;
                this.DGDetalleDeIngreso.Columns[7].HeaderText = "Val. Cotizado";
                this.DGDetalleDeIngreso.Columns[7].Width = 95;
                this.DGDetalleDeIngreso.Columns[8].HeaderText = "Val. Compra";
                this.DGDetalleDeIngreso.Columns[8].Width = 95;
                this.DGDetalleDeIngreso.Columns[9].HeaderText = "Total";
                this.DGDetalleDeIngreso.Columns[9].AutoSizeMode.ToString();

                //Se Desabilita las columnas especificadas para evitar la edicion
                //Del Campo por parte del Usuario
                this.DGDetalleDeIngreso.Columns[0].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[1].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[2].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[3].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[4].ReadOnly = false;
                this.DGDetalleDeIngreso.Columns[5].ReadOnly = false;
                this.DGDetalleDeIngreso.Columns[6].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[7].ReadOnly = true;
                this.DGDetalleDeIngreso.Columns[8].ReadOnly = false;
                this.DGDetalleDeIngreso.Columns[9].ReadOnly = true;

                //Formato de Celdas
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalleDeIngreso.Columns[8].DefaultCellStyle.Format = "##,##0.00";
                this.DGDetalleDeIngreso.Columns[9].DefaultCellStyle.Format = "##,##0.00";

                //Aliniacion de las Celdas de Cada Columna
                this.DGDetalleDeIngreso.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.DGDetalleDeIngreso.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

        public void setCotizacion(string idcotizacion, string cotizacion)
        {
            this.TBIdcotizacion.Text = idcotizacion;
            this.TBCotizacion.Text = cotizacion;
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

        private void Agregar_Detalle(int idproducto, string codigo, string nombre, string unidad, string valor_compra)
        {
            try
            {
                bool Agregar = true;

                int Cajas = 0;
                int Cantidad = 0;
                int Unidades = 0;
                double Total = 0;

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
                    Fila["Cajas"] = Cajas;
                    Fila["Unidades"] = Unidades;
                    Fila["Cantidad"] = Cantidad;
                    Fila["Val. Cotizado"] = valor_compra;
                    Fila["Val. Compra"] = valor_compra;
                    Fila["Total"] = Total;
                    this.DtDetalle.Rows.Add(Fila);

                    this.Calculo_Totales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Detalle_SQL(int idproducto, string codigo, string nombre, string Medida, string valor_cotizado)
        {
            try
            {
                bool Agregar = true;

                double Cajas = 0;
                double Unidades = 0;
                double Total = 0;

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
                    Fila["Medida"] = Medida;
                    //Fila["Cajas"] = Cajas;
                    Fila["Unidades"] = Unidades;
                    Fila["Val. Cotizado"] = valor_cotizado;
                    //Fila["Val. de Compra"] = valor_compra;
                    Fila["Total"] = Total;
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
                double ValorFinal = 0;
                double ValorCotizado = 0;

                //Se procede a sumar la columna de valor de compra promedio

                foreach (DataGridViewRow row in DGDetalleDeIngreso.Rows)
                {
                    ValorFinal += Convert.ToDouble(row.Cells[9].Value);
                    ValorCotizado += Convert.ToDouble(row.Cells[7].Value);
                }

                //
                this.TBValorCompra_Final.Text = Convert.ToString(ValorFinal);
                this.TBValorCotizado.Text = Convert.ToString(ValorCotizado);

                //Se les da Formato a los campo de texto en este caso con Miles y Dos Decimales

                //this.TBValorCotizado.Text = Operacion.ToString("##,##0.00");
                this.TBValorCompra_Final.Text = ValorFinal.ToString("##,##0.00");
                this.TBValorCotizado.Text = ValorCotizado.ToString("##,##0.00");
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
            try
            {
                frmTotalizar_OrdenDeCompra frmTotalizar_OrdenDeCompra = frmTotalizar_OrdenDeCompra.GetInstancia();
                frmTotalizar_OrdenDeCompra.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Datos_Click(object sender, EventArgs e)
        {
            try
            {
                DGDetalleDeIngreso.Rows.RemoveAt(DGDetalleDeIngreso.CurrentRow.Index);

                this.Calculo_Totales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExaminar_Proveedor_Click(object sender, EventArgs e)
        {
            frmFiltro_Proveedor frmFiltro_Proveedor = new frmFiltro_Proveedor();
            frmFiltro_Proveedor.ShowDialog();
        }

        private void btnExaminar_Producto_Click(object sender, EventArgs e)
        {
            frmFiltro_Producto frmFiltro_Producto = new frmFiltro_Producto();
            frmFiltro_Producto.ShowDialog();
        }

        private void CBOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                        lblTotal_Detalles.Text = "Productos: " + Convert.ToString(DGDetalleDeIngreso.Rows.Count);

                        //Se procede a sumar la columna de valor de compra promedio

                        double total = 0;
                        foreach (DataGridViewRow row in DGDetalleDeIngreso.Rows)
                        {
                            total += Convert.ToDouble(row.Cells[7].Value);
                        }
                        //TBValorCompra_Final.Text = Convert.ToString(total);
                        this.TBValorCompra_Final.Text = total.ToString("##,##0.00");

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
            if (TBCotizacion.Text == Campo)
            {
                this.TBCotizacion.BackColor = Color.Azure;
                this.TBCotizacion.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCotizacion.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCotizacion.BackColor = Color.Azure;
                this.TBCotizacion.ForeColor = Color.FromArgb(0, 0, 0);
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

        private void DGDetalleDeIngreso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //
                int cantidad = 0;
                double Ingreso_Stock = 0;
                double Cajas = 0;
                double Unidades = 0;
                double Val_Compra = 0;
                double Val_CompraFinal = 0;
                double Operacion_Final = 0;
                double precio_total = 0;

                if (DGDetalleDeIngreso.Columns[e.ColumnIndex].Name == "Cajas")
                {
                    try
                    {
                        Cajas = Convert.ToDouble(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[4].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese la Cantidad de Cajas o Paquetes a Ordenar");
                    }

                    try
                    {
                        Unidades = Convert.ToDouble(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese las Unidades Pertenecientes a las Cajas o Paquetes Ordenados");
                    }

                    if (!(Cajas == 0) && !(Unidades == 0))
                    {
                        Ingreso_Stock = Unidades * Cajas;
                        this.DGDetalleDeIngreso.Rows[e.RowIndex].Cells[6].Value = Ingreso_Stock.ToString();
                    }
                }

                if (DGDetalleDeIngreso.Columns[e.ColumnIndex].Name == "Unidades")
                {
                    try
                    {
                        Cajas = Convert.ToDouble(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[4].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese la Cantidad de Cajas o Paquetes a Ordenar");
                    }

                    try
                    {
                        Unidades = Convert.ToDouble(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[5].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Por Favor Ingrese las Unidades Pertenecientes a las Cajas o Paquetes Ordenados");
                    }

                    if (!(Cajas == 0) && !(Unidades == 0))
                    {
                        Ingreso_Stock = Unidades * Cajas;
                        this.DGDetalleDeIngreso.Rows[e.RowIndex].Cells[6].Value = Ingreso_Stock.ToString();
                    }

                    //*******************************************************************************************

                    cantidad = Convert.ToInt32(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[6].Value.ToString());
                    Val_Compra = double.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[8].Value.ToString());
                    Val_CompraFinal = double.Parse(DGDetalleDeIngreso.Rows[e.RowIndex].Cells[9].Value.ToString());

                    if (!(cantidad == 0) && !(Val_Compra == 0))
                    {
                        precio_total = Val_Compra * cantidad;
                        this.DGDetalleDeIngreso.Rows[e.RowIndex].Cells[9].Value = precio_total.ToString("##,##0.00");

                        this.Calculo_Totales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBIdordendecompra_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBIdcotizacion_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCotizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    DataTable Datos = new DataTable();
                    Datos = fCotizacion_Compra.Auto_ConsultaEnOrden(this.TBCotizacion.Text.Trim());
                    if (Datos.Rows.Count <= 0)
                    {
                        this.MensajeError("El producto el cual desea agregar no se encuentra registrado en su Base de Datos");
                    }
                    else
                    {
                        //Captura de Valores en la Base de Datos

                        this.TBIdcotizacion.Text = Datos.Rows[0][0].ToString();
                        this.TBIdbodega.Text = Datos.Rows[0][1].ToString();
                        this.TBIdproveedor.Text = Datos.Rows[0][2].ToString();
                        this.CBTipodepago.Text = Datos.Rows[0][3].ToString();
                        this.TBProveedor.Text = Datos.Rows[0][4].ToString();
                        this.TBCodigo_Proveedor.Text = Datos.Rows[0][5].ToString();
                        this.TBBodega.Text = Datos.Rows[0][6].ToString();
                        this.TBCodigo_Bodega.Text = Datos.Rows[0][7].ToString();

                        this.TBIddetalle.Text = TBIdcotizacion.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBIddetalle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.DGDetalleDeIngreso.DataSource = fCotizacion_Compra.Auto_ConsultaDetalle(this.TBIddetalle.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            frmFiltro_ActualizarPrecios frmFiltro_ActualizarPrecios = new frmFiltro_ActualizarPrecios();
            frmFiltro_ActualizarPrecios.ShowDialog();
        }

        private void btnExaminar_Bodega_Click(object sender, EventArgs e)
        {
            frmFiltro_Bodega frmFiltro_Bodega = new frmFiltro_Bodega();
            frmFiltro_Bodega.ShowDialog();
        }

        private void TBCodigo_Bodega_KeyPress(object sender, KeyPressEventArgs e)
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

                    this.lblTotal_Detalles.Text = "Productos Agregados: " + Convert.ToString(DGDetalleDeIngreso.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnExaminar_Cotizacion_Click(object sender, EventArgs e)
        {
            frmFiltro_CotizacionDeCompra frmFiltro_CotizacionDeCompra = new frmFiltro_CotizacionDeCompra();
            frmFiltro_CotizacionDeCompra.ShowDialog();
        }

        private void DGDetalleDeIngreso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TBIdproducto.Text = this.DGDetalleDeIngreso.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdproducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fProductos.Buscar(this.TBIdproducto.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos
                    Referencia = Datos.Rows[0][9].ToString();
                    Stock = Datos.Rows[0][14].ToString();
                    ValorPromedio = Datos.Rows[0][25].ToString();
                    ValorCompra = Datos.Rows[0][26].ToString();
                    ValorVenta = Datos.Rows[0][27].ToString();
                    Marca = Datos.Rows[0][44].ToString();
                    Grupo = Datos.Rows[0][44].ToString();

                    //Se lleva acabo el complemento de los campos de Texto

                    this.TBMarca.Text = Marca;
                    this.TBGrupo.Text = Grupo;
                    this.TBStock.Text = Stock;

                    this.TBValorPromedio.Text = ValorPromedio;
                    this.TBValorCompra.Text = ValorCompra;
                    this.TBValorVenta.Text = ValorVenta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            if (TBCotizacion.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCotizacion.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCotizacion.Text = Campo;
                this.TBCotizacion.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCotizacion.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void frmOrdenDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }


    }
}

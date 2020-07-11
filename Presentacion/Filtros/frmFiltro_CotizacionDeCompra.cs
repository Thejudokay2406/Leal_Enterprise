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
    public partial class frmFiltro_CotizacionDeCompra : Form
    {
        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Codigo, Proveedor, Bodega, Almacen, TipoDePago = "";
        private string Mora, Disponible, Envio, SubTotal, Descuento_Porcentaje, Descuento = "";
        private string Impuesto, Valor, Vencimiento, Fecha = "";

        //***************************************************************************************

        public frmFiltro_CotizacionDeCompra()
        {
            InitializeComponent();
        }

        private void frmFiltro_CotizacionDeCompra_Load(object sender, EventArgs e)
        {
            //Ocultacion de Texboxt
            this.TBIdcotizacion.Visible = false;
            //Inicio de Claes
            this.Habilitar();
        }

        private void Habilitar()
        {
            this.TBCodigo.ReadOnly = true;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBProveedor.ReadOnly = true;
            this.TBProveedor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.ReadOnly = true;
            this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBAlmacen.ReadOnly = true;
            this.TBAlmacen.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTipodepago.ReadOnly = true;
            this.TBTipodepago.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMora.ReadOnly = true;
            this.TBMora.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDisponible.ReadOnly = true;
            this.TBDisponible.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEnvio.ReadOnly = true;
            this.TBEnvio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBSubTotal.ReadOnly = true;
            this.TBSubTotal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescuento_Porcentaje.ReadOnly = true;
            this.TBDescuento_Porcentaje.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescuento.ReadOnly = true;
            this.TBDescuento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBImpuesto_Valor.ReadOnly = true;
            this.TBImpuesto_Valor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorGeneral.ReadOnly = true;
            this.TBValorGeneral.BackColor = Color.FromArgb(3, 155, 229);
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenDeCompra frmOC = frmOrdenDeCompra.GetInstancia();
                
                //Variables Para Los Filtros
                string idcotizacion, cotizacion;

                if (frmOC.Examinar)
                {
                    idcotizacion = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    cotizacion = Convert.ToString(this.DGFiltro_Resultados.CurrentRow.Cells[2].Value);
                    frmOC.setCotizacion(idcotizacion, cotizacion);
                    this.Hide();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fCotizacion_Compra.Buscar(this.TBBuscar.Text, 1);
                    this.DGFiltro_Resultados.Columns[0].Visible = false;

                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);

                    this.btnAgregar.Enabled = true;
                    this.DGFiltro_Resultados.Enabled = true;

                    //this.DGFiltro_Resultados.Columns[1].Width = 120;
                    //this.DGFiltro_Resultados.Columns[2].Width = 337;

                    //Aliniacion de las Celdas de Cada Columna
                    this.DGFiltro_Resultados.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //this.DGFiltro_Resultados.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //this.DGFiltro_Resultados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //Alineacion de los Encabezados de Cada Columna
                    this.DGFiltro_Resultados.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_Resultados.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //this.DGFiltro_Resultados.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //this.DGFiltro_Resultados.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_Resultados.DataSource = null;
                    this.DGFiltro_Resultados.Enabled = false;
                    this.lblTotal.Text = "Datos Registrados: 0";

                    this.btnAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGFiltro_Resultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TBIdcotizacion.Text = this.DGFiltro_Resultados.CurrentRow.Cells["Codigo"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdcotizacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fCotizacion_Compra.Buscar(this.TBIdcotizacion.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos
                    Codigo = Datos.Rows[0][6].ToString();
                    Almacen = Datos.Rows[0][8].ToString();
                    SubTotal = Datos.Rows[0][11].ToString();
                    Descuento_Porcentaje = Datos.Rows[0][12].ToString();
                    Descuento = Datos.Rows[0][13].ToString();
                    Impuesto = Datos.Rows[0][14].ToString();
                    Valor = Datos.Rows[0][15].ToString();
                    Mora = Datos.Rows[0][16].ToString();
                    Disponible = Datos.Rows[0][17].ToString();
                    Envio = Datos.Rows[0][18].ToString();
                    TipoDePago = Datos.Rows[0][19].ToString();
                    Vencimiento = Datos.Rows[0][21].ToString();
                    Fecha = Datos.Rows[0][22].ToString();
                    Bodega = Datos.Rows[0][23].ToString();
                    Proveedor = Datos.Rows[0][25].ToString();
                    

                    //Se lleva acabo el complemento de los campos de Texto
                    this.TBCodigo.Text = Codigo;
                    this.TBProveedor.Text = Proveedor;
                    this.TBBodega.Text = Bodega;
                    this.TBAlmacen.Text = Almacen;
                    this.TBTipodepago.Text = TipoDePago;
                    this.TBMora.Text = Mora;
                    this.TBDisponible.Text = Disponible;
                    this.TBEnvio.Text = Envio;
                    this.TBSubTotal.Text = SubTotal;
                    this.TBDescuento_Porcentaje.Text = Descuento_Porcentaje;
                    this.TBDescuento.Text = Descuento;
                    this.TBImpuesto_Valor.Text = Impuesto;
                    this.TBValorGeneral.Text = Valor;
                    this.dateTimePicker3.Text = Fecha;
                                      

                    if (Vencimiento == "1")
                    {
                        this.CHVencimiento.Checked = true;
                    }
                    else
                    {
                        this.CHVencimiento.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

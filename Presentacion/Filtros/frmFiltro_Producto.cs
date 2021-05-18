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
    public partial class frmFiltro_Producto : Form
    {
        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Codigo, Nombre, Referencia, Descripcion, Presentacion, Bodega, Lote, Marca, Unidad = "";
        private string CompraMinimaCliente, CompraMaximaCliente, CompraMinimaMayorista, CompraMaximaMayorista = "";
        private string VentaMinimaCliente, VentaMaximaCliente, VentaMinimaMayorista, VentaMaximaMayorista = "";

        //***************************************************************************************

        public frmFiltro_Producto()
        {
            InitializeComponent();
        }

        private void frmFiltro_Producto_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBBuscar_General.Select();

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;

            //SE EVALUA EL TIPO DE FILTRO A REALIZAR YA SEA DE IGUALDAD O GENERAL
            frmProducto frmPro = new frmProducto();

            if (frmPro.Filtro_Igualdad)
            {
                tabControl1.SelectedIndex = 1;
                this.TBBuscar_Igualdad.Focus();
            }
        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Solicitud Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Leal Enterprise - Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Habilitar()
        {
            this.TBCodigo.ReadOnly = true;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBNombre.ReadOnly = true;
            this.TBNombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBReferencia.ReadOnly = true;
            this.TBReferencia.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescripcion01.ReadOnly = true;
            this.TBDescripcion01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBPresentacion.ReadOnly = true;
            this.TBPresentacion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMarca.ReadOnly = true;
            this.TBMarca.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.ReadOnly = true;
            this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBStock.ReadOnly = true;
            this.TBStock.BackColor = Color.FromArgb(3, 155, 229);
            this.TBUnidad.ReadOnly = true;
            this.TBUnidad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBUnidad_Valor.ReadOnly = true;
            this.TBUnidad_Valor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComMin_Cliente.ReadOnly = true;
            this.TBComMin_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComMax_Cliente.ReadOnly = true;
            this.TBComMax_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComMin_Mayorista.ReadOnly = true;
            this.TBComMin_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBComMax_Mayorista.ReadOnly = true;
            this.TBComMax_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVenMax_Mayorista.ReadOnly = true;
            this.TBVenMax_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVenMax_Personal.ReadOnly = true;
            this.TBVenMax_Personal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVenMin_Mayorista.ReadOnly = true;
            this.TBVenMin_Mayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVenMin_Personal.ReadOnly = true;
            this.TBVenMin_Personal.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBReferencia.Clear();
            this.TBDescripcion01.Clear();
            this.TBPresentacion.Clear();
            this.TBMarca.Clear();
            this.TBBodega.Clear();
            this.TBStock.Clear();
            this.TBUnidad.Clear();
            this.TBUnidad_Valor.Clear();
            this.TBComMin_Cliente.Clear();
            this.TBComMax_Cliente.Clear();
            this.TBComMin_Mayorista.Clear();
            this.TBComMax_Mayorista.Clear();
            this.TBVenMax_Mayorista.Clear();
            this.TBVenMax_Personal.Clear();
            this.TBVenMin_Mayorista.Clear();
            this.TBVenMin_Personal.Clear();
        }
    
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenDeCompra frmOC = frmOrdenDeCompra.GetInstancia();
                frmInventario_Ingreso frmBI = frmInventario_Ingreso.GetInstancia();
                frmCotizacionDeCompra frmCot = frmCotizacionDeCompra.GetInstancia();
                //frmOrdenDeCompra frmOCom = frmOrdenDeCompra.GetInstancia();

                //Variables Para Los Filtros
                string idproducto, producto;

                if (frmBI.Examinar)
                {   
                    idproducto = this.DGFiltro_General.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_General.CurrentRow.Cells[2].Value);
                    frmBI.setProducto(idproducto, producto);
                    this.Hide();
                }

                if (frmOC.Examinar)
                {
                    idproducto = this.DGFiltro_General.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_General.CurrentRow.Cells[2].Value);
                    frmOC.setProducto(idproducto, producto);
                    this.Hide();
                }

                if (frmCot.Examinar)
                {
                    idproducto = this.DGFiltro_General.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_General.CurrentRow.Cells[2].Value);
                    frmCot.setProducto(idproducto, producto);
                    this.Hide();
                }

                //if (frmOCom.Examinar)
                //{
                //    idproducto = this.DGFiltro_General.CurrentRow.Cells[0].Value.ToString();
                //    producto = Convert.ToString(this.DGFiltro_General.CurrentRow.Cells[2].Value);
                //    frmOCom.setProducto(idproducto, producto);
                //    this.Hide();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Lotes_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar_General.Text != "")
                {
                    this.DGFiltro_General.DataSource = fProducto_Inventario.Buscar(1, this.TBBuscar_General.Text);
                    this.DGFiltro_General.Columns[0].Visible = false;
                    
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_General.Rows.Count);

                    this.btnAgregar.Enabled = true;
                    this.DGFiltro_General.Enabled = true;

                    this.DGFiltro_General.Columns[1].Width = 120;
                    this.DGFiltro_General.Columns[2].Width = 337;

                    //Aliniacion de las Celdas de Cada Columna
                    this.DGFiltro_General.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_General.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //Alineacion de los Encabezados de Cada Columna
                    this.DGFiltro_General.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_General.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    this.Limpiar_Datos();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_General.DataSource = null;
                    this.DGFiltro_General.Enabled = false;
                    this.lblTotal.Text = "Datos Registrados: 0";

                    this.btnAgregar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_Filtro_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBIdproducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fProducto_Inventario.Buscar(2, this.TBIdproducto.Text);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos
                    Codigo = Datos.Rows[0][4].ToString();
                    Nombre = Datos.Rows[0][5].ToString();
                    Referencia = Datos.Rows[0][6].ToString();
                    Descripcion = Datos.Rows[0][7].ToString();
                    Presentacion = Datos.Rows[0][8].ToString();
                    Unidad = Datos.Rows[0][11].ToString();
                    VentaMinimaCliente = Datos.Rows[0][29].ToString();
                    VentaMaximaCliente = Datos.Rows[0][30].ToString();
                    VentaMinimaMayorista = Datos.Rows[0][31].ToString();
                    VentaMaximaMayorista = Datos.Rows[0][32].ToString();
                    CompraMinimaCliente = Datos.Rows[0][33].ToString();
                    CompraMaximaCliente = Datos.Rows[0][34].ToString();
                    CompraMinimaMayorista = Datos.Rows[0][35].ToString();
                    CompraMaximaMayorista = Datos.Rows[0][36].ToString();
                    //Marca = Datos.Rows[0][38].ToString();
                    //Bodega = Datos.Rows[0][36].ToString();
                    //Lote = Datos.Rows[0][40].ToString();

                    //Se lleva acabo el complemento de los campos de Texto
                    this.TBCodigo.Text = Codigo;
                    this.TBNombre.Text = Nombre;
                    this.TBReferencia.Text = Referencia;
                    this.TBDescripcion01.Text = Descripcion;
                    this.TBPresentacion.Text = Presentacion;
                    this.TBMarca.Text = Marca;
                    this.TBUnidad.Text = Unidad;
                    this.TBComMin_Cliente.Text = CompraMinimaCliente;
                    this.TBComMax_Cliente.Text = CompraMaximaCliente;
                    this.TBComMin_Mayorista.Text = CompraMinimaMayorista;
                    this.TBComMax_Mayorista.Text = CompraMaximaMayorista;
                    this.TBVenMin_Personal.Text = VentaMinimaCliente;
                    this.TBVenMax_Personal.Text = VentaMaximaCliente;
                    this.TBVenMin_Mayorista.Text = VentaMinimaMayorista;
                    this.TBVenMax_Mayorista.Text = VentaMaximaMayorista;
                    //this.TBBodega.Text = Bodega;
                    //this.TBStock.Text = Stock;
                    //this.TBUnidad.Text = Lote;

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
                this.TBIdproducto.Text = this.DGFiltro_General.CurrentRow.Cells["ID"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        private void DGResultados_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar_General.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar_General.BackColor = Color.FromArgb(3, 155, 229);
        }
    }
}

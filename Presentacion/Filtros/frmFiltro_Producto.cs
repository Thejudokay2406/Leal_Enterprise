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
        private string Codigo, Nombre, Referencia, Descripcion, Presentacion = "";
        private string Marca, Unidad, UnidadDeVenta, CantidadMinimaCliente, CantidadMaximaCliente = "";
        private string CantidadMinimaMayorista, CantidadMaximaMayorista, Bodega, Stock, Lote = "";

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
            this.TBBuscar.Select();

            //Ocultacion de Texboxt
            this.TBIdproducto.Visible = false;
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
            this.TBUnidad.ReadOnly = true;
            this.TBUnidad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBUnidadDeVenta.ReadOnly = true;
            this.TBUnidadDeVenta.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMininoCliente.ReadOnly = true;
            this.TBMininoCliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMaximoCliente.ReadOnly = true;
            this.TBMaximoCliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMinimoMayorista.ReadOnly = true;
            this.TBMinimoMayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMaximaMayorista.ReadOnly = true;
            this.TBMaximaMayorista.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBodega.ReadOnly = true;
            this.TBBodega.BackColor = Color.FromArgb(3, 155, 229);
            this.TBStock.ReadOnly = true;
            this.TBStock.BackColor = Color.FromArgb(3, 155, 229);
            this.TBlote.ReadOnly = true;
            this.TBlote.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBReferencia.Clear();
            this.TBDescripcion01.Clear();
            this.TBPresentacion.Clear();
            this.TBMarca.Clear();
            this.TBUnidad.Clear();
            this.TBUnidadDeVenta.Clear();
            this.TBMininoCliente.Clear();
            this.TBMaximoCliente.Clear();
            this.TBMinimoMayorista.Clear();
            this.TBMaximaMayorista.Clear();
            this.TBBodega.Clear();
            this.TBStock.Clear();
            this.TBlote.Clear();
        }
    
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenDeCompra frmOC = frmOrdenDeCompra.GetInstancia();
                frmInventario_Ingreso frmBI = frmInventario_Ingreso.GetInstancia();
                frmCotizacionDeCompra frmCot = frmCotizacionDeCompra.GetInstancia();
                frmOrdenDeCompra frmOCom = frmOrdenDeCompra.GetInstancia();

                //Variables Para Los Filtros
                string idproducto, producto;

                if (frmBI.Examinar)
                {   
                    idproducto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_Resultados.CurrentRow.Cells[2].Value);
                    frmBI.setProducto(idproducto, producto);
                    this.Hide();
                }

                if (frmOC.Examinar)
                {
                    idproducto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_Resultados.CurrentRow.Cells[2].Value);
                    frmOC.setProducto(idproducto, producto);
                    this.Hide();
                }

                if (frmCot.Examinar)
                {
                    idproducto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_Resultados.CurrentRow.Cells[2].Value);
                    frmCot.setProducto(idproducto, producto);
                    this.Hide();
                }

                if (frmOCom.Examinar)
                {
                    idproducto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    producto = Convert.ToString(this.DGFiltro_Resultados.CurrentRow.Cells[2].Value);
                    frmOCom.setProducto(idproducto, producto);
                    this.Hide();
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
                if (TBBuscar.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fProductos.Buscar(this.TBBuscar.Text, 1);
                    this.DGFiltro_Resultados.Columns[0].Visible = false;
                    
                    this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);

                    this.btnAgregar.Enabled = true;
                    this.DGFiltro_Resultados.Enabled = true;

                    this.DGFiltro_Resultados.Columns[1].Width = 120;
                    this.DGFiltro_Resultados.Columns[2].Width = 337;

                    //Aliniacion de las Celdas de Cada Columna
                    this.DGFiltro_Resultados.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //Alineacion de los Encabezados de Cada Columna
                    this.DGFiltro_Resultados.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_Resultados.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    this.Limpiar_Datos();

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
                    Codigo = Datos.Rows[0][7].ToString();
                    Nombre = Datos.Rows[0][8].ToString();
                    Referencia = Datos.Rows[0][9].ToString();
                    Descripcion = Datos.Rows[0][10].ToString();
                    Presentacion = Datos.Rows[0][11].ToString();
                    Stock = Datos.Rows[0][14].ToString();
                    Unidad = Datos.Rows[0][15].ToString();
                    UnidadDeVenta = Datos.Rows[0][16].ToString();
                    CantidadMinimaCliente = Datos.Rows[0][32].ToString();
                    CantidadMaximaCliente = Datos.Rows[0][33].ToString();
                    CantidadMinimaMayorista = Datos.Rows[0][34].ToString();
                    CantidadMaximaMayorista = Datos.Rows[0][35].ToString();
                    Bodega = Datos.Rows[0][36].ToString();
                    Lote = Datos.Rows[0][40].ToString();
                    Marca = Datos.Rows[0][44].ToString();
                    
                    //Se lleva acabo el complemento de los campos de Texto
                    this.TBCodigo.Text = Codigo;
                    this.TBNombre.Text = Nombre;
                    this.TBReferencia.Text = Referencia;
                    this.TBDescripcion01.Text = Descripcion;
                    this.TBPresentacion.Text = Presentacion;
                    this.TBMarca.Text = Marca;
                    this.TBUnidad.Text = Unidad;
                    this.TBUnidadDeVenta.Text = UnidadDeVenta;
                    this.TBMininoCliente.Text = CantidadMinimaCliente;
                    this.TBMaximoCliente.Text = CantidadMaximaCliente;
                    this.TBMinimoMayorista.Text = CantidadMinimaMayorista;
                    this.TBMaximaMayorista.Text = CantidadMaximaMayorista;
                    this.TBBodega.Text = Bodega;
                    this.TBStock.Text = Stock;
                    this.TBlote.Text = Lote;

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
                this.TBIdproducto.Text = this.DGFiltro_Resultados.CurrentRow.Cells["ID"].Value.ToString();
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
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }
    }
}

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
        private string Codigo, Nombre, Grupo, Referencia, Descripcion01, Descripcion02, Descripcion03, Presentacion, Marca, Stock, Unidad, Unidad_Valor, Valor_CompraPromedio, Valor_CompraFinal, ValorBase_Inicial01, ValorBase_Inicial02, ValorBase_Inicial03, ValorBase_InicialMayorista, CompraMinima, CompraMaxima, VentaMinima, VentaMaxima = "";

        //
        private string Valor_Venta01, Valor_Venta02, Valor_Venta03, Valor_Mayorista, Valor_PorVenta01, Valor_PorVenta02, Valor_PorVenta03, Valor_PorMayorista, Valor_ImpVenta01, Valor_ImpVenta02, Valor_ImpVenta03, Valor_ImpMayorista, Valor_Unidad = "";

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
            this.TBCodigo.Enabled = false;
            this.TBCodigo.BackColor = Color.FromArgb(245, 245, 245);
            this.TBNombre.Enabled = false;
            this.TBNombre.BackColor = Color.FromArgb(245, 245, 245);
            this.TBGrupo.Enabled = false;
            this.TBGrupo.BackColor = Color.FromArgb(245, 245, 245);
            this.TBReferencia.Enabled = false;
            this.TBReferencia.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDescripcion01.Enabled = false;
            this.TBDescripcion01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDescripcion02.Enabled = false;
            this.TBDescripcion02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDescripcion03.Enabled = false;
            this.TBDescripcion03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBPresentacion.Enabled = false;
            this.TBPresentacion.BackColor = Color.FromArgb(245, 245, 245);
            this.TBMarca.Enabled = false;
            this.TBMarca.BackColor = Color.FromArgb(245, 245, 245);
            this.TBStock.Enabled = false;
            this.TBStock.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_CompraPromedio.Enabled = false;
            this.TBValor_CompraPromedio.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_CompraFinal.Enabled = false;
            this.TBValor_CompraFinal.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValorBase_Inicial01.Enabled = false;
            this.TBValorBase_Inicial01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValorBase_Inicial02.Enabled = false;
            this.TBValorBase_Inicial02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValorBase_Inicial03.Enabled = false;
            this.TBValorBase_Inicial03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValorBase_InicialMayorista.Enabled = false;
            this.TBValorBase_InicialMayorista.BackColor = Color.FromArgb(245, 245, 245);

            //
            this.TBValor_Venta01.Enabled = false;
            this.TBValor_Venta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Venta02.Enabled = false;
            this.TBValor_Venta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Venta03.Enabled = false;
            this.TBValor_Venta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Mayorista.Enabled = false;
            this.TBValor_Mayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValor_PorVenta01.Enabled = false;
            this.TBValor_PorVenta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorVenta02.Enabled = false;
            this.TBValor_PorVenta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorVenta03.Enabled = false;
            this.TBValor_PorVenta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_PorMayorista.Enabled = false;
            this.TBValor_PorMayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBValor_ImpVenta01.Enabled = false;
            this.TBValor_ImpVenta01.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpVenta02.Enabled = false;
            this.TBValor_ImpVenta02.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpVenta03.Enabled = false;
            this.TBValor_ImpVenta03.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_ImpMayorista.Enabled = false;
            this.TBValor_ImpMayorista.BackColor = Color.FromArgb(245, 245, 245);

            this.TBUnidad.Enabled = false;
            this.TBUnidad.BackColor = Color.FromArgb(245, 245, 245);
            this.TBValor_Unidad.Enabled = false;
            this.TBValor_Unidad.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCompraminima.Enabled = false;
            this.TBCompraminima.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCompraMaxima.Enabled = false;
            this.TBCompraMaxima.BackColor = Color.FromArgb(245, 245, 245);
            this.TBVentaMinima.Enabled = false;
            this.TBVentaMinima.BackColor = Color.FromArgb(245, 245, 245);
            this.TBVentaMaxima.Enabled = false;
            this.TBVentaMaxima.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void Limpiar_Datos()
        {
            this.TBCodigo.Clear();
            this.TBNombre.Clear();
            this.TBGrupo.Clear();
            this.TBReferencia.Clear();
            this.TBDescripcion01.Clear();
            this.TBDescripcion02.Clear();
            this.TBDescripcion03.Clear();
            this.TBPresentacion.Clear();
            this.TBMarca.Clear();
            this.TBStock.Clear();
            this.TBValor_CompraPromedio.Clear();
            this.TBValor_CompraFinal.Clear();

            this.TBValorBase_Inicial01.Clear();
            this.TBValorBase_Inicial02.Clear();
            this.TBValorBase_Inicial03.Clear();
            this.TBValorBase_InicialMayorista.Clear();

            //
            this.TBValor_Venta01.Clear();
            this.TBValor_Venta02.Clear();
            this.TBValor_Venta03.Clear();
            this.TBValor_Mayorista.Clear();

            this.TBValor_PorVenta01.Clear();
            this.TBValor_PorVenta02.Clear();
            this.TBValor_PorVenta03.Clear();
            this.TBValor_PorMayorista.Clear();

            this.TBValor_ImpVenta01.Clear();
            this.TBValor_ImpVenta02.Clear();
            this.TBValor_ImpVenta03.Clear();
            this.TBValor_ImpMayorista.Clear();

            this.TBUnidad.Clear();
            this.TBValor_Unidad.Clear();
            this.TBCompraminima.Clear();
            this.TBCompraMaxima.Clear();
            this.TBVentaMinima.Clear();
            this.TBVentaMaxima.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmOrdenDeCompra frmOC = frmOrdenDeCompra.GetInstancia();
                frmInventario_Ingreso frmBI = frmInventario_Ingreso.GetInstancia();
                frmCotizacionDeCompra frmCot = frmCotizacionDeCompra.GetInstancia();
                frmProducto frmPD = frmProducto.GetInstancia();

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
                    Nombre = Datos.Rows[0][6].ToString();
                    Marca = Datos.Rows[0][7].ToString();
                    Referencia = Datos.Rows[0][8].ToString();
                    Descripcion01 = Datos.Rows[0][9].ToString();
                    Descripcion02 = Datos.Rows[0][10].ToString();
                    Descripcion03 = Datos.Rows[0][11].ToString();
                    Presentacion = Datos.Rows[0][12].ToString();
                    CompraMinima = Datos.Rows[0][14].ToString();
                    CompraMaxima = Datos.Rows[0][15].ToString();
                    VentaMinima = Datos.Rows[0][16].ToString();
                    VentaMaxima = Datos.Rows[0][17].ToString();
                                        
                    Valor_CompraPromedio = Datos.Rows[0][43].ToString();
                    Valor_CompraFinal = Datos.Rows[0][44].ToString();

                    ValorBase_Inicial01 = Datos.Rows[0][45].ToString();
                    ValorBase_Inicial02 = Datos.Rows[0][46].ToString();
                    ValorBase_Inicial03 = Datos.Rows[0][47].ToString();
                    ValorBase_InicialMayorista = Datos.Rows[0][48].ToString();

                    Valor_PorVenta01 = Datos.Rows[0][49].ToString();
                    Valor_PorVenta02 = Datos.Rows[0][50].ToString();
                    Valor_PorVenta03 = Datos.Rows[0][51].ToString();
                    Valor_PorMayorista = Datos.Rows[0][52].ToString();

                    Valor_ImpVenta01 = Datos.Rows[0][53].ToString();
                    Valor_ImpVenta02 = Datos.Rows[0][54].ToString();
                    Valor_ImpVenta03 = Datos.Rows[0][55].ToString();
                    Valor_ImpMayorista = Datos.Rows[0][56].ToString();

                    //
                    Valor_Venta01 = Datos.Rows[0][57].ToString();
                    Valor_Venta02 = Datos.Rows[0][58].ToString();
                    Valor_Venta03 = Datos.Rows[0][59].ToString();
                    Valor_Mayorista = Datos.Rows[0][60].ToString();

                    Unidad = Datos.Rows[0][61].ToString();
                    Valor_Unidad = Datos.Rows[0][62].ToString();
                    Grupo = Datos.Rows[0][64].ToString();
                    
                    //Bodega = Datos.Rows[0][0].ToString();
                    //Stock = Datos.Rows[0][0].ToString();

                    //Se lleva acabo el complemento de los campos de Texto
                    this.TBCodigo.Text = Codigo;
                    this.TBNombre.Text = Nombre;
                    this.TBReferencia.Text = Referencia;
                    this.TBDescripcion01.Text = Descripcion01;
                    this.TBDescripcion02.Text = Descripcion02;
                    this.TBDescripcion03.Text = Descripcion03;
                    this.TBPresentacion.Text = Presentacion;
                    this.TBMarca.Text = Marca;
                    this.TBStock.Text = Stock;
                    this.TBCompraminima.Text = CompraMinima;
                    this.TBCompraMaxima.Text = CompraMaxima;
                    this.TBVentaMinima.Text = VentaMinima;
                    this.TBVentaMaxima.Text = VentaMaxima;

                    this.TBValor_CompraPromedio.Text = Valor_CompraPromedio;
                    this.TBValor_CompraFinal.Text = Valor_CompraFinal;

                    this.TBValorBase_Inicial01.Text = ValorBase_Inicial01;
                    this.TBValorBase_Inicial02.Text = ValorBase_Inicial02;
                    this.TBValorBase_Inicial03.Text = ValorBase_Inicial03;
                    this.TBValorBase_InicialMayorista.Text = ValorBase_InicialMayorista;

                    //
                    this.TBValor_Venta01.Text = Valor_Venta01;
                    this.TBValor_Venta02.Text = Valor_Venta02;
                    this.TBValor_Venta03.Text = Valor_Venta03;
                    this.TBValor_Mayorista.Text = Valor_Mayorista;

                    this.TBValor_PorVenta01.Text = Valor_PorVenta01;
                    this.TBValor_PorVenta02.Text = Valor_PorVenta02;
                    this.TBValor_PorVenta03.Text = Valor_PorVenta03;
                    this.TBValor_PorMayorista.Text = Valor_PorMayorista;

                    this.TBValor_ImpVenta01.Text = Valor_ImpVenta01;
                    this.TBValor_ImpVenta02.Text = Valor_ImpVenta02;
                    this.TBValor_ImpVenta03.Text = Valor_ImpVenta03;
                    this.TBValor_ImpMayorista.Text = Valor_ImpMayorista;

                    this.TBUnidad.Text = Unidad;
                    this.TBValor_Unidad.Text = Valor_Unidad;
                    this.TBGrupo.Text = Grupo;

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
            this.TBBuscar_General.BackColor = Color.FromArgb(245, 245, 245);
        }
    }
}

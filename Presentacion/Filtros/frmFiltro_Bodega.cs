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
    public partial class frmFiltro_Bodega : Form
    {
        public frmFiltro_Bodega()
        {
            InitializeComponent();
        }

        private void frmFiltro_Bodega_Load(object sender, EventArgs e)
        {

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

        private void DGFiltro_Resultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmOrdenDeCompra frmOComp = frmOrdenDeCompra.GetInstancia();
                frmInventario_Ingreso frmInv = frmInventario_Ingreso.GetInstancia();
                frmCotizacionDeCompra frmCComp = frmCotizacionDeCompra.GetInstancia();
                
                //Variables Para Los Filtros
                string idbodega, bodega, documento;

                if (frmInv.Filtro)
                {
                    idbodega = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    bodega = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmInv.setBodega(idbodega, bodega, documento);
                    this.Hide();
                }

                if (frmCComp.Filtro)
                {
                    idbodega = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    bodega = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmCComp.setBodega(idbodega, bodega, documento);
                    this.Hide();
                }

                if (frmOComp.Filtro)
                {
                    idbodega = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    bodega = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmOComp.setBodega(idbodega, bodega, documento);
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
                    this.DGFiltro_Resultados.DataSource = fBodega.Buscar(this.TBBuscar.Text, 1);
                    //this.DGFiltro_Resultados.Columns[0].Visible = false;

                    lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
                    this.DGFiltro_Resultados.Enabled = true;

                    this.DGFiltro_Resultados.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_Resultados.DataSource = null;
                    this.DGFiltro_Resultados.Enabled = false;
                    this.lblTotal.Text = "Datos Registrados: 0";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

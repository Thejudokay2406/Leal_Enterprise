﻿using System;
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
    public partial class frmFiltro_Proveedor : Form
    {
        public frmFiltro_Proveedor()
        {
            InitializeComponent();
        }

        private void frmFiltro_Proveedor_Load(object sender, EventArgs e)
        {

        }

        private void Filtro_General()
        {
            try
            {
                frmProducto frmPro = frmProducto.GetInstancia();
                frmOrdenDeCompra frmOCom = frmOrdenDeCompra.GetInstancia();
                frmInventario_Ingreso frmInv = frmInventario_Ingreso.GetInstancia();

                //Variables para realizar los Filtro 
                string idproveedor, proveedor, documento;

                if (frmPro.Examinar_Proveedor)
                {
                    idproveedor = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    proveedor = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmPro.setProveedor(idproveedor, proveedor, documento);
                    this.Hide();
                }

                if (frmInv.Examinar)
                {
                    idproveedor = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    proveedor = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmInv.setProveedor(idproveedor, proveedor, documento);
                    this.Hide();
                }

                if (frmOCom.Examinar)
                {
                    idproveedor = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    proveedor = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmOCom.setProveedor(idproveedor, proveedor, documento);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fProveedor.Buscar(this.TBBuscar.Text, 1);
                    //this.DGFiltro_Resultados.Columns[0].Visible = false;

                    lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
                    this.DGFiltro_Resultados.Enabled = true;
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

        private void DGFiltro_Resultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Filtro_General();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGFiltro_Resultados_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.F3))
                {
                    this.Filtro_General();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Filtro_General();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

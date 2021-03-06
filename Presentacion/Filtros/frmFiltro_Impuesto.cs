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
    public partial class frmFiltro_Impuesto : Form
    {
        
        public frmFiltro_Impuesto()
        {
            InitializeComponent();
        }

        private void frmFiltro_Impuesto_Load(object sender, EventArgs e)
        {

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
                    this.DGFiltro_Resultados.DataSource = fImpuesto.Buscar(this.TBBuscar.Text, 1);
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

        private void DGFiltro_Resultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string idimpuesto, impuesto, valor, descripcion;

                frmProducto frmPro = frmProducto.GetInstancia();
                frmServicios frmSer = frmServicios.GetInstancia();

                if (frmPro.Examinar)
                {
                    idimpuesto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    impuesto = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    valor = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    descripcion = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmPro.setImpuesto(idimpuesto, impuesto, valor, descripcion);
                    this.Hide();
                }
                if (frmSer.Examinar)
                {
                    idimpuesto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    impuesto = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    valor = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmSer.setImpuesto(idimpuesto, impuesto, valor);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
            {
                //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                DGFiltro_Resultados.CurrentRow.Cells[2].Selected = true;
            }
        }

        private void DGFiltro_Resultados_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
                {
                    string idimpuesto, impuesto, valor, descripcion;

                    frmProducto frmPro = frmProducto.GetInstancia();

                    idimpuesto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    impuesto = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    valor = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    descripcion = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmPro.setImpuesto(idimpuesto, impuesto, valor, descripcion);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }   
        }

        private void DGFiltro_Resultados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string idimpuesto, impuesto, valor, descripcion;

                    frmProducto frmPro = frmProducto.GetInstancia();

                    idimpuesto = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    impuesto = this.DGFiltro_Resultados.CurrentRow.Cells[1].Value.ToString();
                    valor = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    descripcion = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmPro.setImpuesto(idimpuesto, impuesto, valor, descripcion);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

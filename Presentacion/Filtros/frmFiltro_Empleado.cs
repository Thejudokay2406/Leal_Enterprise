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
    public partial class frmFiltro_Empleado : Form
    {
        public frmFiltro_Empleado()
        {
            InitializeComponent();
        }

        private void frmFiltro_Empleado_Load(object sender, EventArgs e)
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
                    this.DGFiltro_Resultados.DataSource = fGestion_Empleados.Buscar(this.TBBuscar.Text, 1);
                    this.DGFiltro_Resultados.Columns[0].Visible = false;

                    lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
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
                frmDepartamento frmDep = frmDepartamento.GetInstancia();

                //Variables Para Los Filtros
                string idempleado, empleado, documento;

                if (frmDep.Filtro)
                {
                    idempleado = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    empleado = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmDep.setEmpleado(idempleado, empleado);
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

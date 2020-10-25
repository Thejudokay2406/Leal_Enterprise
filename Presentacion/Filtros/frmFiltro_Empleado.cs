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
    public partial class frmFiltro_Empleado : Form
    {
        public frmFiltro_Empleado()
        {
            InitializeComponent();
        }

        private void frmFiltro_Empleado_Load(object sender, EventArgs e)
        {

        }

        //private void Mostrar()
        //{
        //    this.dataListado.DataSource = NCliente.Mostrar();
        //    this.OcultarColumnas();
        //    lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        //}

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

        private void TBBuscar_General_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar_General.Text != "")
                {
                    this.DGFiltro_General.DataSource = fGestion_Empleados.Buscar(this.TBBuscar_General.Text, 3);
                    this.DGFiltro_General.Columns[0].Visible = false;

                    lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
                    //this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_General.DataSource = null;
                    this.DGFiltro_General.Enabled = false;
                    this.DGFiltro_General.Text = "Datos Registrados: 0";
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
                frmCliente frmCli = frmCliente.GetInstancia();

                //Variables Para Los Filtros
                string idempleado, empleado, documento;

                if (frmDep.Filtro)
                {
                    idempleado = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    empleado = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    frmDep.setEmpleado(idempleado, empleado);
                    this.Hide();
                }

                if (frmCli.Filtro)
                {
                    idempleado = this.DGFiltro_Resultados.CurrentRow.Cells[0].Value.ToString();
                    empleado = this.DGFiltro_Resultados.CurrentRow.Cells[2].Value.ToString();
                    documento = this.DGFiltro_Resultados.CurrentRow.Cells[3].Value.ToString();
                    frmCli.setEmpleado(idempleado, documento, empleado);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregarEmpl_Factura_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarEmpl_General_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_Facturacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBBuscar_Facturacion.Text != "")
                {
                    this.DGFiltro_Resultados.DataSource = fGestion_Empleados.Buscar(this.TBBuscar_Facturacion.Text, 3);
                    this.DGFiltro_Resultados.Columns[0].Visible = false;

                    lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Resultados.Rows.Count);
                    //this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_Resultados.DataSource = null;
                    this.DGFiltro_Resultados.Enabled = false;
                    this.lblTotal_Facturacion.Text = "Datos Registrados: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

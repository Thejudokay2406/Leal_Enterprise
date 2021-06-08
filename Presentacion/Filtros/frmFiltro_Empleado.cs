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
        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        private string Codigo, Contrato, Sucursal, Departamento, Nombre, Documento, Profesion, Cargo, Email = "";

        public frmFiltro_Empleado()
        {
            InitializeComponent();
        }

        private void frmFiltro_Empleado_Load(object sender, EventArgs e)
        {
            //
            this.Habilitar();
            this.TBIdempleado.Visible = false;

            //
            this.TBBuscar_General.BackColor = Color.FromArgb(3, 155, 229);
            this.TBBuscar_Facturacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Habilitar()
        {
            this.TBCodigo.Enabled = false;
            this.TBCodigo.BackColor = Color.FromArgb(245, 245, 245);
            this.TBContrato.Enabled = false;
            this.TBContrato.BackColor = Color.FromArgb(245, 245, 245);
            this.TBSucursal.Enabled = false;
            this.TBSucursal.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDepartamento.Enabled = false;
            this.TBDepartamento.BackColor = Color.FromArgb(245, 245, 245);
            this.TBEmpleado.Enabled = false;
            this.TBEmpleado.BackColor = Color.FromArgb(245, 245, 245);
            this.TBDocumento.Enabled = false;
            this.TBDocumento.BackColor = Color.FromArgb(245, 245, 245);
            this.TBProfesion.Enabled = false;
            this.TBProfesion.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCargo.Enabled = false;
            this.TBCargo.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCorreo.Enabled = false;
            this.TBCorreo.BackColor = Color.FromArgb(245, 245, 245);
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

                    lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Facturacion.Rows.Count);
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

        private void DGFiltro_Facturacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //frmDepartamento frmDep = frmDepartamento.GetInstancia();
                frmCliente frmCli = frmCliente.GetInstancia();

                //Variables Para Los Filtros
                string idempleado, empleado, documento;

                //if (frmDep.Filtro)
                //{
                //    idempleado = this.DGFiltro_Facturacion.CurrentRow.Cells[0].Value.ToString();
                //    empleado = this.DGFiltro_Facturacion.CurrentRow.Cells[2].Value.ToString();
                //    frmDep.setEmpleado(idempleado, empleado);
                //    this.Hide();
                //}

                if (frmCli.Filtro)
                {
                    idempleado = this.DGFiltro_Facturacion.CurrentRow.Cells[0].Value.ToString();
                    empleado = this.DGFiltro_Facturacion.CurrentRow.Cells[2].Value.ToString();
                    documento = this.DGFiltro_Facturacion.CurrentRow.Cells[3].Value.ToString();
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
            try
            {
                frmCliente frmCli = frmCliente.GetInstancia();

                //Variables Para Los Filtros
                string idempleado, empleado, documento;

                if (frmCli.Filtro)
                {
                    idempleado = this.DGFiltro_Facturacion.CurrentRow.Cells[0].Value.ToString();
                    empleado = this.DGFiltro_Facturacion.CurrentRow.Cells[2].Value.ToString();
                    documento = this.DGFiltro_Facturacion.CurrentRow.Cells[3].Value.ToString();
                    frmCli.setEmpleado(idempleado, documento, empleado);
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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
                    this.DGFiltro_Facturacion.DataSource = fGestion_Empleados.Buscar(this.TBBuscar_Facturacion.Text, 3);
                    this.DGFiltro_Facturacion.Columns[0].Visible = false;

                    lblTotal_Facturacion.Text = "Datos Registrados: " + Convert.ToString(DGFiltro_Facturacion.Rows.Count);
                    //this.DGFiltro_Resultados.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGFiltro_Facturacion.DataSource = null;
                    this.DGFiltro_Facturacion.Enabled = false;
                    this.lblTotal_Facturacion.Text = "Datos Registrados: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGFiltro_General_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmCliente frmCli = frmCliente.GetInstancia();
                string idbanco, asesor, documento;

                if (frmCli.Examinar)
                {
                    idbanco = this.DGFiltro_General.CurrentRow.Cells[0].Value.ToString();
                    asesor = this.DGFiltro_General.CurrentRow.Cells[1].Value.ToString();
                    documento = this.DGFiltro_General.CurrentRow.Cells[2].Value.ToString();
                    frmCli.setEmpleado(idbanco, documento, asesor);
                    this.Hide();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TBBuscar_Facturacion_Enter(object sender, EventArgs e)
        {
            this.TBBuscar_Facturacion.BackColor = Color.Azure;
        }

        private void TBBuscar_General_Enter(object sender, EventArgs e)
        {
            this.TBBuscar_General.BackColor = Color.Azure;
        }

        private void TBBuscar_General_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBBuscar_General.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Facturacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBBuscar_Facturacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void DGFiltro_Facturacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.TBIdempleado.Text = this.DGFiltro_Facturacion.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBIdempleado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fGestion_Empleados.Buscar(this.TBIdempleado.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count != 0)
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos

                    Codigo = Datos.Rows[0][3].ToString();
                    Contrato = Datos.Rows[0][0].ToString();
                    Sucursal = Datos.Rows[0][1].ToString();
                    Departamento = Datos.Rows[0][2].ToString();
                    Nombre = Datos.Rows[0][4].ToString();
                    Documento = Datos.Rows[0][5].ToString();
                    Profesion = Datos.Rows[0][6].ToString();
                    Cargo = Datos.Rows[0][7].ToString();
                    Email = Datos.Rows[0][8].ToString();

                    //Se lleva acabo el complemento de los campos de Texto
                    this.TBCodigo.Text = Codigo;
                    this.TBContrato.Text = Contrato;
                    this.TBSucursal.Text = Sucursal;
                    this.TBDepartamento.Text = Departamento;
                    this.TBEmpleado.Text = Nombre;
                    this.TBDocumento.Text = Documento;
                    this.TBProfesion.Text = Profesion;
                    this.TBCargo.Text = Cargo;
                    this.TBCorreo.Text = Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

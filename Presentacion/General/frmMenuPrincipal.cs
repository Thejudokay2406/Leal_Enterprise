﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMenuPrincipal : Form
    {
        //Parametros Basicos
        public string Idempleado = "";
        public string Empleado = "";
        public string UsuarioLogueado = "";
        public string Idusuario = "";

        //Menu Principal
        public string Menu_Almacen = "";
        public string Menu_Financiera = "";
        public string Menu_GestionHumana = "";
        public string Menu_Inventario = "";
        public string Menu_Reportes = "";
        public string Menu_Sistema = "";
        public string Menu_Ventas = "";

        //Permisos de Operacion Que Vienen de la Base de Datos

        public string SQL_Guardar = "";
        public string SQL_Editar = "";
        public string SQL_Eliminar = "";
        public string SQL_Consultar = "";
        public string SQL_Imprimir = "";

        //
        public string Cede = "";

        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            //toolStripComboBox1.SelectedIndex = 0;

            //
            this.TSEmpleado.Text = Empleado;
            this.TSUsuario.Text = UsuarioLogueado;
            //this.TBEmpleadoLogueado.Text = Empleado;

            this.Seguridad_SQL();

            //
            //textBox1.Enabled = false;
            //textBox1.ForeColor = Color.FromArgb(0, 0, 0);
            //textBox1.BackColor = Color.FromArgb(255, 255, 255);

            //textBox2.Enabled = false;
            //textBox2.ForeColor = Color.FromArgb(0, 0, 0);
            //textBox2.BackColor = Color.FromArgb(255, 255, 255);

            //textBox3.Enabled = false;
            //textBox3.ForeColor=Color.FromArgb(0, 0, 0);
            //textBox3.BackColor=Color.FromArgb(255, 255, 255);
        }


        //private void AbrirFormulario(object formulario)
        //{
        //    if (this.Panel_Contenedor.Controls.Count > 0) this.Panel_Contenedor.Controls.RemoveAt(0);
        //    {
        //        Form fh = formulario as Form;
        //        fh.TopLevel = false;
        //        fh.Dock = DockStyle.Bottom;
        //        this.Panel_Contenedor.Controls.Add(fh);
        //        this.Panel_Contenedor.Tag = fh;
        //        fh.Show();
        //    }
        //}

        private void Seguridad_SQL()
        {
            if (Menu_Almacen == "0")
            {
                this.ficheroToolStripMenuItem.Enabled = false;
            }
            else if (Menu_Financiera == "0")
            {
                this.financieraToolStripMenuItem.Enabled = false;
            }
            else if (Menu_GestionHumana == "0")
            {
                this.gestionHumanaToolStripMenuItem.Enabled = false;
            }
            else if (Menu_Inventario == "0")
            {
                this.operacionesToolStripMenuItem.Enabled = false;
            }
            else if (Menu_Sistema == "0")
            {
                this.sistemaToolStripMenuItem.Enabled = false;
            }
            else if (Menu_Ventas == "0")
            {
                this.ventasToolStripMenuItem.Enabled = false;
            }
        }
       
        private void datosBasicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados frmEmpleados = frmEmpleados.GetInstancia();
            frmEmpleados.MdiParent = this;
            frmEmpleados.Show();

            frmEmpleados.Guardar = Convert.ToString(this.SQL_Guardar);
            frmEmpleados.Editar = Convert.ToString(this.SQL_Editar);
            frmEmpleados.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmEmpleados.Consultar = Convert.ToString(this.SQL_Consultar);
            frmEmpleados.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void departamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartamento frmDepartamento = frmDepartamento.GetInstancia();
            frmDepartamento.MdiParent = this;
            frmDepartamento.Show();

            frmDepartamento.Guardar = Convert.ToString(this.SQL_Guardar);
            frmDepartamento.Editar = Convert.ToString(this.SQL_Editar);
            frmDepartamento.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmDepartamento.Consultar = Convert.ToString(this.SQL_Consultar);
            frmDepartamento.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmMenuPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Escape))
                {
                    DialogResult result = MessageBox.Show("¿Desea Salir del Sistema?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();

                    }
                    else
                    {
                        this.Refresh();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void equiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tipoDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void empaquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpaque frmEmpaque = new frmEmpaque();
            frmEmpaque.MdiParent = this;
            frmEmpaque.Show();

            frmEmpaque.Guardar = Convert.ToString(this.SQL_Guardar);
            frmEmpaque.Editar = Convert.ToString(this.SQL_Editar);
            frmEmpaque.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmEmpaque.Consultar = Convert.ToString(this.SQL_Consultar);
            frmEmpaque.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }
        
        private void bodegaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBodega frmBodega = new frmBodega();
            frmBodega.MdiParent = this;
            frmBodega.Show();;

            frmBodega.Guardar = Convert.ToString(this.SQL_Guardar);
            frmBodega.Editar = Convert.ToString(this.SQL_Editar);
            frmBodega.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmBodega.Consultar = Convert.ToString(this.SQL_Consultar);
            frmBodega.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void proveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProveedor frmProveedor = frmProveedor.GetInstancia();
            frmProveedor.MdiParent = this;
            frmProveedor.Show();

            frmProveedor.Guardar = Convert.ToString(this.SQL_Guardar);
            frmProveedor.Editar = Convert.ToString(this.SQL_Editar);
            frmProveedor.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmProveedor.Consultar = Convert.ToString(this.SQL_Consultar);
            frmProveedor.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void sucurzalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursal frmSucursal = new frmSucursal();
            frmSucursal.MdiParent = this;
            frmSucursal.Show();

            frmSucursal.Guardar = Convert.ToString(this.SQL_Guardar);
            frmSucursal.Editar = Convert.ToString(this.SQL_Editar);
            frmSucursal.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmSucursal.Consultar = Convert.ToString(this.SQL_Consultar);
            frmSucursal.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProducto frmProducto = frmProducto.GetInstancia();
            frmProducto.MdiParent = this;
            frmProducto.Show();

            frmProducto.Guardar = Convert.ToString(this.SQL_Guardar);
            frmProducto.Editar = Convert.ToString(this.SQL_Editar);
            frmProducto.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmProducto.Consultar = Convert.ToString(this.SQL_Consultar);
            frmProducto.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto_Grupo frmProducto_Grupo = new frmProducto_Grupo();
            frmProducto_Grupo.MdiParent = this;
            frmProducto_Grupo.Show();

            frmProducto_Grupo.Guardar = Convert.ToString(this.SQL_Guardar);
            frmProducto_Grupo.Editar = Convert.ToString(this.SQL_Editar);
            frmProducto_Grupo.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmProducto_Grupo.Consultar = Convert.ToString(this.SQL_Consultar);
            frmProducto_Grupo.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarca frmMarca = new frmMarca();
            frmMarca.MdiParent = this;
            frmMarca.Show();

            frmMarca.Guardar = Convert.ToString(this.SQL_Guardar);
            frmMarca.Editar = Convert.ToString(this.SQL_Editar);
            frmMarca.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmMarca.Consultar = Convert.ToString(this.SQL_Consultar);
            frmMarca.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void impuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmImpuesto frmImpuesto = new frmImpuesto();
            frmImpuesto.MdiParent = this;
            frmImpuesto.Show();

            frmImpuesto.Guardar = Convert.ToString(this.SQL_Guardar);
            frmImpuesto.Editar = Convert.ToString(this.SQL_Editar);
            frmImpuesto.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmImpuesto.Consultar = Convert.ToString(this.SQL_Consultar);
            frmImpuesto.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto_Tipo frmProducto_Tipo = new frmProducto_Tipo();
            frmProducto_Tipo.MdiParent = this;
            frmProducto_Tipo.Show();

            frmProducto_Tipo.Guardar = Convert.ToString(this.SQL_Guardar);
            frmProducto_Tipo.Editar = Convert.ToString(this.SQL_Editar);
            frmProducto_Tipo.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmProducto_Tipo.Consultar = Convert.ToString(this.SQL_Consultar);
            frmProducto_Tipo.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario_Ingreso frmInventario_Ingreso = frmInventario_Ingreso.GetInstancia();
            frmInventario_Ingreso.MdiParent = this;
            frmInventario_Ingreso.Show();

            frmInventario_Ingreso.Guardar = Convert.ToString(this.SQL_Guardar);
            frmInventario_Ingreso.Editar = Convert.ToString(this.SQL_Editar);
            frmInventario_Ingreso.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmInventario_Ingreso.Consultar = Convert.ToString(this.SQL_Consultar);
            frmInventario_Ingreso.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void ordenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdenDeCompra frmOrdenDeCompra = frmOrdenDeCompra.GetInstancia();
            frmOrdenDeCompra.MdiParent = this;
            frmOrdenDeCompra.Show();

            frmOrdenDeCompra.Guardar = Convert.ToString(this.SQL_Guardar);
            frmOrdenDeCompra.Editar = Convert.ToString(this.SQL_Editar);
            frmOrdenDeCompra.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmOrdenDeCompra.Consultar = Convert.ToString(this.SQL_Consultar);
            frmOrdenDeCompra.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void inventarioInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario_Inicial frmInventario_Inicial = frmInventario_Inicial.GetInstancia();
            frmInventario_Inicial.MdiParent = this;
            frmInventario_Inicial.Show();

            frmInventario_Inicial.Guardar = Convert.ToString(this.SQL_Guardar);
            frmInventario_Inicial.Editar = Convert.ToString(this.SQL_Editar);
            frmInventario_Inicial.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmInventario_Inicial.Consultar = Convert.ToString(this.SQL_Consultar);
            frmInventario_Inicial.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void liquidarOrdenDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFacturaDeCompra frmFacturaDeCompra = frmFacturaDeCompra.GetInstancia();
            frmFacturaDeCompra.MdiParent = this;
            frmFacturaDeCompra.Show();

            frmFacturaDeCompra.Guardar = Convert.ToString(this.SQL_Guardar);
            frmFacturaDeCompra.Editar = Convert.ToString(this.SQL_Editar);
            frmFacturaDeCompra.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmFacturaDeCompra.Consultar = Convert.ToString(this.SQL_Consultar);
            frmFacturaDeCompra.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void cotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCotizacionDeCompra frmCotizacionDeCompra = frmCotizacionDeCompra.GetInstancia();
            frmCotizacionDeCompra.MdiParent = this;
            frmCotizacionDeCompra.Show();

            frmCotizacionDeCompra.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCotizacionDeCompra.Editar = Convert.ToString(this.SQL_Editar);
            frmCotizacionDeCompra.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCotizacionDeCompra.Consultar = Convert.ToString(this.SQL_Consultar);
            frmCotizacionDeCompra.Imprimir = Convert.ToString(this.SQL_Imprimir);
            frmCotizacionDeCompra.Idempleado = Convert.ToInt32(this.Idempleado);
        }

        private void empaqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpaque frmEmpaque = frmEmpaque.GetInstancia();
            frmEmpaque.MdiParent = this;
            frmEmpaque.Show();

            frmEmpaque.Guardar = Convert.ToString(this.SQL_Guardar);
            frmEmpaque.Editar = Convert.ToString(this.SQL_Editar);
            frmEmpaque.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmEmpaque.Consultar = Convert.ToString(this.SQL_Consultar);
            frmEmpaque.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frmUsuario = new frmUsuario();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void tiposDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipo_Pago frmTipo_Pago = new frmTipo_Pago();
            frmTipo_Pago.MdiParent = this;
            frmTipo_Pago.Show();

            frmTipo_Pago.Guardar = Convert.ToString(this.SQL_Guardar);
            frmTipo_Pago.Editar = Convert.ToString(this.SQL_Editar);
            frmTipo_Pago.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmTipo_Pago.Consultar = Convert.ToString(this.SQL_Consultar);
            frmTipo_Pago.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void datosBasicosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = frmCliente.GetInstancia();
            frmCliente.MdiParent = this;
            frmCliente.Show();

            frmCliente.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCliente.Editar = Convert.ToString(this.SQL_Editar);
            frmCliente.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCliente.Consultar = Convert.ToString(this.SQL_Consultar);
            frmCliente.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCliente_Grupo frmCliente_Grupo =new frmCliente_Grupo();
            frmCliente_Grupo.MdiParent = this;
            frmCliente_Grupo.Show();

            frmCliente_Grupo.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCliente_Grupo.Editar = Convert.ToString(this.SQL_Editar);
            frmCliente_Grupo.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCliente_Grupo.Consultar = Convert.ToString(this.SQL_Consultar);
            frmCliente_Grupo.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void zonasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tiposDeContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoDeContrato frmTipoDeContrato = new frmTipoDeContrato();
            frmTipoDeContrato.MdiParent = this;
            frmTipoDeContrato.Show();

            frmTipoDeContrato.Guardar = Convert.ToString(this.SQL_Guardar);
            frmTipoDeContrato.Editar = Convert.ToString(this.SQL_Editar);
            frmTipoDeContrato.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmTipoDeContrato.Consultar = Convert.ToString(this.SQL_Consultar);
            frmTipoDeContrato.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void tiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCliente_Tipo frmCliente_Tipo = new frmCliente_Tipo();
            frmCliente_Tipo.MdiParent = this;
            frmCliente_Tipo.Show();

            frmCliente_Tipo.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCliente_Tipo.Editar = Convert.ToString(this.SQL_Editar);
            frmCliente_Tipo.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCliente_Tipo.Consultar = Convert.ToString(this.SQL_Consultar);
            frmCliente_Tipo.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void confiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void datosBasicosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBanco frmBanco = new frmBanco();
            frmBanco.MdiParent = this;
            frmBanco.Show();

            frmBanco.Guardar = Convert.ToString(this.SQL_Guardar);
            frmBanco.Editar = Convert.ToString(this.SQL_Editar);
            frmBanco.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmBanco.Consultar = Convert.ToString(this.SQL_Consultar);
            frmBanco.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void contactosBanariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanco_Contacto frmBanco_Contacto =frmBanco_Contacto.GetInstancia();
            frmBanco_Contacto.MdiParent = this;
            frmBanco_Contacto.Show();

            frmBanco_Contacto.Guardar = Convert.ToString(this.SQL_Guardar);
            frmBanco_Contacto.Editar = Convert.ToString(this.SQL_Editar);
            frmBanco_Contacto.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmBanco_Contacto.Consultar = Convert.ToString(this.SQL_Consultar);
            frmBanco_Contacto.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicios frmServicios = frmServicios.GetInstancia();
            frmServicios.MdiParent = this;
            frmServicios.Show();

            frmServicios.Guardar = Convert.ToString(this.SQL_Guardar);
            frmServicios.Editar = Convert.ToString(this.SQL_Editar);
            frmServicios.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmServicios.Consultar = Convert.ToString(this.SQL_Consultar);
            frmServicios.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }
    }
}

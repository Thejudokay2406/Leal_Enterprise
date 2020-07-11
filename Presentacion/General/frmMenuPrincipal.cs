using System;
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

            this.Seguridad_SQL();
        }

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
            frmEmpleados frmEmpleados = new frmEmpleados();
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
            frmDepartamento frmDepartamento = new frmDepartamento();
            frmDepartamento.MdiParent = this;
            frmDepartamento.Show();

            frmDepartamento.Guardar = Convert.ToString(this.SQL_Guardar);
            frmDepartamento.Editar = Convert.ToString(this.SQL_Editar);
            frmDepartamento.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmDepartamento.Consultar = Convert.ToString(this.SQL_Consultar);
            frmDepartamento.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicio frmServicio = new frmServicio();
            frmServicio.MdiParent = this;
            frmServicio.Show();

            frmServicio.Guardar = Convert.ToString(this.SQL_Guardar);
            frmServicio.Editar = Convert.ToString(this.SQL_Editar);
            frmServicio.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmServicio.Consultar = Convert.ToString(this.SQL_Consultar);
            frmServicio.Imprimir = Convert.ToString(this.SQL_Imprimir);
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

        private void tipoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoDeCliente frmTipoDeCliente = new frmTipoDeCliente();
            frmTipoDeCliente.MdiParent = this;
            frmTipoDeCliente.Show();

            frmTipoDeCliente.Guardar = Convert.ToString(this.SQL_Guardar);
            frmTipoDeCliente.Editar = Convert.ToString(this.SQL_Editar);
            frmTipoDeCliente.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmTipoDeCliente.Consultar = Convert.ToString(this.SQL_Consultar);
            frmTipoDeCliente.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void equiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tipoDeClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTipoDeCliente frmTipoDeCliente = new frmTipoDeCliente();
            frmTipoDeCliente.MdiParent = this;
            frmTipoDeCliente.Show();

            frmTipoDeCliente.Guardar = Convert.ToString(this.SQL_Guardar);
            frmTipoDeCliente.Editar = Convert.ToString(this.SQL_Editar);
            frmTipoDeCliente.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmTipoDeCliente.Consultar = Convert.ToString(this.SQL_Consultar);
            frmTipoDeCliente.Imprimir = Convert.ToString(this.SQL_Imprimir);
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
            frmBodega.Show();

            frmBodega.Guardar = Convert.ToString(this.SQL_Guardar);
            frmBodega.Editar = Convert.ToString(this.SQL_Editar);
            frmBodega.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmBodega.Consultar = Convert.ToString(this.SQL_Consultar);
            frmBodega.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            frmCliente.MdiParent = this;
            frmCliente.Show();

            frmCliente.Guardar = Convert.ToString(this.SQL_Guardar);
            frmCliente.Editar = Convert.ToString(this.SQL_Editar);
            frmCliente.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmCliente.Consultar = Convert.ToString(this.SQL_Consultar);
            frmCliente.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void proveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProveedor frmProveedor = new frmProveedor();
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
            frmSucurzal frmSucurzal = new frmSucurzal();
            frmSucurzal.MdiParent = this;
            frmSucurzal.Show();

            frmSucurzal.Guardar = Convert.ToString(this.SQL_Guardar);
            frmSucurzal.Editar = Convert.ToString(this.SQL_Editar);
            frmSucurzal.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmSucurzal.Consultar = Convert.ToString(this.SQL_Consultar);
            frmSucurzal.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = frmProductos.GetInstancia();
            frmProductos.MdiParent = this;
            frmProductos.Show();

            frmProductos.Guardar = Convert.ToString(this.SQL_Guardar);
            frmProductos.Editar = Convert.ToString(this.SQL_Editar);
            frmProductos.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmProductos.Consultar = Convert.ToString(this.SQL_Consultar);
            frmProductos.Imprimir = Convert.ToString(this.SQL_Imprimir);
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrupo frmGrupo = new frmGrupo();
            frmGrupo.MdiParent = this;
            frmGrupo.Show();

            frmGrupo.Guardar = Convert.ToString(this.SQL_Guardar);
            frmGrupo.Editar = Convert.ToString(this.SQL_Editar);
            frmGrupo.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmGrupo.Consultar = Convert.ToString(this.SQL_Consultar);
            frmGrupo.Imprimir = Convert.ToString(this.SQL_Imprimir);
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
            frmTipoDeProducto frmTipoDeProducto = new frmTipoDeProducto();
            frmTipoDeProducto.MdiParent = this;
            frmTipoDeProducto.Show();

            frmTipoDeProducto.Guardar = Convert.ToString(this.SQL_Guardar);
            frmTipoDeProducto.Editar = Convert.ToString(this.SQL_Editar);
            frmTipoDeProducto.Eliminar = Convert.ToString(this.SQL_Eliminar);
            frmTipoDeProducto.Consultar = Convert.ToString(this.SQL_Consultar);
            frmTipoDeProducto.Imprimir = Convert.ToString(this.SQL_Imprimir);
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
    }
}

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
    public partial class frmLogin : Form
    {
        private string Equipo_SQL = "";
        private string HDD_SQL = "";
        private string MacSeguridad_SQL = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.TBUsuario.Focus();
            this.TBContraseña.BackColor = Color.FromArgb(3, 155, 229);

            //Informe de Sesion
            this.TBCopyrigth.Enabled = false;
            this.TBCopyrigth.BackColor = Color.FromArgb(253, 254, 254);
            this.TBDesarrollo.Enabled = false;
            this.TBDesarrollo.BackColor = Color.FromArgb(253, 254, 254);

            //Datos de Seguridad
            this.Seguridad_SQL();
        }

        private void Seguridad_SQL()
        {
            try
            {
                //Se capturan los valores del computador donde esta iniciado
                this.HDD_SQL = Informacion_Computer.Serial_HDD();
                this.MacSeguridad_SQL = Informacion_Computer.MAC_Address();
                this.Equipo_SQL = Informacion_Computer.Nombre_PC();

                //this.TBSerialProcesador.Text = Informacion_Computer.Serial_Procesador();
                //this.TBCodigoDeSeguridad.Text = Informacion_Computer.SO_Informacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void TBUsuario_Enter(object sender, EventArgs e)
        {
            TBUsuario.BackColor = Color.Azure;
        }

        private void TBContraseña_Enter(object sender, EventArgs e)
        {
            TBContraseña.BackColor = Color.Azure;
        }

        private void TBUsuario_Leave(object sender, EventArgs e)
        {
            this.TBUsuario.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBContraseña_Leave(object sender, EventArgs e)
        {
            this.TBContraseña.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.TBContraseña.Focus();
                //this.TBContraseña.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (TBUsuario.Text=="Tecnologia" && TBContraseña.Text=="SQL")
                    {
                        frmEquipos frmEquipos = new frmEquipos();
                        //
                        frmEquipos.ShowDialog();
                    }
                    else
                    {
                        DataTable Datos_Seguridad = Negocio.fEquipos.Seguridad_SQL(Equipo_SQL, HDD_SQL, MacSeguridad_SQL);
                        //Evaluamos si  existen los Datos
                        if (Datos_Seguridad.Rows.Count == 0)
                        {
                            MessageBox.Show("Niveles de Seguridad no Cumplidos", "Leal Enterprise - Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            ////<<<<<<----- Al pasar las pruebas de seguridad se procede a verificar los usuarios ingresados

                            DataTable Datos = Negocio.fUsuarios.Login_SQL(this.TBUsuario.Text, this.TBContraseña.Text);
                            //Evaluamos si  existen los Datos
                            if (Datos.Rows.Count == 0)
                            {
                                MessageBox.Show("Acceso Denegado al Sistema, Usuario o Contraseña Incorrecto. Si el Problema Persiste Contacte al Area de Sistemas", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                frmMenuPrincipal frm = new frmMenuPrincipal();
                                frm.Idempleado = Datos.Rows[0][0].ToString();
                                frm.Idusuario = Datos.Rows[0][1].ToString();
                                frm.Empleado = Datos.Rows[0][2].ToString();
                                frm.UsuarioLogueado = Datos.Rows[0][3].ToString();

                                //Captura de Valores en la Base de Datos

                                frm.SQL_Guardar = Datos.Rows[0][4].ToString();
                                frm.SQL_Editar = Datos.Rows[0][5].ToString();
                                frm.SQL_Eliminar = Datos.Rows[0][6].ToString();
                                frm.SQL_Consultar = Datos.Rows[0][7].ToString();

                                frm.Menu_Almacen = Datos.Rows[0][8].ToString();
                                frm.Menu_Financiera = Datos.Rows[0][9].ToString();
                                frm.Menu_GestionHumana = Datos.Rows[0][10].ToString();
                                //frm.Menu_Productos = Datos.Rows[0][11].ToString();
                                frm.Menu_Reportes = Datos.Rows[0][12].ToString();
                                frm.Menu_Sistema = Datos.Rows[0][13].ToString();
                                frm.Menu_Ventas = Datos.Rows[0][14].ToString();

                                frm.Show();
                                this.Hide();

                            }
                        }
                    }                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Management;
using System.Configuration;

using Negocio;

namespace Presentacion
{
    public partial class frmEquipos : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public bool Filtro = true;

        //Variable para Capturar el Nombre de la Empresa desde la Base de Datos
        public string Empresa = "";

        //Variable para Metodo Eliminar
        private string Eliminacion = null;
        public frmEquipos()
        {
            InitializeComponent();
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.DesHabilitar();

            //Ocultacion de Texbox ID
            this.TBIdequipo.Visible = false;

            //Color para Texboxt Buscar
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);

        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            // Los Campos de Textos se Habilitaran 
            this.TBEquipo.ReadOnly = false;
            this.TBEquipo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDiscoDuro.ReadOnly = false;
            this.TBDiscoDuro.BackColor = Color.FromArgb(3, 155, 229);
            this.CBTipo.Enabled = true;
            this.CBTipo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBMacseguridad.ReadOnly = false;
            this.TBMacseguridad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void DesHabilitar()
        {
            //Panel - Datos Basicos
            this.TBEquipo.ReadOnly = true;
            this.TBEquipo.BackColor = Color.FromArgb(187, 222, 251);
            this.TBDiscoDuro.ReadOnly = true;
            this.TBDiscoDuro.BackColor = Color.FromArgb(187, 222, 251);
            this.CBTipo.Enabled = false;
            this.CBTipo.BackColor = Color.FromArgb(187, 222, 251);
            this.TBMacseguridad.ReadOnly = true;
            this.TBMacseguridad.BackColor = Color.FromArgb(187, 222, 251);

            //Desabilitacion de Botones
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = false;
            this.btnGuardar.Enabled = false;
            this.btnEliminar.Enabled = false;

        }

        private void Limpiar()
        {
            //Panel - Datos Basicos
            this.TBIdequipo.Clear();
            this.TBEquipo.Clear();
            this.TBDiscoDuro.Clear();
            this.CBTipo.SelectedItem = 0;
            this.TBMacseguridad.Clear();
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                //Datos Basicos
                if (this.TBEquipo.Text == string.Empty)
                {
                    MensajeError("Por Favor Ingrese el Nombre del Equipo a Registrar");
                    TBEquipo.BackColor = Color.FromArgb(250, 235, 215);
                }
                else if (this.CBTipo.SelectedIndex == 0)
                {
                    MensajeError("Por Favor Seleccione el Tipo de Equipo a Registrar");
                    CBTipo.BackColor = Color.FromArgb(250, 235, 215);
                }

                else
                {
                    if (this.IsNuevo)
                    {
                        rptaDatosBasicos = fEquipos.Guardar_DatosBasicos

                            (
                                //Panel de Datos Basicos
                                this.TBEquipo.Text, this.TBDiscoDuro.Text, this.CBTipo.Text, this.TBMacseguridad.Text, 1, 1
                            );
                    }

                    else if (this.IsEditar)
                    {
                        rptaDatosBasicos = fEquipos.Editar_DatosBasicos

                            (
                                //Panel de Datos Basicos
                                2, Convert.ToInt32(this.TBIdequipo.Text), this.TBEquipo.Text, this.TBDiscoDuro.Text, this.CBTipo.Text, this.TBMacseguridad.Text, 1
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Registro Completado");
                        }
                        else if (this.IsEditar)
                        {
                            this.MensajeOk("Actualizacion Completada");
                        }
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    this.IsEditar = false;
                    this.IsNuevo = false;
                    this.DesHabilitar();
                    this.Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public static String Serial_HDD()
        {
            ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection mcol = mangnmt.GetInstances();
            string result = "";
            foreach (ManagementObject strt in mcol)
            {
                result += Convert.ToString(strt["VolumeSerialNumber"]);
            }
            return result;
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


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Se procede habilitar los campos de textos
                this.Habilitar();
                this.Limpiar();

                // Se procede habilitar los Botones Basicos
                // Los Campos de Textos y Botones de Examinar

                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEliminar.Enabled = false;
                this.btnEditar.Enabled = false;

                // Se hace enfasis (Focus) Al Iniciar el Evento Click 
                // sobre el Campo Con Nombre Proveedor

                this.TBEquipo.Focus();
                this.IsNuevo = true;

                //Se capturan los valores del computador donde esta iniciado
                this.TBDiscoDuro.Text = Informacion_Computer.Serial_HDD();
                this.TBMacseguridad.Text = Informacion_Computer.MAC_Address();
                this.TBEquipo.Text = Informacion_Computer.Nombre_PC();

                //this.TBSerialProcesador.Text = Informacion_Computer.Serial_Procesador();
                //this.TBCodigoDeSeguridad.Text = Informacion_Computer.SO_Informacion();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Guardar_SQL();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}

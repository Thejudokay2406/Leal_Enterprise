using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Negocio;

namespace Presentacion
{
    public partial class frmConfigurador_SQLServer : Form
    {
        public frmConfigurador_SQLServer()
        {
            InitializeComponent();
        }

        private void frmConfigurador_SQLServer_Load(object sender, EventArgs e)
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

        private void Guardar_SQL()
        {
            try
            {
                //string rptaDatosBasicos = "";

                //// <<<<<<------ Panel Datos Basicos ------>>>>>

                //if (this.TBServidor.Text == string.Empty)
                //{
                //    MensajeError("Ingrese el nombre del Marca a registrar");
                //}
                //else if (this.TBUsuario.Text == string.Empty)
                //{
                //    MensajeError("Ingrese la Descripcion de la Marca");
                //}
                //else if (this.TBContraseña.Text == string.Empty)
                //{
                //    MensajeError("Ingrese la Descripcion de la Marca");
                //}

                //else
                //{

                //    rptaDatosBasicos = fconfi.Guardar_DatosBasicos(1, this.TBCodigo.Text, this.TBNombre.Text, this.TBDescripcion.Text, this.TBReferencia.Text, this.TBObservacion.Text);

                //    if (rptaDatosBasicos.Equals("OK"))
                //    {
                //        if (this.Digitar)
                //        {
                //            this.MensajeOk("Solicitud de Registro - Leal Enterprise \n\n" + "La Marca: " + this.TBNombre.Text + " ha Exitosamente");
                //        }

                //        else
                //        {
                //            this.MensajeOk("Los Datos de la Marca: " + this.TBNombre.Text + " \n\n han Sido Modificados Exitosamente");
                //            //MessageBox.Show("la suma de los números es: " + suma + "\ny la diferencia de los números es :" + diferen);
                //        }
                //    }
                //    else
                //    {
                //        this.MensajeError(rptaDatosBasicos);
                //    }

                //    //Llamada de Clase
                //    //this.Digitar = true;
                //    //this.Botones();
                //    //this.Limpiar_Datos();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void btnLectura_Click(object sender, EventArgs e)
        {
            try
            {
                string Valor = ConfigurationManager.AppSettings["Servidor"];
                MessageBox.Show(Valor);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["Servidor"].Value = textBox1.Text;
                config.Save(ConfigurationSaveMode.Modified);

                MessageBox.Show("ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            ////try
            ////{
            ////    string valor_nuevo = textBox1.Text.Trim();

            ////    XmlDocument xmlDoc = new XmlDocument();

            ////    //se establece la ruta por defecto en la aplicacion
            ////    xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ////    foreach (XmlElement element in xmlDoc.DocumentElement)
            ////    {
            ////        if (element.Name.Equals("appSettings"))
            ////        {
            ////            foreach (XmlNode node in element.ChildNodes)
            ////            {
            ////                if (node.Attributes[0].Value == "Servidor")
            ////                    node.Attributes[1].Value = valor_nuevo;
            ////            }
            ////        }
            ////    }

            ////    xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ////    ConfigurationManager.RefreshSection("appSettings");
            ////}
            ////catch (Exception ex)
            ////{
            ////    MessageBox.Show(ex.Message + ex.StackTrace);
            ////}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Metodo Guardar y editar
                this.Guardar_SQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

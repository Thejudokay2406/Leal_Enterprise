using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Presentacion
{
    public partial class frmConfigurador_SQLServer : Form
    {
        public frmConfigurador_SQLServer()
        {
            InitializeComponent();
        }

        private void btnLectura_Click(object sender, EventArgs e)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader("E:\\Proyectos C#\\Leal_Enterprise\\Datos\\bin\\Release\\Datos.dll");
                String ultimaetiqueta = "";
                while (xmlTextReader.Read())
                {
                    if (xmlTextReader.NodeType == XmlNodeType.Element)
                    {
                        richTextBox1.Text += (new string(' ', xmlTextReader.Depth * 3) + "<" + xmlTextReader.Name + ">");
                        ultimaetiqueta = xmlTextReader.Name;
                        continue;
                    }
                    if (xmlTextReader.NodeType == XmlNodeType.Text)
                    {
                        richTextBox1.Text += xmlTextReader.ReadContentAsString() + "</" + ultimaetiqueta + ">";
                    }
                    else
                    {
                        richTextBox1.Text += "/r";
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

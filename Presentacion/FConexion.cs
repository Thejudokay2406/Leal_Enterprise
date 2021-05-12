using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conexion_SQL;

namespace Presentacion
{
    public partial class FConexion : Form
    {
        public FConexion()
        {
            InitializeComponent();
        }

        private void FConexion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nConexion = "Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtDB.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPass.Text + "";
            Conexion_SQL01.cambiarConexion(nConexion);
        }
    }
}

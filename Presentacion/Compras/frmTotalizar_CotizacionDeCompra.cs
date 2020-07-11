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
    public partial class frmTotalizar_CotizacionDeCompra : Form
    {
        //
        public int Vencimiento;
        
        //Instancia para el Filtro de los productos 
        private static frmTotalizar_CotizacionDeCompra _Instancia;

        public static frmTotalizar_CotizacionDeCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmTotalizar_CotizacionDeCompra();
            }
            return _Instancia;
        }

        public frmTotalizar_CotizacionDeCompra()
        {
            InitializeComponent();
        }

        private void frmTotalizar_CotizacionDeCompra_Load(object sender, EventArgs e)
        {
            this.Habilitar();
            this.AutoComplementar();
        }

        private void Habilitar()
        {
            //
            this.TBSubTotal.Enabled = false;
            this.TBSubTotal.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescuento.Enabled = false;
            this.TBDescuento.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescuento_Porcentaje.Enabled = false;
            this.TBDescuento_Porcentaje.BackColor = Color.FromArgb(72, 209, 204);
            this.TBImpuesto_Valor.Enabled = false;
            this.TBImpuesto_Valor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorGeneral.Enabled = false;
            this.TBValorGeneral.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBCreditoMora.Enabled = false;
            this.TBCreditoMora.BackColor = Color.FromArgb(72, 209, 204);
            this.TBCreditoDisponible.Enabled = false;
            this.TBCreditoDisponible.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBValorDeEnvio.ReadOnly = false;
            this.TBValorDeEnvio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTipoDePago.ReadOnly = false;
            this.TBTipoDePago.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDiasDeEntrega.ReadOnly = false;
            this.TBDiasDeEntrega.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void AutoComplementar()
        {
            try
            {
                //
                frmCotizacionDeCompra frmCotiCompra = frmCotizacionDeCompra.GetInstancia();

                //
                double ValorFinal, Operacion, SubTotal;

                //
                this.TBSubTotal.Text = frmCotiCompra.TBSubTotal.Text;
                this.TBDescuento_Porcentaje.Text = frmCotiCompra.TBDescuento.Text;
                this.TBValorGeneral.Text = frmCotiCompra.TBValorFinal.Text;

                //
                this.TBCreditoMora.Text = frmCotiCompra.TBCreditoEnMora.Text;
                this.TBCreditoDisponible.Text = frmCotiCompra.TBCreditoDisponible.Text;

                //
                SubTotal = Convert.ToDouble(TBSubTotal.Text);
                ValorFinal = Convert.ToDouble(TBValorGeneral.Text);
                Operacion = SubTotal - ValorFinal;
                
                //Formato de Texboxt
                this.TBDescuento.Text = Operacion.ToString("##,##0.00");

                //Validacion de Chexbox
                if (CHVencimiento.Checked)
                {
                    this.Vencimiento = 1;
                }
                else
                {
                    this.Vencimiento = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setFiltro(string subtotal, string descuento, string valorgeneral, string creditomora, string creditodisponible)
        {
            this.TBSubTotal.Text = subtotal;
            this.TBDescuento.Text = descuento;
            this.TBValorGeneral.Text = valorgeneral;

            //
            this.TBCreditoMora.Text = creditomora;
            this.TBCreditoDisponible.Text = creditodisponible;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCotizacionDeCompra frmCotCompra = frmCotizacionDeCompra.GetInstancia();
                frmCotCompra.Guardar_SQL();

                //Se cierra el formulario de totalizacion
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmTotalizar_CotizacionDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}

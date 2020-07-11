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
    public partial class frmTotalizar_OrdenDeCompra : Form
    {
        //Instancia para el Filtro de los productos 
        private static frmTotalizar_OrdenDeCompra _Instancia;

        public static frmTotalizar_OrdenDeCompra GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmTotalizar_OrdenDeCompra();
            }
            return _Instancia;
        }

        public frmTotalizar_OrdenDeCompra()
        {
            InitializeComponent();
        }

        private void frmTotalizar_OrdenDeCompra_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Habilitar();
        }

        private void Habilitar()
        {
            //
            this.TBValorCotizado.Enabled = false;
            this.TBValorCotizado.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescuento_Porcentaje.Enabled = false;
            this.TBDescuento_Porcentaje.BackColor = Color.FromArgb(72, 209, 204);
            this.TBDescuento_Cotizado.Enabled = false;
            this.TBDescuento_Cotizado.BackColor = Color.FromArgb(72, 209, 204);
            this.TBValorFinal_Cotizado.Enabled = false;
            this.TBValorFinal_Cotizado.BackColor = Color.FromArgb(72, 209, 204);
            this.TBImpuesto_Cotizado.Enabled = false;
            this.TBImpuesto_Cotizado.BackColor = Color.FromArgb(72, 209, 204);
            this.TBTipoDePago_Cotizado.Enabled = false;
            this.TBTipoDePago_Cotizado.BackColor = Color.FromArgb(72, 209, 204);
            this.TBEnvio_Cotizado.Enabled = false;
            this.TBEnvio_Cotizado.BackColor = Color.FromArgb(72, 209, 204);

            //
            this.TBTipodepago.ReadOnly = false;
            this.TBTipodepago.BackColor = Color.FromArgb(3, 155, 229);
            this.TBAdelanto.ReadOnly = false;
            this.TBAdelanto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBAdelanto_Porcentaje.ReadOnly = false;
            this.TBAdelanto_Porcentaje.BackColor = Color.FromArgb(3, 155, 229);
            this.TBEfectivo.ReadOnly = false;
            this.TBEfectivo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCredito.ReadOnly = false;
            this.TBCredito.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCheques.ReadOnly = false;
            this.TBCheques.BackColor = Color.FromArgb(3, 155, 229);
            this.TBTransferencia.ReadOnly = false;
            this.TBTransferencia.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCreditoDisponible.ReadOnly = false;
            this.TBCreditoDisponible.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDescuento_Final.ReadOnly = false;
            this.TBDescuento_Final.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDias.ReadOnly = false;
            this.TBDias.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValorGeneral.ReadOnly = false;
            this.TBValorGeneral.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void CBRetencion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void frmTotalizar_OrdenDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}

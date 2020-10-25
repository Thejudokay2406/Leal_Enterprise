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
    public partial class frmCliente : Form
    {
        //Instancia para el Filtro de los Clientes 
        private static frmCliente _Instancia;

        public static frmCliente GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmCliente();
            }
            return _Instancia;
        }


        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio";

        // ******************************************* Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar ************************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        // ******************************************* Parametros para AutoCompletar los Texboxt *********************************************************

        //Panel Datos Basicos
        private string Codigo, Idtipo, Nombre, Documento, Telefono, Movil, Correo, Pais, Ciudad, Departamento = "";

        //Panel Datos de Envio
        private string PaisDeEnvio, CiudadDeEnvio, Receptor, DireccionPrincipal, TelefonoDeEnvio, MovilDeEnvio, Observacion = "";

        //Panel Datos Financieros
        private string Diasdecredito, Diasdeprorroga, Interesespormora, Creditominimo, Creditomaximo = "";

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Auto_Combobox();

            //Focus a Texboxt y Combobox
            this.TBDat_Nombre.Select();

            //Ocultacion de Texboxt
            this.TBIdcliente.Visible = false;
        }

        private void Habilitar()
        {
            //Datos Basicos
            this.CBTipo.Enabled = true;
            this.CBTipo.BackColor = Color.FromArgb(3, 155, 229);
            this.CBGrupo.Enabled = true;
            this.CBGrupo.BackColor = Color.FromArgb(3, 155, 229);

            this.TBDat_Codigo.ReadOnly = false;
            this.TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Codigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Codigo.Text = Campo;
            this.TBDat_Nombre.ReadOnly = false;
            this.TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Nombre.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Nombre.Text = Campo;
            this.TBDat_Documento.ReadOnly = false;
            this.TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Documento.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBDat_Documento.Text = Campo;
            this.TBDat_Telefono.ReadOnly = false;
            this.TBDat_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Movil.ReadOnly = false;
            this.TBDat_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_TelefonoAux.ReadOnly = false;
            this.TBDat_TelefonoAux.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_MovilAux.ReadOnly = false;
            this.TBDat_MovilAux.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Correo.ReadOnly = false;
            this.TBDat_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Pais.ReadOnly = false;
            this.TBDat_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Ciudad.ReadOnly = false;
            this.TBDat_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Departamento.ReadOnly = false;
            this.TBDat_Departamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_PaginaWeb.ReadOnly = false;
            this.TBDat_PaginaWeb.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Direccion.ReadOnly = false;
            this.TBDat_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDat_Observacion.ReadOnly = false;
            this.TBDat_Observacion.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBDat_Ahorro.ReadOnly = false;
            //this.TBDat_Ahorro.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBDat_CreditoDisp.ReadOnly = false;
            //this.TBDat_CreditoDisp.BackColor = Color.FromArgb(3, 155, 229);
            //this.TBDat_CreditoFact.ReadOnly = false;
            //this.TBDat_CreditoFact.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Envio
            this.TBDes_Sucurzal.ReadOnly = false;
            this.TBDes_Sucurzal.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Pais.ReadOnly = false;
            this.TBDes_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Ciudad.ReadOnly = false;
            this.TBDes_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Departamento.ReadOnly = false;
            this.TBDes_Departamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Receptor.ReadOnly = false;
            this.TBDes_Receptor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Barrio.ReadOnly = false;
            this.TBDes_Barrio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Apartamento.ReadOnly = false;
            this.TBDes_Apartamento.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Direccion.ReadOnly = false;
            this.TBDes_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Movil.ReadOnly = false;
            this.TBDes_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBDes_Observacion.ReadOnly = false;
            this.TBDes_Observacion.BackColor = Color.FromArgb(3, 155, 229);

            //Datos Financieros
            this.TBFin_CodigoBanco.Enabled = false;
            this.TBFin_CodigoBanco.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFin_Banco.Enabled = false;
            this.TBFin_Banco.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFin_NumCuenta.ReadOnly = false;
            this.TBFin_NumCuenta.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Creditos
            this.TBCre_CreditoMinimo.ReadOnly = false;
            this.TBCre_CreditoMinimo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_CreditoMaximo.ReadOnly = false;
            this.TBCre_CreditoMaximo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_DebitoMinimo.ReadOnly = false;
            this.TBCre_DebitoMinimo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_CuotaMinima.ReadOnly = false;
            this.TBCre_CuotaMinima.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_CuotaMaxima.ReadOnly = false;
            this.TBCre_CuotaMaxima.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_Diasdecredito.ReadOnly = false;
            this.TBCre_Diasdecredito.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_DiasDeProrroga.ReadOnly = false;
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_InteresMora.ReadOnly = false;
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_DebitoMaximo.ReadOnly = false;
            this.TBCre_DebitoMaximo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCre_Intereses.ReadOnly = false;
            this.TBCre_Intereses.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Facturacion
            this.TBFac_Cliente.ReadOnly = false;
            this.TBFac_Cliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Asesor.Enabled = false;
            this.TBFac_Asesor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFac_DocumentoCliente.ReadOnly = false;
            this.TBFac_DocumentoCliente.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_DocumentoAsesor.Enabled = false;
            this.TBFac_DocumentoAsesor.BackColor = Color.FromArgb(72, 209, 204);
            this.TBFac_Movil.ReadOnly = false;
            this.TBFac_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Correo.ReadOnly = false;
            this.TBFac_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Pais.ReadOnly = false;
            this.TBFac_Pais.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Ciudad.ReadOnly = false;
            this.TBFac_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBFac_Departamento.ReadOnly = false;
            this.TBFac_Departamento.BackColor = Color.FromArgb(3, 155, 229);

            //Datos de Contacto
            this.TBCon_Contacto.ReadOnly = false;
            this.TBCon_Contacto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Ciudad.ReadOnly = false;
            this.TBCon_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Direccion.ReadOnly = false;
            this.TBCon_Direccion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Telefono.ReadOnly = false;
            this.TBCon_Telefono.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Movil.ReadOnly = false;
            this.TBCon_Movil.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Correo.ReadOnly = false;
            this.TBCon_Correo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCon_Parentesco.ReadOnly = false;
            this.TBCon_Parentesco.BackColor = Color.FromArgb(3, 155, 229);

            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.CBTipo.SelectedIndex = 0;
            this.CBGrupo.SelectedIndex = 0;
            this.TBDat_Codigo.Clear();
            this.TBDat_Codigo.Text = Campo;
            this.TBDat_Nombre.Clear();
            this.TBDat_Nombre.Text = Campo;
            this.TBDat_Documento.Clear();
            this.TBDat_Documento.Text = Campo;

            this.TBDat_Telefono.Clear();
            this.TBDat_Movil.Clear();
            this.TBDat_TelefonoAux.Clear();
            this.TBDat_MovilAux.Clear();
            this.TBDat_Correo.Clear();
            this.TBDat_Pais.Clear();
            this.TBDat_Ciudad.Clear();
            this.TBDat_Departamento.Clear();
            this.TBDat_PaginaWeb.Clear();
            this.TBDat_Direccion.Clear();
            this.TBDat_Observacion.Clear();
            //this.TBDat_Ahorro.Clear();
            //this.TBDat_CreditoDisp.Clear();
            //this.TBDat_CreditoFact.Clear();

            this.CH_Contado.Checked = true;
            this.CH_Credito.Checked = true;
            this.CH_Efectivo.Checked = true;
            this.CH_Efectivo.Checked = true;

            //Datos de Envio
            this.TBDes_Sucurzal.Clear();
            this.TBDes_Pais.Clear();
            this.TBDes_Ciudad.Clear();
            this.TBDes_Departamento.Clear();
            this.TBDes_Receptor.Clear();
            this.TBDes_Barrio.Clear();
            this.TBDes_Apartamento.Clear();
            this.TBDes_Direccion.Clear();
            this.TBDes_Movil.Clear();
            this.TBDes_Observacion.Clear();

            //Datos Financieros
            this.TBFin_CodigoBanco.Clear();
            this.TBFin_Banco.Enabled = false;
            this.TBFin_NumCuenta.Clear();
            this.CBFin_Cuenta.SelectedIndex = 0;

            //Datos de Creditos
            this.TBCre_CreditoMinimo.Clear();
            this.TBCre_CreditoMaximo.Clear();
            this.TBCre_DebitoMinimo.Clear();
            this.TBCre_CuotaMinima.Clear();
            this.TBCre_CuotaMaxima.Clear();
            this.TBCre_Diasdecredito.Clear();
            this.TBCre_DiasDeProrroga.Clear();
            this.TBCre_InteresMora.Clear();
            this.TBCre_DebitoMaximo.Clear();
            this.TBCre_Intereses.Clear();

            //Datos de Facturacion
            this.TBFac_Cliente.Clear();
            this.TBFac_Asesor.Clear();
            this.TBFac_DocumentoCliente.Clear();
            this.TBFac_DocumentoAsesor.Clear();
            this.TBFac_Movil.Clear();
            this.TBFac_Correo.Clear();
            this.TBFac_Pais.Clear();
            this.TBFac_Ciudad.Clear();
            this.TBFac_Departamento.Clear();
            this.CH_Facturacion.Checked = false;

            //Datos de Contacto
            this.TBCon_Contacto.Clear();
            this.TBCon_Ciudad.Clear();
            this.TBCon_Direccion.Clear();
            this.TBCon_Telefono.Clear();
            this.TBCon_Movil.Clear();
            this.TBCon_Correo.Clear();
            this.TBCon_Parentesco.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TCPrincipal.SelectedIndex = 0;
            this.TBDat_Codigo.Select();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnEliminar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
        }

        private void Auto_Combobox()
        {
            try
            {
                this.CBTipo.DataSource = fTipoDeCliente.Lista();
                this.CBTipo.ValueMember = "Codigo";
                this.CBTipo.DisplayMember = "Tipo";

                this.CBGrupo.DataSource = fGrupoDeCliente.Lista();
                this.CBGrupo.ValueMember = "Codigo";
                this.CBGrupo.DisplayMember = "Grupo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void setEmpleado(string idempleado, string documento, string asesor)
        {
            this.TBIdempleado.Text = idempleado;
            this.TBFac_DocumentoAsesor.Text = documento;
            this.TBFac_Asesor.Text = asesor;
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBDat_Nombre.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Cliente a registrar");
                }
                else if (this.TBDat_Documento.Text == Campo)
                {
                    MensajeError("Ingrese el numero del Documento del Cliente");
                }
                else if (this.TBDat_Codigo.Text == Campo)
                {
                    MensajeError("Ingrese el Codigo del Cliente");
                }
                else if (this.CBTipo.SelectedIndex == 0)
                {
                    MensajeError("Seleccione el Tipo de Cliente");
                }

                else
                {
                    if (this.Digitar)
                    {
                        //rptaDatosBasicos = fCliente.Guardar_DatosBasicos

                        //    (
                        //         //Datos Auxiliares
                        //         1,

                        //         //Panel Datos Basicos
                        //         Convert.ToInt32(this.CBTipo.SelectedValue), this.TBCodigo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBTelefono.Text,
                        //         this.TBMovil.Text, this.TBCorreo.Text, this.TBPais.Text, this.TBCiudad.Text, this.TBDepartamento.Text,

                        //         //
                        //         this.TBPais_01.Text, this.TBCiudad_01.Text, this.TBReceptor.Text, this.TBDireccionPrincipal.Text, this.TBDireccion01.Text,
                        //         this.TBDireccion02.Text, this.TBTelefono_01.Text, this.TBMovil_01.Text, this.TBObservacion_01.Text,

                        //         //
                        //         this.CBTieneCredito.Text, this.TBLimiteDeCredito.Text, this.TBDiasdecredito.Text, this.TBDiasDeProrroga.Text,
                        //         this.TBInteresesmora.Text, this.TBCreditoMinimo.Text, this.TBCreditoMaximo.Text,

                        //         1
                        //    );
                    }

                    else
                    {
                        //rptaDatosBasicos = fCliente.Editar_DatosBasicos

                        //    (
                        //         //Datos Auxiliares
                        //         1, Convert.ToInt32(this.TBIdcliente.Text),

                        //         //Panel Datos Basicos
                        //         Convert.ToInt32(this.CBTipo.SelectedValue), this.TBCodigo.Text, this.TBNombre.Text, this.TBDocumento.Text, this.TBTelefono.Text,
                        //         this.TBMovil.Text, this.TBCorreo.Text, this.TBPais.Text, this.TBCiudad.Text, this.TBDepartamento.Text,

                        //         //
                        //         this.TBPais_01.Text, this.TBCiudad_01.Text, this.TBReceptor.Text, this.TBDireccionPrincipal.Text, this.TBDireccion01.Text,
                        //         this.TBDireccion02.Text, this.TBTelefono_01.Text, this.TBMovil_01.Text, this.TBObservacion_01.Text,

                        //         //
                        //         this.CBTieneCredito.Text, this.TBLimiteDeCredito.Text, this.TBDiasdecredito.Text, this.TBDiasDeProrroga.Text,
                        //         this.TBInteresesmora.Text, this.TBCreditoMinimo.Text, this.TBCreditoMaximo.Text,

                        //         2
                        //    );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Registro Exitoso");
                        }

                        else
                        {
                            this.MensajeOk("Registro Actualizado");
                        }
                    }

                    else
                    {
                        this.MensajeError(rptaDatosBasicos);
                    }

                    //Llamada de Clase
                    this.Digitar = true;
                    this.Botones();
                    this.Limpiar_Datos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Digitar)
                {
                    if (Guardar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }

                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Guardar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Limpiar_Datos();
                    }
                }

                else
                {
                    if (Editar == "1")
                    {
                        //Metodo Guardar y editar
                        this.Guardar_SQL();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Editar Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Llamada de Clase
                        this.Limpiar_Datos();
                    }
                }
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
                this.Limpiar_Datos();

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultados.DataSource = null;
                this.DGResultados.Enabled = false;
                this.lblTotal.Text = "Datos Registrados: 0";
                this.TBBuscar.Text="";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Eliminar == "1")
                {

                    DialogResult Opcion;
                    string Respuesta = "";
                    int Eliminacion;

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGResultados.SelectedRows.Count > 0)
                        {
                            Eliminacion = Convert.ToInt32(DGResultados.CurrentRow.Cells["Codigo"].Value.ToString());
                            Respuesta = Negocio.fCliente.Eliminar(Eliminacion, 0);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Registro Eliminado Correctamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }

                        //Botones Comunes
                        this.TBBuscar.Text = "";
                        this.Limpiar_Datos();
                    }
                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Asesor_Click(object sender, EventArgs e)
        {
            frmFiltro_Empleado frmFiltro_Empleado = new frmFiltro_Empleado();
            frmFiltro_Empleado.ShowDialog();
        }


        private void TBIdcliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fCliente.Buscar(this.TBIdcliente.Text, 2);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise - Consulta de Registro Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos
                    Codigo = Datos.Rows[0][0].ToString();
                    Idtipo = Datos.Rows[0][1].ToString();
                    Nombre = Datos.Rows[0][2].ToString();
                    Documento = Datos.Rows[0][3].ToString();
                    Telefono = Datos.Rows[0][4].ToString();
                    Movil = Datos.Rows[0][5].ToString();
                    Correo = Datos.Rows[0][6].ToString();
                    Pais = Datos.Rows[0][7].ToString();
                    Ciudad = Datos.Rows[0][8].ToString();
                    Departamento = Datos.Rows[0][9].ToString();

                    //Panel Datos de Envio
                    PaisDeEnvio = Datos.Rows[0][10].ToString();
                    CiudadDeEnvio = Datos.Rows[0][11].ToString();
                    Receptor = Datos.Rows[0][12].ToString();
                    DireccionPrincipal = Datos.Rows[0][13].ToString();
                    TelefonoDeEnvio = Datos.Rows[0][16].ToString();
                    MovilDeEnvio = Datos.Rows[0][17].ToString();
                    Observacion = Datos.Rows[0][18].ToString();

                    //Panel Datos Financieros
                    Diasdecredito = Datos.Rows[0][21].ToString();
                    Diasdeprorroga = Datos.Rows[0][22].ToString();
                    Interesespormora = Datos.Rows[0][23].ToString();
                    Creditominimo = Datos.Rows[0][24].ToString();
                    Creditomaximo = Datos.Rows[0][25].ToString();

                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos


                    //Panel Datos Basicos
                    this.TBDat_Codigo.Text = Codigo;
                    this.CBTipo.SelectedValue = Idtipo;
                    this.TBDat_Nombre.Text = Nombre;
                    this.TBDat_Documento.Text = Documento;
                    this.TBDat_Telefono.Text = Telefono;
                    this.TBDat_Movil.Text = Movil;
                    this.TBDat_Correo.Text = Correo;
                    this.TBDat_Pais.Text = Pais;
                    this.TBDat_Ciudad.Text = Ciudad;
                    this.TBDat_Departamento.Text = Departamento;

                    //Panel Datos de Envio
                    this.TBDes_Pais.Text = PaisDeEnvio;
                    this.TBDes_Ciudad.Text = CiudadDeEnvio;
                    this.TBDes_Receptor.Text = Receptor;
                    this.TBDes_Direccion.Text = DireccionPrincipal;
                    this.TBDes_Movil.Text = TelefonoDeEnvio;
                    this.TBDes_Movil.Text = MovilDeEnvio;
                    this.TBDes_Observacion.Text = Observacion;

                    //Panel Datos Financieros
                    this.TBCre_Diasdecredito.Text = Diasdecredito;
                    this.TBCre_DiasDeProrroga.Text = Diasdeprorroga;
                    this.TBCre_InteresMora.Text = Interesespormora;
                    this.TBCre_CreditoMinimo.Text = Creditominimo;
                    this.TBCre_CreditoMaximo.Text = Creditomaximo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Editar == "1")
                {
                    //
                    this.Digitar = false;
                    this.Botones();

                    //Se procede a completar los campos de textos segun
                    //la consulta realizada en la base de datos
                    this.TBIdcliente.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                }
                else
                {
                    MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DGResultados_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    try
                    {
                        if (Editar == "1")
                        {
                            //
                            this.Digitar = false;
                            this.Botones();

                            //Se procede a completar los campos de textos segun
                            //la consulta realizada en la base de datos
                            this.TBIdcliente.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);

                        }
                        else
                        {
                            MessageBox.Show("El Usuario Iniciado Actualmente no Contiene Permisos Para Actualizar Datos en el Sistema", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CBTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBTipo.SelectedIndex != 0)
            {
                this.TBDat_Nombre.Select();
            }
        }

        //********************** PANEL DATOS BASICOS - ENTER *********************************************
        private void TBDat_Nombre_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Codigo_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Documento_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Telefono_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Movil_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_TelefonoAux_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_MovilAux_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Correo_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Pais_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Ciudad_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Departamento_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_PaginaWeb_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Direccion_Enter(object sender, EventArgs e)
        {

        }

        private void TBDat_Observacion_Enter(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE FACTURACION - ENTER *********************************************

        private void TBFac_DocumentoCliente_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Cliente_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Movil_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Pais_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Ciudad_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Departamento_Enter(object sender, EventArgs e)
        {

        }

        private void TBFac_Correo_Enter(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE CREDITO - ENTER *********************************************

        private void TBCre_CreditoMinimo_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_CreditoMaximo_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_CuotaMinima_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_CuotaMaxima_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_Diasdecredito_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_DiasDeProrroga_Enter(object sender, EventArgs e)
        {

        }
                
        private void TBCre_DebitoMinimo_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_DebitoMaximo_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_Intereses_Enter(object sender, EventArgs e)
        {

        }

        private void TBCre_InteresMora_Enter(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE DESPACHO - ENTER *********************************************

        private void TBDes_Sucurzal_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Pais_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Ciudad_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Departamento_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Receptor_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Barrio_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Apartamento_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Movil_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Direccion_Enter(object sender, EventArgs e)
        {

        }

        private void TBDes_Observacion_Enter(object sender, EventArgs e)
        {

        }
                
        //********************** PANEL DATOS FINANCIEROS - ENTER *********************************************

        private void TBFin_NumCuenta_Enter(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE CONTACTO - ENTER *********************************************

        private void TBCon_Contacto_Enter(object sender, EventArgs e)
        {

        }

        private void TBCon_Ciudad_Enter(object sender, EventArgs e)
        {

        }

        private void TBCon_Direccion_Enter(object sender, EventArgs e)
        {

        }

        private void TBCon_Telefono_Enter(object sender, EventArgs e)
        {

        }

        private void TBCon_Movil_Enter(object sender, EventArgs e)
        {

        }

        private void TBCon_Correo_Enter(object sender, EventArgs e)
        {

        }
                
        private void TBCon_Parentesco_Enter(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS BASICOS - LEAVE *********************************************

        private void TBDat_Codigo_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Nombre_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Documento_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Telefono_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Movil_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_TelefonoAux_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_MovilAux_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Correo_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Pais_Leave(object sender, EventArgs e)
        {

        }
                
        private void TBDat_Ciudad_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Departamento_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_PaginaWeb_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Direccion_Leave(object sender, EventArgs e)
        {

        }

        private void TBDat_Observacion_Leave(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE FACTURACION - LEAVE *********************************************

        private void TBFac_DocumentoCliente_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Cliente_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Movil_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Pais_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Ciudad_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Departamento_Leave(object sender, EventArgs e)
        {

        }

        private void TBFac_Correo_Leave(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE CREDITO - LEAVE *********************************************

        private void TBCre_CreditoMinimo_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_CreditoMaximo_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_CuotaMinima_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_CuotaMaxima_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_Diasdecredito_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_DiasDeProrroga_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_DebitoMinimo_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_DebitoMaximo_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_Intereses_Leave(object sender, EventArgs e)
        {

        }

        private void TBCre_InteresMora_Leave(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE ENVIO - LEAVE *********************************************

        private void TBDes_Sucurzal_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Pais_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Ciudad_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Departamento_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Receptor_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Barrio_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Apartamento_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Movil_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Direccion_Leave(object sender, EventArgs e)
        {

        }

        private void TBDes_Observacion_Leave(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE FINANCIERA - LEAVE *********************************************

        private void TBFin_NumCuenta_Leave(object sender, EventArgs e)
        {

        }

        //********************** PANEL DATOS DE CONTACTO - LEAVE *********************************************

        private void TBCon_Contacto_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Ciudad_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Direccion_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Telefono_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Movil_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Correo_Leave(object sender, EventArgs e)
        {

        }

        private void TBCon_Parentesco_Leave(object sender, EventArgs e)
        {

        }


        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}

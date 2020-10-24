﻿using System;
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
        
        //Variable para Captura el Empleado Logueado
        public int Idempleado;

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
            this.TBFac_DocumentoAsesor.ReadOnly = false;
            this.TBFac_DocumentoAsesor.BackColor = Color.FromArgb(3, 155, 229);
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
        
        //******************** PANEL DATOS BASICOS ********************

        private void TBIdcliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Nombre.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Nombre.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Codigo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Codigo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Documento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Nombre.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Nombre.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Telefono.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Documento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Documento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Telefono.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Telefono.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Correo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Digitar = false;
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Pais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Correo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Correo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBPais_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Pais.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCiudad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Departamento.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDepartamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDat_Nombre.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Departamento.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDat_Departamento.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //******************** PANEL DATOS DE ENVIO ********************

        private void TBPais_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Ciudad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Pais.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Pais.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCiudad_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Receptor.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Ciudad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Ciudad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBReceptor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Barrio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Receptor.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Receptor.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDireccionPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente
                    this.TBDes_Apartamento.Select();
                }

                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Direccion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Direccion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBTelefono_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBMovil_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    //this.TBHorario_Despacho.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.this.Guardar_SQL();
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Movil.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Movil.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBObservacion_01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Pais.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.

                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Observacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBDes_Observacion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //******************** PANEL DATOS FINANCIEROS ********************

        private void TBDiasdecredito_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCre_DiasDeProrroga.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_Diasdecredito.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_Diasdecredito.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDiasDeProrroga_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCre_InteresMora.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_DiasDeProrroga.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_DiasDeProrroga.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBInteresesmora_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCre_CreditoMinimo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_InteresMora.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_InteresMora.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCreditoMinimo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBCre_CreditoMaximo.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMinimo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMinimo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCreditoMaximo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    //this.TBBancoPrincipal.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        //******************** FOCUS ENTER  DATOS BASICOS ********************

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Codigo.Text == Campo)
            {
                this.TBDat_Codigo.BackColor = Color.Azure;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Codigo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDat_Codigo.BackColor = Color.Azure;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBNombre_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Nombre.Text == Campo)
            {
                this.TBDat_Nombre.BackColor = Color.Azure;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Nombre.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDat_Nombre.BackColor = Color.Azure;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDocumento_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBDat_Documento.Text == Campo)
            {
                this.TBDat_Documento.BackColor = Color.Azure;
                this.TBDat_Documento.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBDat_Documento.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBDat_Documento.BackColor = Color.Azure;
                this.TBDat_Documento.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBTelefono_Enter(object sender, EventArgs e)
        {
            this.TBDat_Telefono.BackColor = Color.Azure;
        }

        private void TBMovil_Enter(object sender, EventArgs e)
        {
            this.TBDat_Movil.BackColor = Color.Azure;
        }

        private void TBCorreo_Enter(object sender, EventArgs e)
        {
            this.TBDat_Correo.BackColor = Color.Azure;
        }

        private void TBPais_Enter(object sender, EventArgs e)
        {
            this.TBDat_Pais.BackColor = Color.Azure;
        }

        private void TBCiudad_Enter(object sender, EventArgs e)
        {
            this.TBDat_Ciudad.BackColor = Color.Azure;
        }

        private void TBDepartamento_Enter(object sender, EventArgs e)
        {
            this.TBDat_Departamento.BackColor = Color.Azure;
        }

        //******************** FOCUS ENTER DATOS DE ENVIO ********************

        private void TBPais_01_Enter(object sender, EventArgs e)
        {
            this.TBDes_Pais.BackColor = Color.Azure;
        }

        private void TBCiudad_01_Enter(object sender, EventArgs e)
        {
            this.TBDes_Ciudad.BackColor = Color.Azure;
        }

        private void TBReceptor_Enter(object sender, EventArgs e)
        {
            this.TBDes_Receptor.BackColor = Color.Azure;
        }

        private void TBDireccionPrincipal_Enter(object sender, EventArgs e)
        {
            this.TBDes_Direccion.BackColor = Color.Azure;
        }

        private void TBTelefono_01_Enter(object sender, EventArgs e)
        {
            this.TBDes_Movil.BackColor = Color.Azure;
        }

        private void TBMovil_01_Enter(object sender, EventArgs e)
        {
            this.TBDes_Movil.BackColor = Color.Azure;
        }

        private void TBObservacion_01_Enter(object sender, EventArgs e)
        {
            this.TBDes_Observacion.BackColor = Color.Azure;
        }

        //******************** FOCUS ENTER DATOS BASICOS ********************

        private void TBDiasdecredito_Enter(object sender, EventArgs e)
        {
            this.TBCre_Diasdecredito.BackColor = Color.Azure;
        }

        private void TBDiasDeProrroga_Enter(object sender, EventArgs e)
        {
            this.TBCre_DiasDeProrroga.BackColor = Color.Azure;
        }

        private void TBInteresesmora_Enter(object sender, EventArgs e)
        {
            this.TBCre_InteresMora.BackColor = Color.Azure;
        }

        private void TBCreditoMinimo_Enter(object sender, EventArgs e)
        {
            this.TBCre_CreditoMinimo.BackColor = Color.Azure;
        }

        private void TBCreditoMaximo_Enter(object sender, EventArgs e)
        {
            this.TBCre_CreditoMaximo.BackColor = Color.Azure;
        }

        private void TBBarrio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Direccion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBApartamento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Movil.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBHorario_Despacho_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                    this.TBDes_Observacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
                {
                    //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El usuario iniciado no contiene permisos para Guardar datos en el sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                //Al realizar la validacion en la base de datos y encontrar que no hay acceso a al operacion solicitada
                                //se procede limpiar los campos de texto y habilitaciond de los botones a su estado por DEFECTO.
                                this.Limpiar_Datos();
                            }
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            //Llamada de Clase
                            this.Digitar = false;
                            this.Guardar_SQL();
                        }
                        else
                        {
                            //Se el usuario presiona NO en el mensaje el FOCUS regresara al campo de texto
                            //Donde se realizo la operacion o combinacion de teclas
                            this.TBCre_CreditoMaximo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Asesor_Click(object sender, EventArgs e)
        {
            frmFiltro_Empleado frmFiltro_Empleado = new frmFiltro_Empleado();
            frmFiltro_Empleado.ShowDialog();
        }

        //******************** FOCUS LEVAE DATOS BASICOS ********************

        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            if (TBDat_Codigo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Codigo.Text = Campo;
                this.TBDat_Codigo.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDat_Codigo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBNombre_Leave(object sender, EventArgs e)
        {
            if (TBDat_Nombre.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Nombre.Text = Campo;
                this.TBDat_Nombre.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDat_Nombre.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDocumento_Leave(object sender, EventArgs e)
        {
            if (TBDat_Documento.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
                this.TBDat_Documento.Text = Campo;
                this.TBDat_Documento.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                TBDat_Documento.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBTelefono_Leave(object sender, EventArgs e)
        {
            this.TBDat_Telefono.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_Leave(object sender, EventArgs e)
        {
            this.TBDat_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCorreo_Leave(object sender, EventArgs e)
        {
            this.TBDat_Correo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBPais_Leave(object sender, EventArgs e)
        {
            this.TBDat_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_Leave(object sender, EventArgs e)
        {
            this.TBDat_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDepartamento_Leave(object sender, EventArgs e)
        {
            this.TBDat_Departamento.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEVAE DATOS DE ENVIO ********************

        private void TBPais_01_Leave(object sender, EventArgs e)
        {
            this.TBDes_Pais.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCiudad_01_Leave(object sender, EventArgs e)
        {
            this.TBDes_Ciudad.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBReceptor_Leave(object sender, EventArgs e)
        {
            this.TBDes_Receptor.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDireccionPrincipal_Leave(object sender, EventArgs e)
        {
            this.TBDes_Direccion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBTelefono_01_Leave(object sender, EventArgs e)
        {
            this.TBDes_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBMovil_01_Leave(object sender, EventArgs e)
        {
            this.TBDes_Movil.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_01_Leave(object sender, EventArgs e)
        {
            this.TBDes_Observacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        //******************** FOCUS LEVAE DATOS FINANCIEROS ********************

        private void TBDiasdecredito_Leave(object sender, EventArgs e)
        {
            this.TBCre_Diasdecredito.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBDiasDeProrroga_Leave(object sender, EventArgs e)
        {
            this.TBCre_DiasDeProrroga.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBInteresesmora_Leave(object sender, EventArgs e)
        {
            this.TBCre_InteresMora.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCreditoMinimo_Leave(object sender, EventArgs e)
        {
            this.TBCre_CreditoMinimo.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCreditoMaximo_Leave(object sender, EventArgs e)
        {
            this.TBCre_CreditoMaximo.BackColor = Color.FromArgb(3, 155, 229);
        }
        
        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }
    }
}

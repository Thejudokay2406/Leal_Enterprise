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
    public partial class frmImpuesto : Form
    {
        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar,Eliminar
        private bool Digitar = true;
        private bool Filtrar = false;
        public bool Filtro = true;
        private string Campo = "Campo Obligatorio - Leal Enterprise";

        //Variable para Captura el Empleado Logueado
        public int Idempleado;

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *************************
        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Variables para la Validacion de los checkbox en el Pane Datos Basicos

        private string Checkbox_Compra, Checkbox_Venta, Checkbox_Servicio = "";

        //********** Parametros para AutoCompletar los Texboxt **********************************

        //Panel Datos Basicos
        public string Idimpuesto, Impuesto, Valor, Descripcion = "";
        public string Compra, Venta, Servicio = "";
        public string MontoDeCompra, MontoDeVenta, MontoDeServicio = "";

        public frmImpuesto()
        {
            InitializeComponent();
        }

        private void frmImpuesto_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();

            //Focus a Texboxt y Combobox
            this.TBImpuesto.Select();

            //Ocultacion de Texboxt
            this.TBIdimpuesto.Visible = false;
        }

        private void Habilitar()
        {
            //Panel - Datos Basicos
            
            this.TBImpuesto.ReadOnly = false;
            this.TBImpuesto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBImpuesto.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBImpuesto.Text = Campo;
            this.TBValor.ReadOnly = false;
            this.TBValor.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBValor.Text = Campo;
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCompra.ReadOnly = false;
            this.TBCompra.BackColor = Color.FromArgb(3, 155, 229);
            this.TBVenta.ReadOnly = false;
            this.TBVenta.BackColor = Color.FromArgb(3, 155, 229);
            this.TBServicio.ReadOnly = false;
            this.TBServicio.BackColor = Color.FromArgb(3, 155, 229);


            //Texboxt de Consulta
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos

            this.TBValor.Clear();
            this.TBValor.Text = Campo;
            this.TBImpuesto.Clear();
            this.TBImpuesto.Text = Campo;
            this.TBDescripcion.Clear();
            this.TBCompra.Clear();
            this.TBVenta.Clear();
            this.TBServicio.Clear();

            this.CHCompra.Checked = false;
            this.CHVenta.Checked = false;
            this.CHServicio.Checked = false;

            this.TBBuscar.Clear();

            //Se realiza el FOCUS al panel y campo de texto iniciales
            this.TBImpuesto.Select();
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar";

                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar";

                this.btnCancelar.Enabled = true;
            }
        }

        private void Validacion_Chexbox()
        {
            //Se valida el valor de los checbox que se encuentran en el panel de datos basicos
            //En el cual si este esta seleccionado su valor sera 1 y si no esta seleccionado este seria 0

            if (CHCompra.Checked)
            {
                Checkbox_Compra = "1";
            }
            else if (CHCompra.Checked)
            {
                Checkbox_Compra = "0";
            }

            if (CHVenta.Checked)
            {
                Checkbox_Venta = "1";
            }
            else if (CHVenta.Checked)
            {
                Checkbox_Venta = "0";
            }

            if (CHServicio.Checked)
            {
                Checkbox_Servicio = "1";
            }
            else if (CHServicio.Checked)
            {
                Checkbox_Servicio = "0";
            }
        }

        private void Guardar_SQL()
        {
            try
            {
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBValor.Text == Campo)
                {
                    MensajeError("Ingrese el porcentaje '%' del Impuesto a registrar");
                }
                else if (this.TBImpuesto.Text == Campo)
                {
                    MensajeError("Ingrese el nombre del Impuesto a registrar");
                }
                else if (this.TBCompra.Text == string.Empty)
                {
                    MensajeError("Ingrese el valor minimo para la compra de los productos"); 
                }
                else if (this.TBVenta.Text == string.Empty)
                {
                    MensajeError("Ingrese el valor minimo para la venta de productos");
                }
                else if (this.TBServicio.Text == string.Empty)
                {
                    MensajeError("Ingrese el valor minimo para los servicios");
                }

                else
                {
                    this.Validacion_Chexbox();

                    if (this.Digitar)
                    {
                        rptaDatosBasicos = fImpuesto.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares
                                 1,

                                 //Panel Datos Basicos
                                 this.TBImpuesto.Text, this.TBValor.Text, this.TBDescripcion.Text, this.TBCompra.Text, this.TBVenta.Text, this.TBServicio.Text, Checkbox_Compra, this.Checkbox_Venta, Checkbox_Servicio
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fImpuesto.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y llave primaria
                                 2, Convert.ToInt32(this.TBIdimpuesto.Text),

                                 //Panel Datos Basicos
                                 this.TBImpuesto.Text, this.TBValor.Text, this.TBDescripcion.Text, this.TBCompra.Text, this.TBVenta.Text, this.TBServicio.Text, Checkbox_Compra, this.Checkbox_Venta, Checkbox_Servicio
                            );

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
            MessageBox.Show(mensaje, "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                        this.Digitar = true;
                        this.Botones();
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
                        this.Digitar = true;
                        this.Botones();
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
                this.Digitar = true;
                this.Botones();
                this.Limpiar_Datos();
                this.TBBuscar.Clear();

                //Se Limpian las Filas y Columnas de la tabla
                DGResultados.DataSource = null;
                this.DGResultados.Enabled = false;
                this.lblTotal.Text = "Datos Registrados: 0";

                //Se restablece la imagen predeterminada del boton
                //this.btnGuardar.Image = Properties.Resources.BV_Guardar;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fImpuesto.Buscar(this.TBBuscar.Text);
                        //this.DGResultados.Columns[0].Visible = false;

                        lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                        this.DGResultados.Enabled = true;
                    }
                    else
                    {
                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
                        this.DGResultados.Enabled = false;
                        this.lblTotal.Text = "Datos Registrados: 0";

                        this.btnEliminar.Enabled = false;
                        this.btnImprimir.Enabled = false;
                    }
                }

                else
                {
                    MessageBox.Show(" El Usuario Iniciado no Contiene Permisos Para Realizar Consultas", "Leal Enterprise - 'Acceso Denegado' ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                    this.TBIdimpuesto.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells["Codigo"].Value);
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

        private void TBCompra_Enter(object sender, EventArgs e)
        {
            this.TBCompra.BackColor = Color.Azure;
        }

        private void TBVenta_Enter(object sender, EventArgs e)
        {
            this.TBVenta.BackColor = Color.Azure;
        }

        private void TBServicio_Enter(object sender, EventArgs e)
        {
            this.TBServicio.BackColor = Color.Azure;
        }

        private void TBCompra_Leave(object sender, EventArgs e)
        {
            this.TBCompra.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBVenta_Leave(object sender, EventArgs e)
        {
            this.TBVenta.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBServicio_Leave(object sender, EventArgs e)
        {
            this.TBServicio.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBIdimpuesto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Datos = Negocio.fImpuesto.Buscar(this.TBIdimpuesto.Text);
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Actualmente no se encuentran registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Captura de Valores en la Base de Datos

                    //Panel Datos Basicos - Llaves Primarias
                    Impuesto = Datos.Rows[0][1].ToString();
                    Valor = Datos.Rows[0][2].ToString();
                    MontoDeCompra = Datos.Rows[0][3].ToString();
                    MontoDeVenta = Datos.Rows[0][4].ToString();
                    MontoDeServicio = Datos.Rows[0][5].ToString();
                    Compra = Datos.Rows[0][6].ToString();
                    Venta = Datos.Rows[0][7].ToString();
                    Servicio = Datos.Rows[0][8].ToString();
                    Descripcion = Datos.Rows[0][9].ToString();


                    //Se procede a completar los campos de texto segun las consulta
                    //Realizada anteriormente en la base de datos


                    //Panel Datos Basicos
                    this.TBImpuesto.Text = Impuesto;
                    this.TBValor.Text = Valor;
                    this.TBDescripcion.Text = Descripcion;
                    this.TBCompra.Text = MontoDeCompra;
                    this.TBServicio.Text = MontoDeServicio;
                    this.TBVenta.Text = MontoDeVenta;

                    //Se proceden a Validar los Chexboxt si estan activos o no

                    if (Compra == "0")
                    {
                        this.CHCompra.Checked = false;
                    }
                    else
                    {
                        this.CHCompra.Checked = true;
                    }

                    if (Venta == "0")
                    {
                        this.CHVenta.Checked = false;
                    }
                    else
                    {
                        this.CHVenta.Checked = true;
                    }

                    if (Servicio == "0")
                    {
                        this.CHServicio.Checked = false;
                    }
                    else
                    {
                        this.CHServicio.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        
        private void TBImpuesto_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBImpuesto.Text == Campo)
            {
                this.TBImpuesto.BackColor = Color.Azure;
                this.TBImpuesto.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBImpuesto.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBImpuesto.BackColor = Color.Azure;
            }
        }

        private void TBValor_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor.Text == Campo)
            {
                this.TBValor.BackColor = Color.Azure;
                this.TBValor.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor.BackColor = Color.Azure;
            }
        }

        private void TBDescripcion_Enter(object sender, EventArgs e)
        {
            this.TBDescripcion.BackColor = Color.Azure;
        }

        private void TBImpuesto_Leave(object sender, EventArgs e)
        {
            if (TBImpuesto.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBImpuesto.BackColor = Color.FromArgb(3, 155, 229);
                this.TBImpuesto.Text = Campo;
                this.TBImpuesto.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                this.TBImpuesto.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBImpuesto.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBValor_Leave(object sender, EventArgs e)
        {
            if (TBValor.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor.Text = Campo;
                this.TBValor.ForeColor = Color.FromArgb(255, 255, 255);
            }

            else
            {
                this.TBValor.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
        }
        
        private void TBImpuesto_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBValor.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBImpuesto.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBImpuesto.Select();
                    }
                }
            }
        }

        private void TBValor_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBDescripcion.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBValor.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBValor.Select();
                    }
                }
            }
        }

        private void TBCompra_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBVenta.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBCompra.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBCompra.Select();
                    }
                }
            }
        }

        private void TBVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBServicio.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBVenta.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBVenta.Select();
                    }
                }
            }
        }

        private void TBServicio_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBImpuesto.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBServicio.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBServicio.Select();
                    }
                }
            }
        }

        private void TBDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Enter))
            {
                //Al precionar la tecla Enter se realiza Focus al Texboxt Siguiente

                this.TBCompra.Select();
            }
            else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.Enter))
            {
                //Al precionar las teclas Control+Enter se realizara el registro en la base de datos
                //Y se realizara las validaciones en el sistema

                if (Digitar)
                {
                    DialogResult result = MessageBox.Show("¿Desea registrar los campos digitados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBDescripcion.Select();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea Actualizar los campos consultados?", "Leal Enterprise", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                        this.TBDescripcion.Select();
                    }
                }
            }
        }
    }
}

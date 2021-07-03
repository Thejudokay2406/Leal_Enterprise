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
    public partial class frmServicios : Form
    {
        private static frmServicios _Instancia;

        public static frmServicios GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmServicios();
            }
            return _Instancia;
        }

        // Variable con la cual se define si el procecimiento 
        // A realizar es Editar, Guardar, Buscar, Eliminar
        private bool Digitar = true;
        public bool Filtro = true;
        public bool Examinar = true;

        //Variables de Validaciones
        public int Idempleado; //Variable para Captura el Empleado Logueado
        private string Campo = "Campo Obligatorio";

        //********** Variable para Metodo SQL Guardar, Eliminar, Editar, Consultar *********************************************

        public string Guardar, Editar, Consultar, Eliminar, Imprimir = "";

        //********** Variables para la Validacion de los Texboxt en el Pane Datos Basicos**************************************

        private string Idimpuesto, Codigo, Servicio, Descripcion, Impuesto, Impuesto_Valor, Utilidad = "";
        private string Costo, Clase, Valor01, Valor02, Valor03, Ejecucion, Observacion = "";

        //********** Variables para AutoComplementar Textboxt, Codigo_AutoIncrementable y Chexboxt segun la Consulta en SQL ****

        private string Operacion, AutoIncrementable = "";

        public frmServicios()
        {
            InitializeComponent();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            //Inicio de Clase y Botones
            this.Botones();
            this.Habilitar();
            this.Auto_CodigoSQL();

            //
            this.CBClase.SelectedIndex = 0;

            //Ocultacion de Texboxt
            this.TBIdservicio.Visible = false;
            this.TBIdimpuesto.Visible = false;
        }

        private void Habilitar()
        {

            //Panel - Datos Basicos
            this.TBCodigo.ReadOnly = false;
            this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCodigo.Text = Campo;
            this.TBServicio.ReadOnly = false;
            this.TBServicio.BackColor = Color.FromArgb(3, 155, 229);
            this.TBServicio.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBServicio.Text = Campo;
            this.TBDescripcion.ReadOnly = false;
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBImpuesto.Enabled = false;
            this.TBImpuesto.BackColor = Color.FromArgb(245, 245, 245);
            this.TBImpuesto_Valor.Enabled = false;
            this.TBImpuesto_Valor.BackColor = Color.FromArgb(245, 245, 245);
            this.TBCosto.ReadOnly = false;
            this.TBCosto.BackColor = Color.FromArgb(3, 155, 229);
            this.TBCosto.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBCosto.Text = Campo;
            this.TBValor01.ReadOnly = false;
            this.TBValor01.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor01.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBValor01.Text = Campo;
            this.TBValor02.ReadOnly = false;
            this.TBValor02.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor02.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBValor02.Text = Campo;
            this.TBValor03.ReadOnly = false;
            this.TBValor03.BackColor = Color.FromArgb(3, 155, 229);
            this.TBValor03.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBValor03.Text = Campo;
            this.TBUtilidad.ReadOnly = false;
            this.TBUtilidad.BackColor = Color.FromArgb(3, 155, 229);
            this.TBUtilidad.ForeColor = Color.FromArgb(255, 255, 255);
            this.TBUtilidad.Text = Campo;
            this.TBEjecucion.ReadOnly = false;
            this.TBEjecucion.BackColor = Color.FromArgb(3, 155, 229);
            this.TBObservacion.ReadOnly = false;
            this.TBObservacion.BackColor = Color.FromArgb(3, 155, 229);

            //Panel de Consulta General
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void Limpiar_Datos()
        {
            //Panel - Datos Basicos
            this.TBIdimpuesto.Clear();
            this.TBIdservicio.Clear();
            this.TBServicio.Text = Campo;
            this.TBDescripcion.Clear();
            this.TBImpuesto.Clear();
            this.TBImpuesto_Valor.Clear();
            this.TBUtilidad.Text = Campo;
            this.TBCosto.Text = Campo;
            this.CBClase.SelectedIndex = 0;
            this.TBValor01.Text = Campo;
            this.TBValor02.Text = Campo;
            this.TBValor03.Text = Campo;
            this.TBEjecucion.Clear();
            this.TBObservacion.Clear();

            //
            this.Auto_CodigoSQL();

            //FOCUS
            if (TBCodigo.Text == "1")
            {
                this.TBServicio.Select();
            }
            else
            {
                this.TBCodigo.Select();
            }
        }

        private void Botones()
        {
            if (Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Guardar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else if (!Digitar)
            {
                this.btnGuardar.Enabled = true;
                this.btnGuardar.Text = "Editar - F10";

                this.btnEliminar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
        }

        private void Auto_CodigoSQL()
        {
            try
            {
                DataTable Datos = Negocio.fServicios.AutoIncrementable(Convert.ToInt32(0));
                //Evaluamos si  existen los Datos
                if (Datos.Rows.Count != 0)
                {
                    //MessageBox.Show("Niveles de Seguridad no Cumplidos", "Leal Enterprise - Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.TBCodigo.Enabled = true;

                    Operacion = Datos.Rows[0][0].ToString();
                    AutoIncrementable = Datos.Rows[0][1].ToString();

                    if (Operacion == "A")
                    {
                        this.TBCodigo.Enabled = false;
                        this.TBCodigo.Text = "1";
                        this.TBCodigo.BackColor = Color.FromArgb(245, 245, 245);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        public void setImpuesto(string idimpuesto, string impuesto, string valor)
        {
            this.TBIdimpuesto.Text = idimpuesto;
            this.TBImpuesto.Text = impuesto;
            this.TBImpuesto_Valor.Text = valor;
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
                string rptaDatosBasicos = "";

                // <<<<<<------ Panel Datos Basicos ------>>>>>

                if (this.TBServicio.Text == Campo)
                {
                    MensajeError("Ingrese el Nombre del Servicio a Registrar");
                    this.TBServicio.Focus();
                }
                else if (this.TBUtilidad.Text == Campo)
                {
                    MensajeError("Ingrese el Valor de Utilidad del Servicio");
                    this.TBUtilidad.Focus();
                }
                else if (this.TBCodigo.Text == Campo)
                {
                    MensajeError("Ingrese el Código del Producto");
                    this.TBCodigo.Focus();
                }
                else if (this.TBCosto.Text == Campo)
                {
                    MensajeError("Ingrese el Costo Promedio del Servicio");
                    this.TBCodigo.Focus();
                }
                else if (this.TBValor01.Text == Campo)
                {
                    MensajeError("Ingrese el Valor Inicial del Servicio");
                    this.TBValor01.Focus();
                }
                else if (this.TBValor02.Text == Campo)
                {
                    MensajeError("Ingrese el Valor Secundario del Servicio");
                    this.TBValor02.Focus();
                }
                else if (this.TBValor03.Text == Campo)
                {
                    MensajeError("Ingrese el Valor Terciario del Servicio");
                    this.TBValor03.Focus();
                }

                else
                {
                    if (this.Digitar)
                    {

                        rptaDatosBasicos = fServicios.Guardar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 1, Convert.ToInt32(this.TBIdimpuesto.Text), this.TBCodigo.Text, this.TBServicio.Text, this.TBDescripcion.Text, this.CBClase.Text, Convert.ToDouble(this.TBCosto.Text), Convert.ToDouble(this.TBValor01.Text), Convert.ToDouble(this.TBValor02.Text), Convert.ToDouble(this.TBValor03.Text), Convert.ToInt64(this.TBUtilidad.Text), Convert.ToInt64(this.TBEjecucion.Text), this.TBObservacion.Text
                            );
                    }

                    else
                    {
                        rptaDatosBasicos = fServicios.Editar_DatosBasicos

                            (
                                 //Datos Auxiliares y Llaves Primarias
                                 2, Convert.ToInt32(this.TBIdservicio.Text), Convert.ToInt32(this.TBIdimpuesto.Text), this.TBCodigo.Text, this.TBServicio.Text, this.TBDescripcion.Text, this.CBClase.Text, Convert.ToDouble(this.TBCosto.Text), Convert.ToDouble(this.TBValor01.Text), Convert.ToDouble(this.TBValor02.Text), Convert.ToDouble(this.TBValor03.Text), Convert.ToInt64(this.TBUtilidad.Text), Convert.ToInt64(this.TBEjecucion.Text), this.TBObservacion.Text
                            );
                    }

                    if (rptaDatosBasicos.Equals("OK"))
                    {
                        if (this.Digitar)
                        {
                            this.MensajeOk("Procedimiento de Digitalización Exitoso - Leal Enterprise \n\n" + "El Servicio: “" + this.TBServicio.Text + "” a Sido Registrado Exitosamente");
                        }

                        else
                        {
                            this.MensajeOk("Procedimiento de Modificación Exitoso - Leal Enterprise \n\n" + "El Registro del Servicio: “" + this.TBServicio.Text + "” a Sido Actualizado Exitosamente");
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

                if (TBCodigo.Text == "1")
                {
                    this.TBServicio.Select();
                }
                else
                {
                    this.TBCodigo.Select();
                }

                //Se Limpian las Filas y Columnas de la tabla
                this.DGResultados.DataSource = null;
                this.lblTotal.Text = "Datos Registrados: 0";
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
                    int Idservicio;

                    Opcion = MessageBox.Show("Desea Eliminar el Registro Seleccionado", "Leal Enterprise", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        if (DGResultados.SelectedRows.Count > 0)
                        {
                            Idservicio = Convert.ToInt32(DGResultados.CurrentRow.Cells[0].Value.ToString());
                            Respuesta = Negocio.fServicios.Eliminar(Idservicio, 1);
                        }

                        if (Respuesta.Equals("OK"))
                        {
                            this.MensajeOk("Procedimiento de Eliminación Exitoso - Leal Enterprise \n\n" + "El Registro de Servicio a Sido Eliminado Exitosamente");
                        }
                        else
                        {
                            this.MensajeError(Respuesta);
                        }
                    }

                    //
                    this.TBBuscar.Clear();

                }
                else
                {
                    MessageBox.Show("Acceso Denegado Para Realizar Eliminaciones en el Sistema", "Leal Enterprise - Solicitud Rechazada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Consultar == "1")
                {
                    if (TBBuscar.Text != "")
                    {
                        this.DGResultados.DataSource = fServicios.Buscar(this.TBBuscar.Text, 1);
                        this.DGResultados.Columns[0].Visible = false;

                        this.lblTotal.Text = "Datos Registrados: " + Convert.ToString(DGResultados.Rows.Count);

                        this.btnEliminar.Enabled = true;
                        this.btnImprimir.Enabled = true;
                    }
                    else
                    {
                        //Se Limpian las Filas y Columnas de la tabla
                        this.DGResultados.DataSource = null;
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

                    this.TBIdservicio.Text = Convert.ToString(this.DGResultados.CurrentRow.Cells[0].Value);
                    this.TBServicio.Focus();
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

        private void DGResultados_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCodigo.Text == Campo)
            {
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCodigo.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCodigo.BackColor = Color.Azure;
                this.TBCodigo.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBServicio_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBServicio.Text == Campo)
            {
                this.TBServicio.BackColor = Color.Azure;
                this.TBServicio.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBServicio.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBServicio.BackColor = Color.Azure;
                this.TBServicio.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBDescripcion_Enter(object sender, EventArgs e)
        {
            this.TBDescripcion.BackColor = Color.Azure;
        }

        private void TBUtilidad_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBUtilidad.Text == Campo)
            {
                this.TBUtilidad.BackColor = Color.Azure;
                this.TBUtilidad.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBUtilidad.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBUtilidad.BackColor = Color.Azure;
                this.TBUtilidad.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void TBEjecucion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBEjecucion.BackColor = Color.Azure;
        }

        private void TBObservacion_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBObservacion.BackColor = Color.Azure;
        }

        private void TBCosto_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBCosto.Text == Campo)
            {
                this.TBCosto.BackColor = Color.Azure;
                this.TBCosto.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBCosto.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBCosto.BackColor = Color.Azure;
                this.TBCosto.ForeColor = Color.FromArgb(0, 0, 0);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);

            }
        }

        private void TBValor01_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor01.Text == Campo)
            {
                this.TBValor01.BackColor = Color.Azure;
                this.TBValor01.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor01.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor01.BackColor = Color.Azure;
                this.TBValor01.ForeColor = Color.FromArgb(0, 0, 0);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBValor02_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor02.Text == Campo)
            {
                this.TBValor02.BackColor = Color.Azure;
                this.TBValor02.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor02.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor02.BackColor = Color.Azure;
                this.TBValor02.ForeColor = Color.FromArgb(0, 0, 0);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBValor03_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            if (TBValor03.Text == Campo)
            {
                this.TBValor03.BackColor = Color.Azure;
                this.TBValor03.ForeColor = Color.FromArgb(0, 0, 0);
                this.TBValor03.Clear();
            }
            else
            {
                //Color de fondo del Texboxt cuando este tiene el FOCUS Activado
                this.TBValor03.BackColor = Color.Azure;
                this.TBValor03.ForeColor = Color.FromArgb(0, 0, 0);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBCosto_Leave(object sender, EventArgs e)
        {
            if (TBCosto.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCosto.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCosto.Text = Campo;
                this.TBCosto.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCosto.BackColor = Color.FromArgb(3, 155, 229);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBValor01_Leave(object sender, EventArgs e)
        {
            if (TBValor01.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor01.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor01.Text = Campo;
                this.TBValor01.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor01.BackColor = Color.FromArgb(3, 155, 229);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBValor02_Leave(object sender, EventArgs e)
        {
            if (TBValor02.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor02.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor02.Text = Campo;
                this.TBValor02.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor02.BackColor = Color.FromArgb(3, 155, 229);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBValor03_Leave(object sender, EventArgs e)
        {
            if (TBValor03.Text == String.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBValor03.BackColor = Color.FromArgb(3, 155, 229);
                this.TBValor03.Text = Campo;
                this.TBValor03.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBValor03.BackColor = Color.FromArgb(3, 155, 229);

                // El control TextBox ha perdido el foco. Referenciamos el control TextBox que ha desencadenado el evento.
                TextBox tb = (TextBox)sender;

                // Primero verificamos si el valor se puede convertir a Decimal.
                double numero = default(double);
                bool bln = double.TryParse(tb.Text, out numero);

                if ((!(bln)))
                {
                    // No es un valor decimal válido; limpiamos el control.
                    //tb.Clear();
                    return;
                }

                // En la propiedad Tag guardamos el valor con todos los decimales.
                //
                tb.Tag = numero;

                // Y acto seguido formateamos el valor
                // a monetario con dos decimales.
                //
                tb.Text = string.Format("{0:N2}", numero);
            }
        }

        private void TBCosto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor01.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBCosto.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCosto.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor01_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor02.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBValor01.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValor01.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor02_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBValor03.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBValor02.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValor02.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor01_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor02_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBValor03_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TBEjecucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO SE PERMITEN INTRODUCIR NUMEROS
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnExaminar_Impuesto_Click(object sender, EventArgs e)
        {
            frmFiltro_Impuesto frmFiltro_Impuesto = new frmFiltro_Impuesto();
            frmFiltro_Impuesto.ShowDialog();
        }

        private void frmServicios_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void CBClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBClase.SelectedIndex != 0)
            {
                this.TBCosto.Select();
            }
        }

        private void TBIdservicio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBIdservicio.Text != string.Empty)
                {
                    // ENVIAN LOS DATOS A LA BASE DE DATOS Y SE EVALUAN QUE EXISTEN O ESTEN REGISTRADOS

                    DataTable Datos = Negocio.fServicios.Buscar(this.TBIdservicio.Text, 2);
                    //Evaluamos si  existen los Datos
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("No Se Encontraron Registros en la Base de Datos", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        //Panel Datos Basicos
                        Idimpuesto = Datos.Rows[0][0].ToString();
                        Codigo = Datos.Rows[0][1].ToString();
                        Servicio = Datos.Rows[0][2].ToString();
                        Descripcion = Datos.Rows[0][3].ToString();
                        Impuesto = Datos.Rows[0][4].ToString();
                        Impuesto_Valor = Datos.Rows[0][5].ToString();
                        Utilidad = Datos.Rows[0][6].ToString();
                        Costo = Datos.Rows[0][7].ToString();
                        Clase = Datos.Rows[0][8].ToString();
                        Valor01 = Datos.Rows[0][9].ToString();
                        Valor02 = Datos.Rows[0][10].ToString();
                        Valor03 = Datos.Rows[0][11].ToString();
                        Ejecucion = Datos.Rows[0][12].ToString();
                        Observacion = Datos.Rows[0][13].ToString();

                        //SE PROCEDE A LLENAR LOS CAMPOS DE TEXTO SEGUN LA CONSULTA REALIZADA

                        this.TBIdimpuesto.Text = Idimpuesto;
                        this.TBCodigo.Text = Codigo;
                        this.TBServicio.Text = Servicio;
                        this.TBDescripcion.Text = Descripcion;
                        this.TBImpuesto.Text = Impuesto;
                        this.TBImpuesto_Valor.Text = Impuesto_Valor;
                        this.TBUtilidad.Text = Utilidad;
                        this.TBCosto.Text = Costo;
                        this.CBClase.Text = Clase;
                        this.TBValor01.Text = Valor01;
                        this.TBValor02.Text = Valor02;
                        this.TBValor03.Text = Valor03;
                        this.TBEjecucion.Text = Ejecucion;
                        this.TBObservacion.Text = Observacion;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBValor03_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBUtilidad.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBValor03.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBValor03.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBBuscar_Enter(object sender, EventArgs e)
        {
            //Se evalua si el campo de texto esta vacio y se espeicifca que es obligatorio en la base de datos
            this.TBBuscar.BackColor = Color.Azure;
        }

        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            if (TBCodigo.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
                this.TBCodigo.Text = Campo;
                this.TBCodigo.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBCodigo.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBServicio_Leave(object sender, EventArgs e)
        {
            if (TBServicio.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBServicio.BackColor = Color.FromArgb(3, 155, 229);
                this.TBServicio.Text = Campo;
                this.TBServicio.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBServicio.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBDescripcion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBDescripcion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBUtilidad_Leave(object sender, EventArgs e)
        {
            if (TBUtilidad.Text == string.Empty)
            {
                //Color de texboxt cuando este posee el FOCUS Activado
                this.TBUtilidad.BackColor = Color.FromArgb(3, 155, 229);
                this.TBUtilidad.Text = Campo;
                this.TBUtilidad.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                this.TBUtilidad.BackColor = Color.FromArgb(3, 155, 229);
            }
        }

        private void TBEjecucion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBEjecucion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBObservacion_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBObservacion.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBBuscar_Leave(object sender, EventArgs e)
        {
            //Color de texboxt cuando este posee el FOCUS Activado
            this.TBBuscar.BackColor = Color.FromArgb(3, 155, 229);
        }

        private void TBCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBServicio.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBCodigo.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBCodigo.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBServicio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBDescripcion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBCosto.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBEjecucion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBUtilidad.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBUtilidad.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBEjecucion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    this.TBObservacion.Select();
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBEjecucion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBEjecucion.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TBObservacion_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Down))
                {
                    //Al precionar la tecla Bajar se realiza Focus al Texboxt Siguiente

                    if (TBCodigo.Text == "1")
                    {
                        this.TBServicio.Select();
                    }
                    else
                    {
                        this.TBCodigo.Select();
                    }
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F9))
                {
                    //
                    this.Digitar = true;

                    this.Botones();
                    this.Limpiar_Datos();

                    this.TBBuscar.Clear();

                    //Se Limpian las Filas y Columnas de la tabla
                    this.DGResultados.DataSource = null;
                    this.lblTotal.Text = "Datos Registrados: 0";
                }
                else if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.F10))
                {
                    //Al precionar las teclas F10 se realizara el registro en la base de datos
                    //Y se realizara las validaciones en el sistema

                    if (Digitar)
                    {
                        DialogResult result = MessageBox.Show("¿Desea Registrar los Campos Digitados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            if (Guardar == "1")
                            {
                                //Llamada de Clase
                                this.Guardar_SQL();
                            }
                            else
                            {
                                MessageBox.Show("El Usuario Iniciado no Contiene Permisos Para Guardar Datos en el Sistema", "Leal Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                            this.TBObservacion.Select();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Desea Actualizar los Campos Consultados?", "Leal Enterprise - Solicitud de Procedimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            this.TBObservacion.Select();
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace WebApp1.Mantenimiento
{
    public partial class nuevoUsuario : System.Web.UI.Page
    {
        logRol rol = new logRol();
        private tblUsuario us = new tblUsuario();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"]!=null)
                {
                    lnkGuardar.Visible = false;
                    lnkeditar.Visible = true;
                    lblMensaje.Text = "Actualización de Datos";
                    int codigo = Convert.ToInt32(Request["cod"]);
                    us = logUser.obtenerxID(codigo);
                    if (us!=null)
                    {
                        txtNombre.Text = us.usNombre.ToString();
                        txtApellido.Text=us.usApellido.ToString();
                        txtCedula.Text=us.usCedula.ToString();
                        txtCalve.Text = us.usClave.ToString();
                        txtCorreo.Text=us.usCorreo.ToString();
                        txtDireccion.Text = us.usDireccion.ToString();
                        ddlRol.SelectedValue = us.idTipUsu.ToString();
                    }

                }
                else
                {
                    lnkGuardar.Visible = true;
                    lnkeditar.Visible = false;
                }
                cargarRol();
            }
            
        }

        void limpiar()
        {
            txtApellido.Text = txtCalve.Text = txtCedula.Text = txtCorreo.Text = txtDireccion.Text = txtNombre.Text = "";
            ddlRol.SelectedIndex = 0;
        }

        private bool cedula(string cedula)
        {
            if (cedula==null)
            {
                return false;
            }
            else
            {
                if (cedula.Length==10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool verificar(string mail)
        {

            if (mail == null)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Campo Vacio";
                return false;
            }
            else
            {

                if (new EmailAddressAttribute().IsValid(mail))
                {
                    string[] correo = mail.Split('@');
                    if (correo[1].Equals("gmail.com") || correo[1].Equals("outlook.com") || correo[1].Equals("outlook.es") || correo[1].Equals("yahoo.com"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }
        private void guardar()
        {
            bool existente = logUser.verificacion(txtCedula.Text);

            if (existente)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Usuario Existente";
            }
            else
            {

                if (verificar(txtCorreo.Text))
                {
                    if (cedula(txtCedula.Text))
                    {


                        try
                        {
                            lblMensaje.Text = "Registro de Usuarios";
                            us = new tblUsuario();

                            us.usNombre = txtNombre.Text;
                            us.usApellido = txtApellido.Text;
                            us.usCedula = txtCedula.Text;
                            us.usClave = txtCalve.Text;
                            us.usCorreo = txtCorreo.Text;
                            us.usDireccion = txtDireccion.Text;
                            us.idTipUsu = Convert.ToInt32(ddlRol.SelectedValue);

                            logUser.save(us);
                            lblMensaje.Text = "";
                            lblMensaje.ForeColor = System.Drawing.Color.Green;
                            lblMensaje.Text = "Datos Guardados exitosamente";
                            lblCedula.Text = "";
                            lblCorreo.Text = "";
                            limpiar();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "Cedula no Válida.";
                    }
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Formato de correo no Válido.";
                }
                
            }
        }

        private void modify(tblUsuario use)
        {
            if (verificar(txtCorreo.Text))
            {
                if (cedula(txtCedula.Text))
                {



                    try
                    {
                        lblMensaje.Text = "";

                        use.usNombre = txtNombre.Text;
                        use.usApellido = txtApellido.Text;
                        use.usCedula = txtCedula.Text;
                        use.usClave = txtCalve.Text;
                        use.usCorreo = txtCorreo.Text;
                        use.usDireccion = txtDireccion.Text;
                        use.idTipUsu = Convert.ToInt32(ddlRol.SelectedValue);


                        logUser.edit(use);
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        lblMensaje.Text = "Datos modificados";
                        lblCedula.Text = "";
                        lblCorreo.Text = "";
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "Datos NO modificados" + ex;
                    }
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "Cedula no Válida.";
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Formato de correo no Válido.";
            }
        }

        private void cargarRol()
        {
            List<tblTipoUsuario> listrol = new List<tblTipoUsuario>();

            listrol = logRol.obtenerRol();
            listrol.Insert(0, new tblTipoUsuario() { tusuRol="Seleccione" });

            ddlRol.DataSource = listrol;
            ddlRol.DataTextField = "tusuRol";
            ddlRol.DataValueField = "idTipUsu";

            ddlRol.DataBind();
        }
        private void guardaroModificar(int key)
        {
            if (key==0)
            {
                guardar();
            }
            else
            {
                us = logUser.obtenerxID(key);
                if (us!=null)
                {
                    modify(us);
                }
            }
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            guardaroModificar(Convert.ToInt32(Request["cod"]));
        }

        protected void lnkeditar_Click(object sender, EventArgs e)
        {
            guardaroModificar(Convert.ToInt32(Request["cod"]));
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/PageUsuarios.aspx");
        }

        protected void txtCedula_TextChanged(object sender, EventArgs e)
        {

            if (!cedula(txtCedula.Text))
            {
                lblCedula.ForeColor = System.Drawing.Color.Red;
                lblCedula.Text = "Cedula no Valida";
            }
            else
            {
                lblCedula.ForeColor = System.Drawing.Color.Green;
                lblCedula.Text = "Cedula Valida";
            }
        }

        protected void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (!verificar(txtCorreo.Text))
            {
                lblCorreo.ForeColor = System.Drawing.Color.Red;
                lblCorreo.Text = "Correo No Valido";
                
                
            }
            else
            {
                lblCorreo.ForeColor = System.Drawing.Color.Green;
                lblCorreo.Text = "Correo Valido";
            }

        }
    }
}
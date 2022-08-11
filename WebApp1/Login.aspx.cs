using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;

namespace WebApp1
{
    public partial class Login : System.Web.UI.Page
    {
        static tblUsuario user = new tblUsuario ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            olvido();
        }

        private void olvido()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                lblMensaje.Text = "Ingrese su cedula para el proceso de recuperacion";
            }
            else
            {
                bool existe = logUser.cilogin(txtUsuario.Text);
                {
                    if (existe)
                    {
                        


                        user = logUser.inforci(txtUsuario.Text);
                        string from = "diabulusinmusic444666@gmail.com";
                        string contra = "Eduardo28";
                        string to = user.usCorreo;
                        string msj = "Su contraseña olvidada es: " + user.usClave;

                        if (new recuperacionCorreo().enviarCorreo(from, contra, to, msj))
                        {
                            lblMensaje.ForeColor = Color.Green;
                            lblMensaje.Text = "La clave se envio con exito...";


                        }
                        else
                        {
                            lblMensaje.ForeColor = Color.Red;
                            lblMensaje.Text = "Correo no enviado...";
                        }



                    }
                    else
                    {
                        lblMensaje.Text = "Cedula incorrecta o no existente...";
                        txtUsuario.Text = "";
                    }
                }
            }
            
        }
    }
}
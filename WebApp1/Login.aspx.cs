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
            lblMensaje.Text = "";
            
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
                        string from = "consorcioinmmokraft.2022@outlook.com";
                        string contra = "Inmmokraft2022";
                        string to = user.usCorreo;
                        //string msj = "Su contraseña olvidada es: " + user.usClave;
                        string msj = @"
                            <div style=' width: 500px;'>
                                <div style=' background-color: #0e589f;color: aliceblue;border-radius:15px 15px 0 0   ;'>
                                    <center>
                                            <h2>Consorcio Inmmokraft LTDA.</h2>
                                    </center>
                                </div>
                             <div style='padding: 0 10px;border: 1px solid #0e589f;'>
                                <br/>
                                <h3 style='color:black'>Sr(a)" + user.usNombre+" "+user.usApellido+ @"</h3>
                                <p style='color:black'> Aquí en Inmmokraft nos aseguramos de que tenga simpre acceso a todos sus datos por eso contestamos a la recuperación de su clave.</p>
                                <b style='color:black'> Clave: " + user.usClave+ @"</b>
                                <p style='color:black'>Un placer atenderle.</p>
                                <center>
                                   <b style='color:black'> Ing Hugo Yepez.</b>
                                </center>
                                <br/>
                                </div>
                                <div style='background-color: #0e589f;color: aliceblue;border-radius: 0 0 15px 15px  ;'>
                                    <center>
                                    <p><b> Dirección:</b> Jose Palomino & Dolores Sucre.</p>
        
                                    <p><b>Telefono:</b> 0987654321</p>
                                </center>
                                </div>
                               </div> ";

                        if (new recuperacionCorreo().enviarCorreo(from, contra, to, msj))
                        {
                            lblMensaje.ForeColor = Color.Green;
                            lblMensaje.Text = "La clave se envio con exito...";
                            txtUsuario.Text = "";


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
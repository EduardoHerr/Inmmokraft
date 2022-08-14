using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp1.Mantenimiento
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ValidacionUsuario
            if (Session["nombre"] != null)
            {
                lblNombre.Text = "Bienvenido, de nuevo " + Session["nombre"].ToString();
            }
            else
            {
                Response.Redirect("~/Loggin.aspx");
            }

            if (Session["rol"] != null)
            {
                int rol = Convert.ToInt32(Session["rol"]);
                if (rol == 2)
                {
                    pnlAdmin.Visible = false;
                    pnlAnalista.Visible = false;
                }
                else if (rol == 3)
                {
                    pnlAnalista.Visible = true;
                    pnlAdmin.Visible = false;
                }
            }
            #endregion


        }

        protected void lnkDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/PageDatos.aspx");
        }

        protected void lnkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/PageUsuarios.aspx");
        }

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session["nombre"] = null;
            Response.Redirect("~/Loggin.aspx");

        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                int rol = Convert.ToInt32(Session["rol"]);
                if (rol == 2)
                {
                    Response.Redirect("~/Mantenimiento/postViewer.aspx");
                }
                else if (rol == 3)
                {
                    Response.Redirect("~/Mantenimiento/analistaView.aspx");
                }
                else
                {
                    Response.Redirect("~/inicioAdmin.aspx");
                }

                }

            }

        protected void lnkVistaAnalista_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/analistaView.aspx");
        }
    }
}
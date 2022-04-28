using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;


namespace WebApp1.Mantenimiento
{
    public partial class postViewer : System.Web.UI.Page
    {
        logDatos dat = new logDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            if (Session["idPost"]!=null)
            {
                int key = Convert.ToInt32(Session["idPost"]);
                List<tblDatos> dat = new List<tblDatos>();
                dat = logDatos.listarDatosxID(key);
                if (dat!=null)
                {
                    grvDatos.DataSource = dat;
                    grvDatos.DataBind();
                }
            }
            
            
        }

        protected void grvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName=="Editar")
            {
                Response.Redirect("~/Mantenimiento/nuevoDato.aspx?cod=" + codigo, true);
                Context.ApplicationInstance.CompleteRequest();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/nuevoDato.aspx");
        }
    }
}
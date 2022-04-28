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
    public partial class PageDatos : System.Web.UI.Page
    {
        logDatos dat = new logDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            cargarDatos();
        }

        private void cargarDatos()
        {
            List<tblDatos> dat = new List<tblDatos>();
            dat = logDatos.listarDatos();
            if (dat!=null)
            {
                gdvDatos.DataSource = dat;
                gdvDatos.DataBind();
            }
        }
        protected void gdvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int codigo = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName=="Editar")
            {
                Response.Redirect("~/Mantenimiento/nuevoDato.aspx?cod=" + codigo,true);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if (e.CommandName=="Eliminar")
            {
                tblDatos data = new tblDatos();

                data=logDatos.obtenerDatos(codigo);
                if (data!=null)
                {
                    logDatos.eliminarDatos(data);
                    cargarDatos();
                }
            }
        }

        protected void btnAgregarDato_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/nuevoDato.aspx");
        }
    }
}
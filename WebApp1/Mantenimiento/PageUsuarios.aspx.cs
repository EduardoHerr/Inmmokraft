using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace WebApp1.Mantenimiento
{
    public partial class PageUsuarios : System.Web.UI.Page
    {
        logUser us = new logUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargaUS();
        }

        private void cargaUS()
        {
            gdvUsuario.DataSource = us.cargaUser();
            gdvUsuario.DataBind();
        }

        protected void btnActualizar_Command(object sender, CommandEventArgs e)
        {
            int key = (int)e.CommandArgument;
        }

        protected void btnNuevoUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/nuevoUsuario.aspx");
        }

        protected void gdvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                Response.Redirect("~/Mantenimiento/nuevoUsuario.aspx?cod="+codigo, true);
                Context.ApplicationInstance.CompleteRequest();
            }
            else if (e.CommandName =="Eliminar")
            {
                tblUsuario user = new tblUsuario();
                user = logUser.obtenerxID(codigo);
                if (user!=null)
                {
                    logUser.eliminarUser(user);
                    cargaUS();
                

                }
            }
            

        }
    }
}
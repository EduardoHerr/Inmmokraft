using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;

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
            SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlCommand cmd = new SqlCommand("select * from tbldatos inner join tblPagina on tblDatos.idPagina=tblPagina.idPagina inner join tblUsuario on tblDatos.idUsuario = tblUsuario.idUsuario inner join tblTipoUsuario on tblUsuario.idTipUsu=tblTipoUsuario.idTipUsu", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds != null)
            {
                gdvUsuario.DataSource = ds;
                gdvUsuario.DataBind();
            }
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
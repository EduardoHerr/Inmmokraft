using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        logPagina logPagina = new logPagina(); 
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
                SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
                SqlCommand cmd = new SqlCommand("select * from tbldatos inner join tblPagina on tblDatos.idPagina=tblPagina.idPagina Where idUsuario="+key, cn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                
                if (ds!=null)
                {
                    grvDatos.DataSource = ds;
                    grvDatos.DataBind();
                }
            }
            if (!logDatos.verificarDatos(Convert.ToInt32(Session["idPost"])))
            {
                lbl1.ForeColor = Color.FromArgb(31, 97, 141);

            }
            else
            {
                lbl1.Visible = false;
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
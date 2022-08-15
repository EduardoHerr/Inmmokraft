using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using Microsoft.SqlServer.Server;

namespace WebApp1.Mantenimiento
{
    public partial class reporteVista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem i;
                i = new ListItem("SELECCIONE", "0");
                drop.Items.Add(i);
                i = new ListItem("Meses", "1");
                drop.Items.Add(i);
                i = new ListItem("Usuarios", "2");
                drop.Items.Add(i);
                i = new ListItem("Todos los Registros", "3");
                drop.Items.Add(i);

                ddl1.Visible = false;
                txtFecha.Visible = false;

                sinParametro();
            }
        }

        private void sinParametro()
        {
            #region sinParametro
            SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlDataAdapter da = new SqlDataAdapter("listarDatos", cn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dataset1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rp);
            ReportViewer1.LocalReport.Refresh();

            #endregion
        }
        private void cargarUsuarios()
        {
           
            SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlCommand cmd = new SqlCommand("select idUsuario,usNombre+' '+usApellido as completo from tblUsuario", cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ddl1.DataSource= ds;
            ddl1.DataTextField = "completo";
            ddl1.DataValueField = "idUsuario";
            ddl1.DataBind();
            ddl1.Items.Insert(0, new ListItem("Seleccione","0"));
            
        }

        private void cargarMeses()
        {
            ddl1.Items.Clear();
            ListItem i;
            i = new ListItem("SELECCIONE", "0");
            ddl1.Items.Add(i);
            i = new ListItem("Enero", "1");
            ddl1.Items.Add(i);
            i = new ListItem("Febrero", "2");
            ddl1.Items.Add(i);
            i = new ListItem("Marzo", "3");
            ddl1.Items.Add(i);
            i = new ListItem("Abril", "4");
            ddl1.Items.Add(i);
            i = new ListItem("Mayo", "5");
            ddl1.Items.Add(i);
            i = new ListItem("Junio", "6");
            ddl1.Items.Add(i);
            i = new ListItem("Julio", "7");
            ddl1.Items.Add(i);
            i = new ListItem("Agosto", "8");
            ddl1.Items.Add(i);
            i = new ListItem("Septiembre", "9");
            ddl1.Items.Add(i);
            i = new ListItem("Octubre", "10");
            ddl1.Items.Add(i);
            i = new ListItem("Noviembre", "11");
            ddl1.Items.Add(i);
            i = new ListItem("Diciembre", "12");
            ddl1.Items.Add(i);
        }

        #region procedimientosAlmacenados

        private void tblDatosFechaPub(int mes,int anio)
        {
            SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlDataAdapter da = new SqlDataAdapter("tblDatosFechaPub", cn);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            da.SelectCommand.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

            da.Fill(dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dataset1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rp);
            ReportViewer1.LocalReport.Refresh();
        }

        private void tblDatosUsuario(int key)
        {
            SqlConnection cn = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlDataAdapter da = new SqlDataAdapter("tblDatosUsuario", cn);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType= CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@usuario",SqlDbType.Int).Value = key;
            da.Fill(dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dataset1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rp);
            ReportViewer1.LocalReport.Refresh();
        }
        #endregion
        

        protected void drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int op = drop.SelectedIndex;
            if (op!=0)
            {
                switch (op)
                {
                    case 1:
                        //cargarMeses();
                        ddl1.Visible = false;
                        txtFecha.Visible = true;
                        break;
                    case 2:
                        txtFecha.Visible = false;
                        ddl1.Visible = true;
                        cargarUsuarios();
                        break;
                    case 3:
                        sinParametro();
                        ddl1.Visible = false;
                        break;
                    default:

                        break;
                }
            }
        }


        protected void Export(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;

            //Export the RDLC Report to Byte Array.
            byte[] bytes = ReportViewer1.LocalReport.Render(RadioButtonList1.SelectedItem.Value, null, out contentType, out encoding, out extension, out streamIds, out warnings);
            

            //Download the RDLC Report in Word, Excel, PDF and Image formats.
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=Inmmokraft." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }


        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int valor = Convert.ToInt32(ddl1.SelectedValue);
                int dropint = drop.SelectedIndex;
                if (dropint != 0)
                {
                    switch (dropint)
                    {
                        case 1:
                            //tblDatosFechaPub(valor);
                            break;
                        case 2:
                            if (dropint != 0)
                            {
                                tblDatosUsuario(valor);
                            }

                            break;

                    }
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Excepcion: "+ex.Message);
            }
            
            
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            string[] query = txtFecha.Text.Split('-');
            tblDatosFechaPub(Convert.ToInt32(query[1]), Convert.ToInt32(query[0]));



        }
    }
}
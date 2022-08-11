using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace WebApp1.Mantenimiento
{
    public partial class analistaController : System.Web.UI.Page
    {
        private tblDatos dt = new tblDatos();
        private tblGrupos gr = new tblGrupos();
        private tblPagina pg = new tblPagina();
        private tblUsuario us = new tblUsuario();

        private static int dato;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request["cod"]!=null)
                {

                    int codigo = Convert.ToInt32(Request["cod"]);
                    dato = codigo;
                    dt = logDatos.obtenerDatos(codigo);
                    if (dt!=null)
                    {
                        #region CargaNormal

                        
                        txtFecha.Text = Convert.ToDateTime(dt.datFechaHoraPub).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        txtPerfil.Text = dt.datPerfil.ToString();
                        txtPropiedad.Text = dt.datPropiedad.ToString();
                        txtTipo.Text = dt.datTipo.ToString();
                        txtSitio.Text = dt.datSitio.ToString();                        
                        txtSubir.Text = dt.datTituloArte.ToString();

                        #region Ifs
                        if (dt.datContInteresado != null)
                        {
                            txtContIntFecha.Text = Convert.ToDateTime(dt.datContInteresado).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        }
                        if (dt.datCantInteresado != null)
                        {
                            txtCantInt.Text = Convert.ToInt32(dt.datCantInteresado).ToString();
                        }

                        if (dt.datContramensaje != null)
                        {
                            txtContraFecha.Text = Convert.ToDateTime(dt.datContramensaje).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        }
                        if (dt.datCantRecibidos != null)
                        {
                            txtCantRec.Text = Convert.ToInt32(dt.datCantRecibidos).ToString();
                        }
                        if (dt.datCita != null)
                        {
                            txtCitaFecha.Text = Convert.ToDateTime(dt.datCita).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        }
                        if (dt.datLlamadaFinal != null)
                        {
                            txtLlamada.Text = Convert.ToInt32(dt.datLlamadaFinal).ToString();
                        }
                        #endregion


                        #endregion


                        #region cargarUser
                        us = logUser.obtenerxID(Convert.ToInt32(dt.idUsuario));
                        if (us!=null)
                        {
                            txtUsuario.Text = us.usNombre.ToString() + " " +us.usApellido.ToString() ;
                        }
                        #endregion

                        

                        #region cargarPag
                        pg = logPagina.obtenerPagxID(Convert.ToInt32(dt.idPagina));
                        if (pg != null)
                        {
                            txtPagina.Text = pg.sitNombre.ToString();
                        }
                        #endregion

                        consultaImagenes(codigo);
                    }


                }
            }
        }

        void consultaImagenes(int cod)
        {
            SqlConnection con = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT datArte FROM tblDatos Where idDato=" + cod;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            try
            {
                byte[] img = (byte[])cmd.ExecuteScalar();

                if (img != null && img.Length > 0)
                {
                    img1.ImageUrl = "data:image;base64," + Convert.ToBase64String(img);
                }

            }
            catch (Exception)
            {

                loadImagen();
            }

            con.Close();
        }

        private void loadImagen()
        {
            img1.ImageUrl = "~/Mantenimiento/Imagenes/imagen.png";
        }

        void guardar()
        {
            try
            {
                dt.idDato = dato;
                dt.datContInteresado = Convert.ToDateTime(txtContIntFecha.Text);
                dt.datCantInteresado = Convert.ToInt32(txtCantInt.Text);
                dt.datContramensaje = Convert.ToDateTime(txtContraFecha.Text);
                dt.datCantRecibidos = Convert.ToInt32(txtCantRec.Text);
                dt.datLlamadaFinal = txtLlamada.Text;
                dt.datCita = Convert.ToDateTime(txtCitaFecha.Text );

                logDatos.actualizaDatos1(dt);
                lblMensaje.ForeColor = System.Drawing.Color.DarkGreen;
                lblMensaje.Text = "Enviado Exitosamente";
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void btnRegresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/analistaView.aspx");
        }
    }
}
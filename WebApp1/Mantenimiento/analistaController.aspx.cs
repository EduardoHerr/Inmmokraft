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
        private tblObservacion ob = new tblObservacion();
        private tblPagina pg = new tblPagina();
        private tblUsuario us = new tblUsuario();
        static bool  editar=false;
        static List<tblObservacion> list = new List<tblObservacion>();
        private static int dato;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                txtLista.Font.Size = 12;

                if (Request["cod"]!=null)
                {

                    int codigo = Convert.ToInt32(Request["cod"]);
                    dato = codigo;
                    dt = logDatos.obtenerDatos(codigo);
                    if (dt!=null)
                    {
                        #region CargaNormal
                        #region prueba
                        SqlConnection con = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "select * from tblObservacion where idDato=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = codigo;

                        SqlDataReader registros = cmd.ExecuteReader();
                        while (registros.Read())
                        {
                            txtIds.Text=txtIds.Text+registros["idObservacion"].ToString()+'\n';
                            txtLista.Text = txtLista.Text + registros["observacion"].ToString() + '\n';
                        }
                        con.Close();
                        #endregion
                        

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

            if (txtContIntFecha.Text == "" || txtContraFecha.Text == "")
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Formato No valido";
            }
            else
            {
                try
                {
                    dt.idDato = dato;
                    dt.datContInteresado = Convert.ToDateTime(txtContIntFecha.Text);
                    dt.datCantInteresado = Convert.ToInt32(txtCantInt.Text);
                    dt.datContramensaje = Convert.ToDateTime(txtContraFecha.Text);
                    dt.datCantRecibidos = Convert.ToInt32(txtCantRec.Text);


                    #region guardarTextArea

                    int codigo = Convert.ToInt32(Request["cod"]);
                    string[] xd = txtLista.Text.Split('\n');
                    string[] cadena = txtIds.Text.Split('\n');
                    int[] aux = new int[30];
                    int x = 0;
                    foreach (string c in cadena)
                    {
                        if (c.ToString() != "")
                        {
                            aux[x] = Convert.ToInt32(c.ToString());
                            x++;
                        }

                    }
                    int a = 0;
                    for (int i = 0; i < xd.Length; i++)
                    {
                        if (xd[i] != "")
                        {

                            try
                            {

                                int value = aux[a];

                                if (value != 0)
                                {


                                    SqlConnection con = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "update tblObservacion  set observacion= @observacion where idObservacion=@id";
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 255).Value = xd[i];
                                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = value;

                                    con.Open();
                                    cmd.ExecuteNonQuery();

                                    con.Close();
                                }
                                else
                                {
                                    SqlConnection con = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "insert into tblObservacion (idDato,observacion) values(" + codigo + ",@observacion)";
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 255).Value = xd[i];

                                    con.Open();
                                    cmd.ExecuteNonQuery();

                                    con.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new ArgumentException("Error: " + ex.Message);

                            }




                        }

                        a++;
                        editar = true;
                    }

                    #endregion
                    if (editar != true)
                    {
                        for (int j = 0; j < xd.Length; j++)
                        {
                            SqlConnection con = new SqlConnection("Data Source=Inmmokraft.mssql.somee.com;Initial Catalog=Inmmokraft;Persist Security Info=True;User ID=Barbas_SQLLogin_1;Password=xhuilpj8aq");
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "insert into tblObservacion (idDato,observacion) values(" + codigo + ",@observacion)";
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 255).Value = xd[j];

                            con.Open();
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                    }

                    logDatos.actualizaDatos1(dt);
                    lblMensaje.ForeColor = System.Drawing.Color.DarkGreen;
                    lblMensaje.Text = "Enviado Exitosamente";
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //probarGuardado();
            
            guardar();
        }

        private void probarGuardado()
        {
           
        }

        protected void btnRegresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Mantenimiento/analistaView.aspx");
        }

        
    }
}
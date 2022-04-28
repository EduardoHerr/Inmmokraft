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
    public partial class nuevoDato : System.Web.UI.Page
    {
        private tblDatos dat = new tblDatos();
        static private DataBaseDataContext db = new DataBaseDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadImagen();
                cargarPag();
                if (Request["cod"]!=null)
                {
                    btnEditar.Visible = true;
                    btnGuardar.Visible = false;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    dat = logDatos.obtenerDatos(codigo);
                    if (dat!=null)
                    {
                        txtFecha.Text = Convert.ToDateTime(dat.datFechaHoraPub).ToString("dd/MM/yyyy");
                        txtHora.Text = Convert.ToDateTime(dat.datFechaHoraPub).ToString("HH:mm");
                        txtPerfil.Text = dat.datPerfil.ToString();
                        txtPropiedad.Text = dat.datPropiedad.ToString();
                        txtTipo.Text = dat.datTipo.ToString();
                        txtSitio.Text = dat.datSitio.ToString();
                        txtGrupos.Text = dat.datGrupoPost.ToString();
                        ddl1.SelectedValue=dat.idPagina.ToString();
                        int val = Convert.ToInt32(dat.idPagina.ToString());
                        cargaGrupo(val);
                        ddl2.SelectedValue=dat.idGrupo.ToString();

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

        void limpiar()
        {
            txtFecha.Text = txtPerfil.Text = txtPropiedad.Text = txtSitio.Text = txtSubir.Text = txtTipo.Text = txtGrupos.Text = txtHora.Text = "";
            ddl1.SelectedIndex = 0;
            loadImagen();
        }
        private void cargarPag()
        {
            List<tblPagina> listpag = new List<tblPagina>();
            listpag = logPagina.obtenerPag();
            listpag.Insert(0, new tblPagina() { sitNombre = "Seleccione" });
            ddl1.DataSource = listpag;
            ddl1.DataTextField = "sitNombre";
            ddl1.DataValueField = "idPagina";
            ddl1.DataBind();
        }


        void cargaGrupo(int valor)
        {
            List<tblGrupos> listgrup = new List<tblGrupos>();
            listgrup = logPagina.obtenerGrupo(valor);
            listgrup.Insert(0, new tblGrupos() { grupNombre = "Seleccione" });
            ddl2.DataSource = listgrup;
            ddl2.DataTextField = "grupNombre";
            ddl2.DataValueField = "idGrupo";
            ddl2.DataBind();
        }
        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pag = ddl1.SelectedIndex;
            if (pag != 0)
            {
                cargaGrupo(pag);
            }

        }

        private void loadImagen()
        {
            img1.ImageUrl = "~/Mantenimiento/Imagenes/imagen.png";
        }

        protected void btnRegresa_Click(object sender, EventArgs e)
        {
            if (Session["rol"]!=null)
            {
                int rol = Convert.ToInt32(Session["rol"]);
                if (rol==1)
                {
                    Response.Redirect("~/Mantenimiento/PageDatos.aspx");
                }
                else if (rol==2)
                {
                    Response.Redirect("~/Mantenimiento/postViewer.aspx");
                }
                else
                {

                }
            }
            
        }

        void guardar()
        {
            try
            {
                string fechaHora = txtFecha.Text + " " + txtHora.Text;
                lblMensaje.Text = "";
                dat = new tblDatos();
                if (Session["idPost"]!=null)
                {
                    int key = Convert.ToInt32(Session["idPost"]);
                    dat.idUsuario = key;

                }
                dat.datPerfil = txtPerfil.Text;
                dat.datPropiedad = txtPropiedad.Text;
                dat.datTipo = txtTipo.Text;
                dat.datFechaHoraPub = Convert.ToDateTime(fechaHora);
                dat.datSitio = txtSitio.Text;
                dat.datGrupoPost = Convert.ToInt32(txtGrupos.Text);
                dat.idPagina = Convert.ToInt32(ddl1.SelectedValue);
                dat.idGrupo = Convert.ToInt32(ddl2.SelectedValue);
                if (fileu.HasFile)
                {
                    dat.datTituloArte = fileu.FileName;
                    #region CargarImagen
                    //Funcion para devolver el tamaño de la imagen
                    int tamanio = fileu.PostedFile.ContentLength;
                    //array de bytes
                    byte[] imageNew = new byte[tamanio];
                    //Leer la imagen original
                    fileu.PostedFile.InputStream.Read(imageNew, 0, tamanio);

                    Bitmap imageOriginalBinaria = new Bitmap(fileu.PostedFile.InputStream);
                    #endregion

                    #region imgThumbnail
                    System.Drawing.Image imgt;
                    int tamaniot = 200;
                    imgt = Redimencion(imageOriginalBinaria, tamaniot);
                    byte[] bImageOriginal = new byte[tamaniot];
                    ImageConverter Convertidor = new ImageConverter();
                    bImageOriginal = (byte[])Convertidor.ConvertTo(imgt, typeof(byte[]));
                    #endregion

                    #region InsertarenBD
                    dat.datArte = bImageOriginal;


                    #endregion
                    string imagendataurl64 = "data:image/jpeg;base64," + Convert.ToBase64String(bImageOriginal);


                    img1.ImageUrl = imagendataurl64;
                }





                logDatos.registrarDatos(dat);
                lblMensaje.Text = "Datos Registrados Exitosamente";
                
            }
            catch (Exception)
            {

                throw;
            }
            

        }
        public System.Drawing.Image Redimencion(System.Drawing.Image imageOriginal, int Alto)
        {
            var Radio = (double)Alto / imageOriginal.Height;
            var nancho = (int)(imageOriginal.Width * Radio);
            var nalto = (int)(imageOriginal.Height * Radio);
            var niredi = new Bitmap(nancho, nalto);
            var g = Graphics.FromImage(niredi);
            g.DrawImage(imageOriginal, 0, 0, nancho, nalto);


            return niredi;
        }

        private void modify(tblDatos datmod)
        {
            try
            {
                lblMensaje.Text = "";

                string fechaHora = txtFecha.Text + " " + txtHora.Text;
                lblMensaje.Text = "";
                

                datmod.datPerfil = txtPerfil.Text;
                datmod.datPropiedad = txtPropiedad.Text;
                datmod.datTipo = txtTipo.Text;
                datmod.datFechaHoraPub = Convert.ToDateTime(fechaHora);
                datmod.datSitio = txtSitio.Text;
                datmod.datGrupoPost = Convert.ToInt32(txtGrupos.Text);
                datmod.idPagina = Convert.ToInt32(ddl1.SelectedValue);
                datmod.idGrupo = Convert.ToInt32(ddl2.SelectedValue);
                

                if (fileu.HasFile)
                {
                    #region CargarImagen
                    //Funcion para devolver el tamaño de la imagen
                    int tamanio = fileu.PostedFile.ContentLength;
                    //array de bytes
                    byte[] imageNew = new byte[tamanio];
                    //Leer la imagen original
                    fileu.PostedFile.InputStream.Read(imageNew, 0, tamanio);

                    Bitmap imageOriginalBinaria = new Bitmap(fileu.PostedFile.InputStream);
                    #endregion

                    #region imgThumbnail
                    System.Drawing.Image imgt;
                    int tamaniot = 200;
                    imgt = Redimencion(imageOriginalBinaria, tamaniot);
                    byte[] bImageOriginal = new byte[tamaniot];
                    ImageConverter Convertidor = new ImageConverter();
                    bImageOriginal = (byte[])Convertidor.ConvertTo(imgt, typeof(byte[]));
                    #endregion

                    #region InsertarenBD
                    datmod.datArte = bImageOriginal;
                    datmod.datTituloArte = fileu.FileName;

                    #endregion
                    string imagendataurl64 = "data:image/jpeg;base64," + Convert.ToBase64String(bImageOriginal);


                    img1.ImageUrl = imagendataurl64;
                }




                logDatos.actualizaDatos(datmod);
                lblMensaje.Text = "Datos Actualizados Exitosamente";
               

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarEditar(Convert.ToInt32(Request["cod"]));
        }

        void guardarEditar(int key)
        {
            if (key==0)
            {
                guardar();
            }
            else
            {
                dat = logDatos.obtenerDatos(key);
                if (dat!=null)
                {
                    modify(dat);
                }
            }

        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            guardarEditar(Convert.ToInt32(Request["cod"]));
        }
    }
}
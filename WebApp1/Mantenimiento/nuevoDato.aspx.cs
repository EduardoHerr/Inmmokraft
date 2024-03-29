﻿using System;
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
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                loadImagen();
                cargarPag();
                btnEditar.Visible=false;
                if (Request["cod"]!=null)
                {
                    btnEditar.Visible = true;
                    btnGuardar.Visible = false;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    dat = logDatos.obtenerDatos(codigo);
                    if (dat!=null)
                    {
                        txtFecha.Text = Convert.ToDateTime(dat.datFechaHoraPub).ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                        txtPerfil.Text = dat.datPerfil.ToString();
                        txtPropiedad.Text = dat.datPropiedad.ToString();
                        txtTipo.Text = dat.datTipo.ToString();
                        txtSitio.Text = dat.datSitio.ToString();
                        //txtGrupos.Text = dat.datGrupoPost.ToString();
                        ddl1.SelectedValue=dat.idPagina.ToString();
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
            txtFecha.Text = txtPerfil.Text = txtPropiedad.Text = txtSitio.Text =  txtTipo.Text = txtGrupos.Text =  "";
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


        
        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pag = ddl1.SelectedIndex;
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
            if (string.IsNullOrEmpty(txtFecha.Text)|| string.IsNullOrEmpty(txtGrupos.Text) || string.IsNullOrEmpty(txtPerfil.Text) || string.IsNullOrEmpty(txtPropiedad.Text) || string.IsNullOrEmpty(txtSitio.Text) || string.IsNullOrEmpty(txtTipo.Text))
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Campo Vacio";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtFecha.Text) || string.IsNullOrWhiteSpace(txtGrupos.Text) || string.IsNullOrWhiteSpace(txtPerfil.Text) || string.IsNullOrWhiteSpace(txtPropiedad.Text) || string.IsNullOrWhiteSpace(txtSitio.Text) || string.IsNullOrWhiteSpace(txtTipo.Text))
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Campo en Blanco";
                }
                else
                {
                    try
                    {

                        lblMensaje.Text = "";
                        dat = new tblDatos();
                        if (Session["idPost"] != null)
                        {
                            int key = Convert.ToInt32(Session["idPost"]);
                            dat.idUsuario = key;

                        }
                        else
                        {
                            if (Session["idAdmin"]!=null)
                            {
                                int keya = Convert.ToInt32(Session["idAdmin"]);
                                dat.idUsuario = keya;
                            }
                        }
                        dat.datPerfil = txtPerfil.Text.Trim();
                        dat.datPropiedad = txtPropiedad.Text.ToLower().Trim();
                        dat.datTipo = txtTipo.Text.Trim();
                        dat.datFechaHoraPub = Convert.ToDateTime(txtFecha.Text);
                        dat.datSitio = txtSitio.Text.Trim();
                        
                        dat.idPagina = Convert.ToInt32(ddl1.SelectedValue);

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
                        lblMensaje.ForeColor = Color.Green;
                        lblMensaje.Text = "Datos Registrados Exitosamente";
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
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

                datmod.datPerfil = txtPerfil.Text;
                datmod.datPropiedad = txtPropiedad.Text;
                datmod.datTipo = txtTipo.Text;
                datmod.datFechaHoraPub = Convert.ToDateTime(txtFecha.Text);
                datmod.datSitio = txtSitio.Text;
                
                datmod.idPagina = Convert.ToInt32(ddl1.SelectedValue);
                
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
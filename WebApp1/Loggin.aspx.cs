﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using System.Drawing;

namespace WebApp1
{
    public partial class Loggin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void ingresar(string ci, string clave)
        {
            if (string.IsNullOrEmpty(ci) || string.IsNullOrEmpty(clave))
            {
                lblMensaje.ForeColor = Color.DarkRed;
                lblMensaje.Text = "Campo Vacio";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(ci) || string.IsNullOrWhiteSpace(clave))
                {
                    lblMensaje.ForeColor = Color.DarkRed;
                    lblMensaje.Text = "Espacio en Blanco";
                }
                else
                {
                    bool usExiste = logUser.usLog(ci);
                    bool usCorrecto = logUser.autentificarLog(ci, clave);

                    if (usExiste)
                    {
                        if (usCorrecto)
                        {
                            tblUsuario us = new tblUsuario();

                            us = logUser.autentificarxLoginlog(ci, clave);

                            int tuser = (int)us.idTipUsu;
                            string nombre = us.usNombre;

                            if (tuser == 1)
                            {
                                string admin = us.idUsuario.ToString();
                                Session["idAdmin"] = admin;
                                Session["rol"] = "1";
                                Session["nombre"] = nombre;
                                Response.Redirect("~/inicioAdmin.aspx");
                            }

                            if (tuser == 2)
                            {
                                string poster = us.idUsuario.ToString();
                                Session["rol"] = "2";
                                Session["nombre"] = nombre;
                                Session["idPost"] = poster;
                                Response.Redirect("~/Mantenimiento/postViewer.aspx");
                            }

                            if (tuser == 3)
                            {
                                Session["rol"] = "3";
                                Session["nombre"] = nombre;
                                Response.Redirect("~/Mantenimiento/analistaView.aspx");
                            }

                        }
                        else
                        {
                            lblMensaje.ForeColor = Color.Red;
                            lblMensaje.Text = "<h3>Datos Incorrectos..</h3>";
                        }
                    }
                    else
                    {
                        lblMensaje.ForeColor = Color.Red;
                        
                        lblMensaje.Text = "<h3>Usuarios no Existentes</h3>";
                    }

                }
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ingresar(txtUsuario.Text, txtClave.Text);
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="analistaController.aspx.cs" Inherits="WebApp1.Mantenimiento.analistaController" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/actualizacionDatos.css" />
    
    <div class="centrar">
        <asp:Button ID="btnRegresa" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresa_Click" />
        <center>
            <h1><asp:Label ID="lblMensaje" runat="server" Text="Registro de Datos"></asp:Label></h1>
        </center>

        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"  Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblPagina" runat="server" Text="Pagina" ></asp:Label>
                        <asp:TextBox ID="txtPagina" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblperfil" runat="server" Text="Perfil" ></asp:Label>
                        <asp:TextBox ID="txtPerfil" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Hora de Posteo"></asp:Label>
                        <asp:TextBox ID="txtFecha" TextMode="DateTimeLocal" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"  Enabled="False"></asp:TextBox>
                        
                    </div>
                </div>

            </div>
            
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblPropiedad" runat="server" Text="Propiedad" ></asp:Label>
                        <asp:TextBox ID="txtPropiedad" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Sitio" ></asp:Label>
                        <asp:TextBox ID="txtSitio" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">

                <div class="col-3">
                    <div class="form-group">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                        <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">

                        <asp:Label ID="Label9" runat="server" Text="Visualización de Archivos"></asp:Label>
                        <br />
                        <center>
                            <asp:Image ID="img1" runat="server" Width="200px" Height="200px" />
                        </center>
                        <br />
                        <asp:TextBox ID="txtSubir" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                </div>
            </div>

        <br />
        
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Contestacion Interesados" ></asp:Label>
                        <asp:TextBox ID="txtContIntFecha" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblCantInt" runat="server" Text="Cantidad de Interesados" ></asp:Label>
                    <asp:TextBox ID="txtCantInt" runat="server" TextMode="Number" CssClass="form-control" min="1">1</asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblContra" runat="server" Text="Contra Mensaje"></asp:Label>
                        <asp:TextBox ID="txtContraFecha" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblCantidadRecibidos" runat="server" Text="Cantidad de Recibidos"></asp:Label>
                    <asp:TextBox ID="txtCantRec" runat="server" TextMode="Number" CssClass="form-control" min="1">1</asp:TextBox>
                </div>
            </div>
            <br />
            <%--<div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblCita" runat="server" Text="Cita"></asp:Label>
                        <asp:TextBox ID="txtCitaFecha" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
                        
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblLlamada" runat="server" Text="Llamada Final" ></asp:Label>
                    <asp:TextBox ID="txtLlamada" runat="server" TextMode="Number" CssClass="form-control" min="1">1</asp:TextBox>
                </div>
            </div>--%>
            <div class="row">
                <div class="col-1">
                    <p>ID</p>
                </div>
                <div class="col-3">
                    <p>Nombre</p>
                </div>
                <div class="col-3">
                    <p>Fecha Cita</p>
                </div>
                <div class="col-3">
                    <p>Llamada final</p>
                </div>

                <div class="col-12">
                    <div class="row">
                        <div class="col-1">
                            <asp:TextBox ID="txtIds" Enabled="false" runat="server" Height="100px" TextMode="MultiLine" ></asp:TextBox>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="txtLista" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
                        </div>
                    </div>
                    
                </div>
            </div>

        </div>
       <br />
        <center>
            <asp:Button ID="btnEnviar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnEnviar_Click" />
        </center>
         
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="analistaController.aspx.cs" Inherits="WebApp1.Mantenimiento.analistaController" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/actualizacionDatos.css" />
    
    <div class="centrar">
        <center>
            <h1><asp:Label ID="lblMensaje" runat="server" Text="Registro de Datos"></asp:Label></h1>
        </center>

        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"   Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblPagina" runat="server" Text="Pagina" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtPagina" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblGrupo" runat="server" Text="Grupo" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>

                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblperfil" runat="server" Text="Perfil" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtPerfil" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblPropiedad" runat="server" Text="Propiedad" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtPropiedad" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Hora de Posteo" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"  Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="txtHora" runat="server" CssClass="form-control" TextMode="Time" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Sitio" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtSitio" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Grupos" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtGrupos" runat="server" CssClass="form-control" TextMode="Number" Enabled="False"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Pagina/Grupo" CssClass="form-control"></asp:Label>
                        <div class="container">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel runat="server" ID="update">
                                <ContentTemplate>
                                    <br />
                   <%-- <asp:DropDownList ID="ddl1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                         <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control"></asp:DropDownList>--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>

        <br />
            <div class="form-group">
                <asp:Label ID="Label9" runat="server" Text="Visualización de Archivos" CssClass="form-control"></asp:Label>
                <br />

                <div class="row">
                    <div class="col">
                        <asp:Image ID="img1" runat="server" Width="200px" Height="200px" />
                    </div>
                    <div class="col">
                        <asp:TextBox ID="txtSubir" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>
        <br />
        
            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Contestacion Interes" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtContIntFecha" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>
                        <asp:TextBox ID="txtContIntDia" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblCantInt" runat="server" Text="Cantidad de Interesados" CssClass="form-control"></asp:Label>
                    <asp:TextBox ID="txtCantInt" runat="server" TextMode="Number" CssClass="form-control">0</asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblContra" runat="server" Text="Contra Mensaje" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtContraFecha" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>
                        <asp:TextBox ID="txtContraDia" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblCantidadRecibidos" runat="server" Text="Cantidad de Recibidos" CssClass="form-control"></asp:Label>
                    <asp:TextBox ID="txtCantRec" runat="server" TextMode="Number" CssClass="form-control">0</asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label ID="lblCita" runat="server" Text="Cita" CssClass="form-control"></asp:Label>
                        <asp:TextBox ID="txtCitaFecha" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa"></asp:TextBox>
                        <asp:TextBox ID="txtCitaDia" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
                    </div>
                </div>
                <div class="col">
                    <asp:Label ID="lblLlamada" runat="server" Text="Llamada Final"  CssClass="form-control"></asp:Label>
                    <asp:TextBox ID="txtLlamada" runat="server" TextMode="Number" CssClass="form-control">0</asp:TextBox>
                </div>
            </div>

        </div>
       <br />
        <center>
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-success" OnClick="btnEnviar_Click" />
        </center>
         
    </div>

</asp:Content>

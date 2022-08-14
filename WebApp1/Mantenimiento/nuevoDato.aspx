<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="nuevoDato.aspx.cs" Inherits="WebApp1.Mantenimiento.nuevoDato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/registroDatos.css" />
    
            <div class="centrar">

                <asp:Button ID="btnRegresa" runat="server" Text="↤ Regresar" OnClick="btnRegresa_Click" CssClass="btn btn-primary" />

                <center>
                    <h1>
                        <asp:Label ID="lblNotificacion" runat="server" Text="Registro de Datos"></asp:Label>

                    </h1>
                </center>
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblperfil" runat="server" Text="Perfil"></asp:Label>
                            <asp:TextBox ID="txtPerfil" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblPropiedad" runat="server" Text="Articulo"></asp:Label>
                            <asp:TextBox ID="txtPropiedad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Hora de Posteo"></asp:Label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Sitio"></asp:Label>
                            <asp:TextBox ID="txtSitio" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="form-group">
                            <asp:Label ID="Label8" runat="server" Text="Pagina/Grupo"></asp:Label>
                            <asp:DropDownList ID="ddl1" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="col-4">
                        <div class="form-group">
                            <asp:Label ID="Label6" runat="server" Text="Grupos" Visible="false"></asp:Label>
                            <asp:TextBox ID="txtGrupos" runat="server" CssClass="form-control" TextMode="Number" min="1" Text="1" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col">
                        <div class="contorno">
                            <div class="form-group">
                                <h5>Cargar Imagen</h5>

                                <div class="row">
                                    <div class="col">

                                        <asp:Image ID="img1" runat="server" Width="200px" Height="200px" />
                                        <asp:FileUpload ID="fileu" accept=".jpeg,.png" runat="server" />


                                    </div>

                                </div>
                            </div>
                        </div>
                        <br />
                    </div>

                </div>

                <br />
                <div class="row">
                    <div class="col-4">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>
                    <div class="col">
                        <asp:Button ID="btnGuardar" runat="server" Text="Registrar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnEditar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="btnEditar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-warning" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
            

</asp:Content>

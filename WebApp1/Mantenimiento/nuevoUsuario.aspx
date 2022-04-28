<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="nuevoUsuario.aspx.cs" Inherits="WebApp1.Mantenimiento.nuevoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/registroUser.css" />
    <div class="padre">
    <form class="row g-3">
        <center>
        <div class="col-md-12">
            <asp:Label ID="lblMensaje" runat="server" Text="Hola" CssClass="Titulo" ></asp:Label>
        </div>
            </center>
        <div class="col-md-11">
            <label class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <label class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <!---->
        <div class="col-md-11">
            <label class="form-label">Cedula</label>
            <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <label class="form-label">Clave</label>
            <asp:TextBox ID="txtCalve" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!---->
        <div class="col-md-11">
            <label class="form-label">Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <label class="form-label">Direccion</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-11">
            <label class="form-label">Rol</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control" Height="35px"></asp:DropDownList>
        </div>
        <br />
        <div>
            <center>
                <asp:LinkButton ID="lnkGuardar" CssClass="btn btn-outline-success" OnClick="lnkGuardar_Click" runat="server">Guardar</asp:LinkButton>
                <asp:LinkButton ID="lnkeditar" CssClass="btn btn-outline-success" OnClick="lnkeditar_Click" runat="server">Editar</asp:LinkButton>
                <asp:LinkButton ID="lnkRegresar" CssClass="btn btn-outline-secondary" OnClick ="lnkRegresar_Click" runat="server">Regresar</asp:LinkButton>
            </center>
        </div>
    </form>
    </div>
</asp:Content>

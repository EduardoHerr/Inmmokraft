<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="vistaAdmin.aspx.cs" Inherits="WebApp1.Mantenimiento.vistaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
    </div>
    <br />
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    <asp:GridView ID="grvCRUD" AutoGenerateColumns="false" OnRowCommand="grvCRUD_RowCommand" runat="server" CssClass="table table-dark table-hover">
    <Columns>
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("usNombre")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Apellido">
            <ItemTemplate>
                <asp:Label ID="lblApellido" runat="server" Text='<%#Eval("usApellido")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Cedula">
            <ItemTemplate>
                <asp:Label ID="lblCedula" runat="server" Text='<%#Eval("usCedula")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Clave">
            <ItemTemplate>
                <asp:Label ID="lblClave" runat="server" Text='<%#Eval("usClave")%>'></asp:Label>        
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Correo">
            <ItemTemplate>
                <asp:Label ID="lblCorreo" runat="server" Text='<%#Eval("usCorreo")%>'></asp:Label>        
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Dirección">
            <ItemTemplate>
                <asp:Label ID="lblDireccion" runat="server" Text='<%#Eval("usDireccion")%>'></asp:Label>        
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

    </asp:GridView>


</asp:Content>

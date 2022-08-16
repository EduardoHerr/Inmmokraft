<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="PageDatos.aspx.cs" Inherits="WebApp1.Mantenimiento.PageDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0px 10px;">
    <div>
        <asp:Button ID="btnAgregarDato" CssClass="btn btn-primary" OnClick="btnAgregarDato_Click" runat="server" Text=" 🕀 Agregar" />
    </div>
    <br />
    <asp:GridView ID="gdvDatos" AutoGenerateColumns="false" OnRowCommand="gdvDatos_RowCommand" runat="server" CssClass="table table-dark table-hover">
        <Columns>
            <asp:TemplateField HeaderText="Rol">
                <ItemTemplate>
                    <asp:Label ID="lblRol" runat="server" Text='<%#Eval("tusuRol") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Usuario">
                <ItemTemplate>
                    <asp:Label ID="lblUsuario" runat="server" Text='<%#Eval("usNombre") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pagina">
                <ItemTemplate>
                    <asp:Label ID="lblPagina" runat="server" Text='<%#Eval("sitNombre") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Perfil">
                <ItemTemplate>
                    <asp:Label ID="lblPerfil" runat="server" Text='<%#Eval("datPerfil") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Propiedad">
                <ItemTemplate>
                    <asp:Label ID="lblPropiedad" runat="server" Text='<%#Eval("datPropiedad") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tipo">
                <ItemTemplate>
                    <asp:Label ID="lblTipo" runat="server" Text='<%#Eval("datTipo") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Arte">
                <ItemTemplate>
                    <asp:Label ID="lblArte" runat="server" Text='<%#Eval("datTituloArte") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha y Hora">
                <ItemTemplate>
                    <asp:Label ID="lblFeHo" runat="server" Text='<%#Eval("datFechaHoraPub") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sitio">
                <ItemTemplate>
                    <asp:Label ID="lblSitio" runat="server" Text='<%#Eval("datSitio") %>'></asp:Label>    
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%#Eval("idDato")%>' CommandName="Editar" CssClass="btn btn-outline-warning" >Editar</asp:LinkButton>
                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%#Eval("idDato")%>' CommandName="Eliminar" onClientClick="return confirm('Seguro de Eliminar el registro?')" CssClass="btn btn-outline-danger" >Eliminar</asp:LinkButton>    
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
        </div>
</asp:Content>

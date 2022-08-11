<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="postViewer.aspx.cs" Inherits="WebApp1.Mantenimiento.postViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:0px 5px;">
        <asp:Button ID="btnAgregar" runat="server" Text=" 🕀 Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
    </div>
    <br />
    <center>
        
        <asp:Label ID="lbl1" runat="server" Text="<h3>No hay Datos Existentes....</h3>"></asp:Label>
    </center>
    <div style="margin:0px 10px;">
    <asp:GridView ID="grvDatos" AutoGenerateColumns="false" OnRowCommand="grvDatos_RowCommand" runat="server" CssClass="table table-dark table-hover rounded-right">
        <Columns>
            
            <asp:BoundField HeaderText="Página" DataField="sitNombre" />
            

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

            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label ID="lblFecha" runat="server" Text='<%#Eval("datFechaHoraPub") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Sitio">
                <ItemTemplate>
                    <asp:Label ID="lblSitio" runat="server" Text='<%#Eval("datSitio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Post">
                <ItemTemplate>
                    <asp:Label ID="lblPost" runat="server" Text='<%#Eval("datGrupoPost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Accion">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" CommandArgument='<%#Eval("idDato") %>' CommandName="Editar" runat="server" CssClass="btn btn-outline-warning">Editar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>



        </Columns>
    </asp:GridView>
        </div>
</asp:Content>

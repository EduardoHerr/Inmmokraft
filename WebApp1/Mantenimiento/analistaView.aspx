<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="analistaView.aspx.cs" Inherits="WebApp1.Mantenimiento.analistaView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="analistaController.aspx">Link</a>
    <div style="width:100%; overflow:auto">
        <asp:GridView ID="gvrAnalista" runat="server" AutoGenerateColumns="false" OnRowCommand="gvrAnalista_RowCommand" CssClass="table  table-bordered table-dark">
            <Columns>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" CommandArgument='<%#Eval("idDato") %>' CommandName="Editar" runat="server" CssClass="btn btn-outline-warning">Añadir</asp:LinkButton>
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

            <asp:TemplateField HeaderText="Grupo">
                <ItemTemplate>
                    <asp:Label ID="lblGrupo" runat="server" Text='<%#Eval("grupNombre") %>'></asp:Label>
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
                <asp:BoundField HeaderText="Fecha" DataField="datFechaHoraPub" DataFormatString="{0:dd/MM/yyyy HH:mm}" HtmlEncode="false" />
                
          

            <asp:TemplateField HeaderText="Sitio">
                <ItemTemplate>
                    <asp:Label ID="lblSitio" runat="server" Text='<%#Eval("datSitio") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Post">
                <ItemTemplate>
                    <asp:Label ID="lblPost" runat="server" Text='<%#Eval("datGrupoPost") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Contestación">
                <ItemTemplate>
                    <asp:Label ID="lblContestación" runat="server" Text='<%#Eval("datContInteresado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Interesados">
                <ItemTemplate>
                    <asp:Label ID="lblInteresados" runat="server" Text='<%#Eval("datCantInteresado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Contramensaje">
                <ItemTemplate>
                    <asp:Label ID="lblContramensaje" runat="server" Text='<%#Eval("datContramensaje") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Recibidos">
                <ItemTemplate>
                    <asp:Label ID="lblRecibidos" runat="server" Text='<%#Eval("datCantRecibidos") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField HeaderText="Llamada">
                <ItemTemplate>
                    <asp:Label ID="lblLlamada" runat="server" Text='<%#Eval("datLlamadaFinal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


                <asp:TemplateField HeaderText="Cita">
                <ItemTemplate>
                    <asp:Label ID="lblCita" runat="server" Text='<%#Eval("datCita") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>

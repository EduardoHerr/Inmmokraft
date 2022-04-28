<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="PageUsuarios.aspx.cs" Inherits="WebApp1.Mantenimiento.PageUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/registroUser.css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="btnNuevo">
            <asp:Button ID="btnNuevoUser" OnClick="btnNuevoUser_Click" CssClass="btn btn-primary" runat="server" Text="Nuevo Usuario"  />
                </div>
            <br />
            <center>
                <div class="tabla">
            <asp:GridView ID="gdvUsuario" style="margin-top:15px;" OnRowCommand="gdvUsuario_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="table table-dark table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Acciones">
                       <ItemTemplate>
                          
                           <asp:LinkButton ID="btnActualizar" cssClass="btn btn-warning"   CommandArgument='<%#Eval("idUsuario")%>' CommandName="Editar" runat="server">Actualizar</asp:LinkButton>
                           <asp:LinkButton ID="btnEliminar" cssClass="btn btn-danger"   CommandArgument='<%#Eval("idUsuario") %>' CommandName="Eliminar" onClientClick="return confirm('Seguro de Eliminar el registro?')" runat="server">Eliminar</asp:LinkButton>
                       </ItemTemplate>
                   </asp:TemplateField>
                    
                   <asp:TemplateField HeaderText="Rol">
                       <ItemTemplate>
                           <asp:Label ID="lblTipoUser" runat="server" Text='<%#Eval("idTipUsu")%>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                        
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

                     <asp:TemplateField HeaderText="Direccion">
                       <ItemTemplate>
                           <asp:Label ID="lblDireccion" runat="server" Text='<%#Eval("usDireccion")%>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>

                     

                    

                </Columns>
            </asp:GridView>
                    </div>
                </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

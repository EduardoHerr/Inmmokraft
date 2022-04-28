<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="nuevoDato.aspx.cs" Inherits="WebApp1.Mantenimiento.nuevoDato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="css/registroDatos.css" />
    <div class="centrar">
        <center>
            <h1>
                <asp:Label ID="lblMensaje" runat="server" Text="Registro de Datos"></asp:Label>

            </h1>
        </center>
        <div class="form-group">          
                <asp:Label ID="lblperfil" runat="server" Text="Perfil" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtPerfil" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">          
                <asp:Label ID="lblPropiedad" runat="server" Text="Propiedad" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtPropiedad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">          
                <asp:Label ID="lblTipo" runat="server" Text="Tipo" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">          
                <asp:Label ID="Label4" runat="server" Text="Hora de Posteo" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" placeholder="dd/mm/aaaa" ></asp:TextBox>
            <asp:TextBox ID="txtHora" runat="server" CssClass="form-control" TextMode="Time"></asp:TextBox>
        </div>
        <div class="form-group">          
                <asp:Label ID="Label5" runat="server" Text="Sitio" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtSitio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">          
                <asp:Label ID="Label6" runat="server" Text="Grupos" CssClass="form-control"></asp:Label>          
                <asp:TextBox ID="txtGrupos" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        
        <div class="form-group">          
                <asp:Label ID="Label8" runat="server" Text="Pagina/Grupo"  CssClass="form-control"></asp:Label>          
            <div class="container">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="update">
                    <ContentTemplate>
                <br />
            <asp:DropDownList ID="ddl1" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        
            <asp:DropDownList ID="ddl2" runat="server" CssClass="form-control"></asp:DropDownList>

                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
        </div>
        
        <br />
        <div class="contorno">
         <div class="form-group">          
               <asp:Label ID="Label9" runat="server" Text="Carga de Archivos" CssClass="form-control"></asp:Label>          
             <br />
             <div class="row">
            <div class="col">
                <center>
                <asp:Image ID="img1" runat="server"  Width="200px" Height="200px"/>
                <asp:FileUpload ID="fileu" accept=".jpeg,.png" runat="server" />                    
                    <asp:TextBox ID="txtSubir" runat="server"></asp:TextBox>
                    </center>
            </div>
            
</div>
        </div>
            </div>
        <br />
        <center>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-outline-success"  OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-outline-warning" OnClick="btnEditar_Click"/>
            <asp:Button ID="btnRegresa" runat="server" Text="Regresar" OnClick="btnRegresa_Click" CssClass="btn btn-outline-dark" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-dark" OnClick="btnLimpiar_Click" />
        </center>

    </div>
        
</asp:Content>

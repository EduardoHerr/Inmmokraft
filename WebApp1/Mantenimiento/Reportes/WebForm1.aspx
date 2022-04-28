<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApp1.Mantenimiento.Reportes.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/style.css">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <center>
Formato:
    <asp:RadioButtonList ID="rbFormat" CssClass="form-check" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="Word"  Value="WORD" Selected="True" />
        <asp:ListItem Text="Excel" Value="EXCEL" />
        <asp:ListItem Text="PDF" Value="PDF" />
        <asp:ListItem Text="Image" Value="IMAGE" />
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btnExport" Text="Export" CssClass="btn btn-primary" runat="server" OnClick="Export" />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Height="1004px" Width="625px">
        <LocalReport ReportPath="Mantenimiento\Reportes\Report1.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:InmmokraftConnectionString %>" SelectCommand="SELECT * FROM [tblDatos]"></asp:SqlDataSource>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="WebApp1.Mantenimiento.Reportes.DataSet1TableAdapters.tblDatosTableAdapter" UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Original_idDato" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="idUsuario" Type="Int32" />
        <asp:Parameter Name="idPagina" Type="Int32" />
        <asp:Parameter Name="idGrupo" Type="Int32" />
        <asp:Parameter Name="datPerfil" Type="String" />
        <asp:Parameter Name="datPropiedad" Type="String" />
        <asp:Parameter Name="datTipo" Type="String" />
        <asp:Parameter Name="datArte" Type="Object" />
        <asp:Parameter Name="datTituloArte" Type="String" />
        <asp:Parameter Name="datFechaHoraPub" Type="DateTime" />
        <asp:Parameter Name="datSitio" Type="String" />
        <asp:Parameter Name="datGrupoPost" Type="Int32" />
        <asp:Parameter Name="datContInteresado" Type="DateTime" />
        <asp:Parameter Name="datCantInteresado" Type="Int32" />
        <asp:Parameter Name="datContramensaje" Type="DateTime" />
        <asp:Parameter Name="datCantRecibidos" Type="Int32" />
        <asp:Parameter Name="datLlamadaFinal" Type="String" />
        <asp:Parameter Name="datCita" Type="DateTime" />
        <asp:Parameter Name="datEstado" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="idUsuario" Type="Int32" />
        <asp:Parameter Name="idPagina" Type="Int32" />
        <asp:Parameter Name="idGrupo" Type="Int32" />
        <asp:Parameter Name="datPerfil" Type="String" />
        <asp:Parameter Name="datPropiedad" Type="String" />
        <asp:Parameter Name="datTipo" Type="String" />
        <asp:Parameter Name="datArte" Type="Object" />
        <asp:Parameter Name="datTituloArte" Type="String" />
        <asp:Parameter Name="datFechaHoraPub" Type="DateTime" />
        <asp:Parameter Name="datSitio" Type="String" />
        <asp:Parameter Name="datGrupoPost" Type="Int32" />
        <asp:Parameter Name="datContInteresado" Type="DateTime" />
        <asp:Parameter Name="datCantInteresado" Type="Int32" />
        <asp:Parameter Name="datContramensaje" Type="DateTime" />
        <asp:Parameter Name="datCantRecibidos" Type="Int32" />
        <asp:Parameter Name="datLlamadaFinal" Type="String" />
        <asp:Parameter Name="datCita" Type="DateTime" />
        <asp:Parameter Name="datEstado" Type="String" />
        <asp:Parameter Name="Original_idDato" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>
        </center>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Mantenimiento/Plantilla.Master" AutoEventWireup="true" CodeBehind="reporteVista.aspx.cs" Inherits="WebApp1.Mantenimiento.reporteVista" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div style="width: 1300px">
                <div style="margin-left: 250px">
                    <div class="row">
                        <div class="col-md-auto">
                            <asp:DropDownList ID="drop" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="drop_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-auto">
                            <asp:DropDownList ID="ddl1" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-auto">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" AutoPostBack="true" TextMode="Month" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                        </div>
                        <div >
                        <p>Format</p>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                            <asp:ListItem Text="Word" Value="WORD" Selected="True" />
                            <asp:ListItem Text="Excel" Value="EXCEL" />
                            
                        </asp:RadioButtonList>
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btnNuevo btn-primary"  OnClick="Export" />
                    </div>
                    </div>
                </div>

                <br />

                <center>
                    
                    
                    <br />
                    
                    <div style="height: auto;">
                        <rsweb:ReportViewer  ID="ReportViewer1" runat="server" ShowExportControls="False" ShowBackButton="False" ShowFindControls="False" ShowPageNavigationControls="False" Height="1004px" Width="800px" ShowPrintButton="False" ShowZoomControl="False" ShowRefreshButton="False">
                            <LocalReport ReportPath="Mantenimiento\ReporteDatos.rdlc">
                            </LocalReport>
                        </rsweb:ReportViewer>
                    </div>
                </center>

            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

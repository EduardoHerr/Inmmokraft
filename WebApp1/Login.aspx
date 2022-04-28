<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/login.css" rel="stylesheet" />
    <link
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"
      rel="stylesheet"
    />
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <div class="containeer">
      <div class="center">
        <div class="log">
          <h1>Inicio de Sesión</h1>
          <div class="container">
            <div class="row">
              <div class="col">Usuario:</div>
              <div class="col">
                
                  <asp:TextBox ID="txtCi" runat="server" placeholder="Ingrese su User" CssClass="inp" ></asp:TextBox>
              </div>
            </div>
          </div>
          <br/>
          <div class="container">
            <div class="row">
              <div class="col">Clave:</div>
              <div class="col">
                  <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Ingrese su Contraseña" cssClass="inp" runat="server"></asp:TextBox>
                
              </div>
            </div>
          </div>
          <br/>
          <center>
              
              <asp:Button ID="btnIngreso" runat="server" Text="Ingresar" OnClick="btnIngreso_Click"  CssClass="sub" />
          </center>
            <br />
            <center>
                <asp:Label ID="lblMensaje"  runat="server" Text=""></asp:Label>
            </center>
          <hr/>
          
            <asp:LinkButton ID="linkRecuperar" CssClass="lnk" runat="server" >Recuperar Contraseña...</asp:LinkButton>
        </div>
      </div >
                          
            </div>
                    </div>
    </form>
</body>
</html>

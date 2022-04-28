<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicioAdmin.aspx.cs" Inherits="WebApp1.inicioAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        td {
            padding: 25px 5px;
            background: rgba( 58, 56, 56, 0.25 );
            background: rgba( 0, 0, 0, 0.85 );
            box-shadow: 0 8px 32px 0 rgba( 31, 38, 135, 0.37 );
            backdrop-filter: blur( 3.5px );
            -webkit-backdrop-filter: blur( 3.5px );
            border-radius: 20px;
            border: 1px solid rgba( 255, 255, 255, 0.18 );
        }
            td:hover {
                background: rgba( 194, 191, 191, 0.7 );
                box-shadow: 0 8px 32px 0 rgba( 31, 38, 135, 0.37 );
                backdrop-filter: blur( 4px );
                -webkit-backdrop-filter: blur( 4px );
                border-radius: 10px;
                border: 1px solid rgba( 255, 255, 255, 0.18 );
                
            }
    </style>
    <link href="css/inicioAdmin.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="cspadre">
            <div class="cshijo">

                <table class="auto-style1">
                    <tr>
                        <td><a href="Mantenimiento/PageDatos.aspx"><image src="img/report.png"> </image><center><p>Reportes</p></center> </a> </td>
                        <td><a href="Mantenimiento/vistaAdmin.aspx?tusu=1"><image src="img/admin.png"></image><center><p>Administrador</p></center> </a></td>
                        <td><a href="Mantenimiento/vistaAdmin.aspx?tusu=2"><image src="img/post.png"></image><center><p>Posteador</p></center> </a></td>
                        <td><a href="Mantenimiento/vistaAdmin.aspx?tusu=3"><image src="img/analista.png"></image><center><p>Analista</p></center> </a></td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>

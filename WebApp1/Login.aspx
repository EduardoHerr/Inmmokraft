<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperación Clave</title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" />
    <link rel="icon" href="Mantenimiento/Imagenes/icon.png"/>
</head>

<body>
    <style>
        * {
            font-family: 'Open Sans', sans-serif;
        }

        @media only screen and (max-width: 800px) {
            .grilla {
                width: 600px !important;
                height: 800px !important;
                display: flex;
                flex-direction: column;
            }

            #image {
                border-radius: 15px !important;
            }

            .columna {
                width: 600px;
            }
        }

        body {
            background-color: #EAEDED;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }


        .grilla {
            display: flex;
            border-radius: 15px;
            width: 1100px;
            height: 550px;
            background-color: whitesmoke;
            text-align: center;
            box-shadow: 6px 6px 17px -3px rgba(0, 0, 0, 0.6);
            -webkit-box-shadow: 6px 6px 17px -3px rgba(0, 0, 0, 0.6);
            -moz-box-shadow: 6px 6px 17px -3px rgba(0, 0, 0, 0.6);
        }

        .columna {
            flex: 50%;
        }

        .titulo {
            margin-top: 50px;
            margin-bottom: 50px;
            color: #5DADE2;
            font-weight: bold;
        }

        .txt {
            margin-top: 20px;
            margin-bottom: 10px;
            width: 300px;
            height: 40px;
            border: none;
            border-left: 3px solid #5DADE2;
            border-right: 3px solid #5DADE2;
            outline: none;
            border-radius: 8px;
            padding: 12px 20px;
            text-align:center;
        }

            .txt:focus {
                border-top: 2px solid #5DADE2;
                border-bottom: 2px solid #5DADE2;
            }

        .btn {
            margin-top: 40px;
            width: 150px;
            font-weight: bold;
            box-shadow: 3px 3px 5px -1px rgba(0, 0, 0, 0.75);
            -webkit-box-shadow: 3px 3px 5px -1px rgba(0, 0, 0, 0.75);
            -moz-box-shadow: 3px 3px 5px -1px rgba(0, 0, 0, 0.75);
        }

            .btn:hover {
                background-color: #5DADE2;
                color: white;
            }

        #image {
            border-radius: 15px 0 0 15px;
            width: 100%;
            height: 100%;
        }

        .contenedor2 {
            display: flex;
            justify-content: end;
        }

        a {
            padding: 10px;
            color: #0d69a7;
        }

            a:hover {
                text-decoration: none;
                color: #5DADE2;
            }

            .intro{
                color:dimgray;
                font-style:italic;
                font-size:12px;
            }
    </style>

    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="grilla">
                <div class="columna">
                    <img id="image" src="img/fondo1.png" alt="fondo1" />

                </div>
                <div class="columna">
                    <div class="2columna">
                        <br />
                        <center>
                            <h1 class="titulo">Recuperar Clave</h1>
                        </center>
                        
                        <p class="intro">Por favor ingrese su Cedula de Identidad con la que fue registrado, para continuar con el proceso de Recuperación</p>
                        
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="txt" placeholder="Usuario"></asp:TextBox>
                                                
                        <br />
                        <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" CssClass="btn btn-primary" OnClick="btnRecuperar_Click"  />

                        
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" Text="" ></asp:Label>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>


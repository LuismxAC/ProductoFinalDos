<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro-carnicero.aspx.cs" Inherits="WebProducto.registro_carnicero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
 <script src="js/main.js"></script>
 <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title>Carniceros</title>
</head>
<body>
    <header>
        <nav class="navbar navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand"><strong>Carniceria</strong></a>
            </div>
        </nav>
    </header>
    <body>
    <form id="form1" runat="server">
        
            <div class="container mt-4">
            <div class="row">
                <div class="col">
                </div>
                <div class="col-6 bg-dark p-3" >
                    <nav aria-label="Bienvenido">
                        <ul class="pagination pagination-small mt-3 justify-content-center">
                            <li class="page-item "><a class="page-link" href="index.aspx">Clientes</a></li>
                            <li class="page-item active"><a class="page-link" href="registro-carnicero.aspx">Carniceros</a></l>
                        </ul>
                    </nav>

                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Celular</label>
                    <asp:TextBox runat="server" ID="txtCel" TextMode="Number" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Correo</label>
                    <asp:TextBox runat="server" ID="txtCorreo" TextMode="Email" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="formFile" class="form-label text-white">Experiencia</label>
                    <asp:TextBox runat="server" ID="txtAnios" TextMode="Number" class="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button runat="server" CssClass="btn btn-primary w-100" Text="Registrar" OnClick="Unnamed1_Click"/>
                </div>
                </div>
                <div class="col">
                </div>
            </div>
        
        </div>
    </form>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

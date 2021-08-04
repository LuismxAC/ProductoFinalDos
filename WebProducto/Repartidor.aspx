<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repartidor.aspx.cs" Inherits="WebProducto.Repartidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Repartidor</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
     <header>
        <nav class="navbar navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand"><strong>Carniceria</strong></a>
            </div>
        </nav>
    </header>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4 mb-4">
            <div class="row">
                <div class="col">
                </div>
                <div class="col-6 bg-dark p-3">
                    <nav aria-label="Bienvenido">
                        <ul class="pagination pagination-small mt-3 justify-content-center">
                            
                        </ul>
                    </nav>
                    <div class="mb-3">
                        <label for="formFile" class="form-label text-white">Registrate Repartidor</label>
                    </div>
                    <div class="mb-3">
                        <label for="formFile" class="form-label text-white">Nombre</label>
                        <asp:TextBox class="input" ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                 
                    <div class="mb-3">
                        <label for="formFile" class="form-label text-white">Celular</label>
                        <asp:TextBox ID="txtCelular" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="formFile" class="form-label text-white">Licencia</label>
                        <asp:TextBox class="input" ID="txtlicencia" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    
                    <div class="mb-3">
                        <asp:Button ID="Button1" class="btn btn-primary w-100" runat="server" Text="Registrar" OnClick="Button1_Click" />
                    </div>
                </div>
                <div class="col">
                </div>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesPed.aspx.cs" Inherits="WebProducto.DetallesPed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Productos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="js/main.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
    <header>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
          <div class="container-fluid">
            <a class="navbar-brand" href="#">Carniceria</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
              <ul class="navbar-nav">
                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="Direccion.aspx">Mis ubicaciones</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="InicioCli.aspx">Mis Pedidos</a>
                </li>
                <li class="nav-item dropdown justify-content-end">
                  <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <label id="lbAux" runat="server"></label>
                  </a>
                  <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    <li><a class="dropdown-item" href="Cerrar.aspx">Salir</a></li>
                    <li><a class="dropdown-item" href="#">Mi informacion</a></li>

                  </ul>
                </li>
              </ul>
            </div>
          </div>
        </nav>
    </header>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
  <div class="row justify-content-md-center">
  </div>
  <div class="row">
    <div class="col col-lg-5 p-3">
                <asp:Panel runat="server" ID="Panel1">
                    <label class="form-label">Producto:</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtProducto"></asp:TextBox>
                    <label class="form-label">Peso:</label>
                    <asp:TextBox  CssClass="form-control" runat="server" ID="txtPeso"></asp:TextBox>
                    <label class="form-label">Cantidad:</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtCantidad"></asp:TextBox>
                    <label class="form-label">Nota:</label>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtNota" Rows="4"></asp:TextBox>
                    <br />

        </asp:Panel>
                            <asp:Button Text="Guardar" runat ="server" class="btn btn-primary w-100" ID="btnGuardar" OnClick="btnGuardar_Click"/>
                     <br />
                    <asp:Button runat="server" Text="Ver productos" class="btn btn-primary w-100" ID="btnVer" OnClick="btnVer_Click"/>
                    <br />
        <asp:Button runat="server" class="btn btn-primary w-100" Text="Finalizar" ID="btnFin" OnClick="Button1_Click"/>
        <asp:Button runat="server" class="btn btn-primary w-100" Text="Mostrar detalles" ID="btnDetails" OnClick="Button2_Click"/>
    </div>
    <div class="col col-lg-7 p-3 ">
         <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
                <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </div>
  </div>
</div>
                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    </form>
</body>
</html>

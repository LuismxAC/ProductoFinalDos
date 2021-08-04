<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Direccion.aspx.cs" Inherits="WebProducto.Direccion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Ubicaci&oacute;n</title>
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
        <label class="form-label">Colonia</label>
        <asp:TextBox class="form-control" ID="txtCol" runat="server"></asp:TextBox>
        <label class="form-label">Calle y n&uacute;mero</label>
        <asp:TextBox class="form-control" ID="txtCayNu" runat="server"></asp:TextBox>
        <label class="form-label">Municipio</label>
        <asp:TextBox class="form-control" ID="txtMuni" runat="server"></asp:TextBox>
        <label class="form-label">Ciudad</label>
        <asp:TextBox class="form-control" ID="txtCiud" runat="server"></asp:TextBox>
        <label class="form-label">Referencia</label>
        <asp:TextBox class="form-control" ID="txtRef" runat="server"></asp:TextBox>
        <label class="form-label">Caracteristica</label>
        <asp:TextBox class="form-control" ID="txtCar" runat="server"></asp:TextBox>
        <label class="form-label">CP</label>
        <asp:TextBox class="form-control" ID="txtCp" runat="server"></asp:TextBox>
        <br />
        <asp:Button runat="server" class="btn btn-primary w-100" ID="btnGuardarU" Text="Guardar" OnClick="btnGuardarU_Click"/>
    </div>
       <div class="col col-lg-7 p-3 ">
                <asp:Button runat="server" ID="btnCargar"  class="btn btn-primary mb-2" Text="Ver mis ubicaciones" OnClick="btnCargar_Click"/>
        <asp:GridView ID="gvUbi" runat="server" class="bg-light m-1" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="gvUbi_SelectedIndexChanged">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </div>
  </div>
</div>
                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    </form>
</body>
</html>

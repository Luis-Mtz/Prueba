<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EdicionUrl.aspx.cs" Inherits="EdicionUrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
      <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 100px">
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-1">
            </div>
            <div class="col-sm-10">
                <div class="row">
                    <div style="margin: auto">
                        <asp:Image ID="imgFoto" runat="server" />
                        <asp:FileUpload ID="fuFoto" runat="server" />
                        <div class="col-xs-6">
                            <asp:DropDownList ID="ddlMarca"  runat="server" AutoPostBack="true"
                                onselectedindexchanged="ddlMarca_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlModelo" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-6">
                           <asp:DropDownList ID="ddlCategoria" runat="server">
                            </asp:DropDownList>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox ID="txtExistencia" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            <asp:Label ID="lblCosto" runat="server" Text="Label"></asp:Label>
                          
                        </div>
                        <div class="col-xs-6">
                            <asp:CheckBox ID="chkEstatus" runat="server" />
                        </div>
                        
                        <div class="col-xs-12">
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                                onclick="btnActualizar_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-1">
            </div>
        </div>
    </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

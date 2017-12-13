<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryDinamico.aspx.cs" Inherits="QueryDinamico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
      <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
        <asp:Button ID="btnEntrar" runat="server" Text="Button" OnClick="btnEntrar_Click" />

    </div>
    </form>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

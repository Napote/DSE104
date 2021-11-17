<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UsandoEstadoDeSesion.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server"
                Text="Escriba la variable de sesion:" />
            <asp:TextBox ID="TextBox1" runat="server" /><br /> <br />
             <asp:Label ID="Label2" runat="server"
                Text="Escriba la variable de aplicacion:" />
            <asp:TextBox ID="TextBox2" runat="server" />
            <br /><br />
            <asp:Button ID="Button1" runat="server"
                Text="Enviar" onclick="Button1_Click" />
        </div>
    </form>
</body>
</html>

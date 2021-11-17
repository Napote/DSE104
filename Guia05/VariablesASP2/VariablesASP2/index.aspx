<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="VariablesASP2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Session:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbSession" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click"/>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Application:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbApplicacion" runat="server" style="margin-left: 0px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Guardar" OnClick="Button2_Click"/>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Variable Session actual:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="varSession" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Variable Application actual:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="varApplication" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button3" runat="server" Text="Actualizar" OnClick="Button3_Click"/>
            </p>
        </div>
    </form>
</body>
</html>

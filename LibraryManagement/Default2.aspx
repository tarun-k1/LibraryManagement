<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Login Page</td>
                </tr>
                <tr>
                    <td>Enter name:</td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Enter email:</td>
                    <td><asp:TextBox TextMode="Email" ID="TextBox2" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click1" /></td>
                    <td><asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </table>
        </div>
    </form>
</body>
</html>

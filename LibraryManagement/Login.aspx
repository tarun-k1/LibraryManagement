<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Default3" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Library management system</h1>
        <table>
            
            <tr>
                <td>Enter name: </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>            
            </tr>
            <tr>
                <td>Enter email: </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>            
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                    
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
                 
          
        </table>    
        </div>
    </form>
</body>
</html>

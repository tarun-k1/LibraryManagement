<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Book Title"></asp:Label>
                    </td>
                    <td><asp:TextBox ID="bookname" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="Label3" runat="server" Text="Author Name"></asp:Label>
                    </td>
                    <td><asp:TextBox ID="author" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                    <asp:Button ID="add" runat="server" Text="ADD" OnClick="add_Click" /></td>
                    <td>
                    <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/></td>
                      <td>
                    <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                          <asp:Label ID="Label4" runat="server" Text="Enter Id for update:"></asp:Label>
                        <asp:TextBox ID="updateId" runat="server" ></asp:TextBox></td>
                  
                </tr>

            </table>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-right:0px; float:left"><h1>User Home</h1></div>
            <div style="float:right">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Home</asp:HyperLink>
            </div>
        </div>      
                
        
        <div style="padding-top:50px;">
           
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="16px" style="margin-left: 0px" Width="660px">
                <asp:ListItem Value="myBook">My Books</asp:ListItem>
                <asp:ListItem Value="issue">Issue New Book</asp:ListItem>
                <asp:ListItem Value="return">Return Book</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click1" style="height: 35px"></asp:Button>
            <asp:Label ID="Label1" runat="server" style="margin-left:50px;height: 35px" Text="Label" Visible="False"></asp:Label>
           
        </div>
        <div style="padding-top:30px;">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
             <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Button" Visible="false" OnClick="Button2_Click"/></div>
        </div>
        <div>
           
    </form>
</body>
</html>

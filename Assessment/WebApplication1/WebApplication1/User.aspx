<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebApplication1.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightyellow">
    <form id="form1" runat="server">
        <div >
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Home" />
            <br />
            <br />
            <br />
            <br />
            <br />

            <asp:GridView ID="GVEmployee" runat="server" AllowCustomPaging="True" 
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" style="background-color:lightcyan" ShowHeaderWhenEmpty="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="287px" Width="705px" PageSize="20">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="InvoiceNumber" HeaderText="InvoiceNumber"/>
                <asp:BoundField DataField="InvoiceAmount" HeaderText="InvoiceAmount"/>
                <asp:BoundField DataField="PurchaseOrderNumber" HeaderText="PurchaseOrderNumber"/>
                <asp:BoundField DataField="InvoiceType" HeaderText="InvoiceType"/>
                <asp:BoundField DataField="Company" HeaderText="Company"/>  
            </Columns>
            
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            
            </asp:GridView>
        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export"/>
        
        </div>
    </form>
</body>
</html>

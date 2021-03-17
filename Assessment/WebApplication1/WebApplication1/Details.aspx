<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebApplication1.Details" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GVEmployee1" runat="server" HorizontalAlign="Center"
                AutoGenerateColumns="False" AllowPaging="True"  OnPageIndexChanging="GVEmployee_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="836px">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
              
                <asp:BoundField DataField="Name" HeaderText="Name"/>
                <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                <asp:BoundField DataField="Country" HeaderText="Country"/>
                <asp:BoundField DataField="Salary" HeaderText="Salary"/>  
                <asp:BoundField DataField="Email" HeaderText="Email"/> 
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
        </div>
        
    </form>
</body>
</html>

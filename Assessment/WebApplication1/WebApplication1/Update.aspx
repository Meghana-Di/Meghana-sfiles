<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="WebApplication1.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Addition of Invoice Details</title>
</head>
<body style="background-color:lightblue">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Home" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GVAddition" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="ID" HorizontalAlign="Center"

                OnRowCommand="GVAddition_RowCommand"
                OnRowEditing="GVAddition_RowEditing"
                OnRowCancelingEdit="GVAddition_RowCancelingEdit"
                OnRowUpdating="GVAddition_RowUpdating"
                OnRowDeleting="GVAddition_RowDeleting"
                AutoGenerateColumns="false" ShowFooter="true" Height="165px" Width="661px">
                <%-- Theme Properties --%>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <Columns>
                <asp:TemplateField HeaderText="InvoiceNumber">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("InvoiceNumber") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtInvoiceNumber" Text='<%# Eval("InvoiceNumber") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtInvoiceNumberFooter" Text='<%# Eval("InvoiceNumber") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="InvoiceAmount">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("InvoiceAmount") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtInvoiceAmount" Text='<%# Eval("InvoiceAmount") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtInvoiceAmountFooter" Text='<%# Eval("InvoiceAmount") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="PurchaseOrderNumber">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("PurchaseOrderNumber") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtPurchaseOrderNumber" Text='<%# Eval("PurchaseOrderNumber") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtPurchaseOrderNumberFooter" Text='<%# Eval("PurchaseOrderNumber") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="InvoiceType">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("InvoiceType") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtInvoiceType" Text='<%# Eval("InvoiceType") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtInvoiceTypeFooter" Text='<%# Eval("InvoiceType") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                      <asp:TemplateField HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Company") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtCompany" Text='<%# Eval("Company") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtCompanyFooter" Text='<%# Eval("Company") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Country") %>' runat="server"/></ItemTemplate>
                       <EditItemTemplate>
                           <asp:TextBox ID="txtCountry" Text='<%# Eval("Country") %>' runat="server"/>
                       </EditItemTemplate>
                        <FooterTemplate>
                           <asp:TextBox ID="txtCountryFooter" Text='<%# Eval("Country") %>' runat="server"/>
                        </FooterTemplate>
                </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Image/Edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20" />
                        <asp:ImageButton ImageUrl="~/Image/Delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20" />
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Image/Save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20" />
                        <asp:ImageButton ImageUrl="~/Image/Cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20" />
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Image/Add.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="LblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="LblErrorMessage" Text="" runat="server" ForeColor="Red"/>
        </div>
    </form>
</body>
</html>

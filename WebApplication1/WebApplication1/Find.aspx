<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Find.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db1ConnectionString %>" ProviderName="<%$ ConnectionStrings:db1ConnectionString.ProviderName %>" SelectCommand="SELECT [NameGood], [Describtion], [Quantity], [Price], [IDtype], [IDdealer], [IdGood] FROM [Goods]"></asp:SqlDataSource>
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Поиск" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="IdGood" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="NameGood" HeaderText="Название" SortExpression="NameGood" />
        <asp:BoundField DataField="Describtion" HeaderText="Описание" SortExpression="Describtion" />
        <asp:BoundField DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" />
        <asp:BoundField DataField="Price" HeaderText="Цена" SortExpression="Price" />
    </Columns>
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F8FAFA" />
    <SortedAscendingHeaderStyle BackColor="#246B61" />
    <SortedDescendingCellStyle BackColor="#D4DFE1" />
    <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
</asp:Content>


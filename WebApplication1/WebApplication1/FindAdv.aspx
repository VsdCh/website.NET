<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindAdv.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder1">
    Фильтр производителя<br />
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceZapros2" DataTextField="Organization" DataValueField="Organization" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="236px">
    </asp:DropDownList>
    <asp:CheckBox ID="CheckBox1" runat="server" Text="Не учитывать" />
    <asp:SqlDataSource ID="SqlDataSourceZapros2" runat="server" ConnectionString="<%$ ConnectionStrings:db1ConnectionStringZapros2 %>" ProviderName="<%$ ConnectionStrings:db1ConnectionStringZapros2.ProviderName %>" SelectCommand="SELECT DISTINCT [Organization] FROM [Запрос1]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceZapros" runat="server" ConnectionString="<%$ ConnectionStrings:db1ConnectionStringZapros %>" ProviderName="<%$ ConnectionStrings:db1ConnectionStringZapros.ProviderName %>" SelectCommand="SELECT DISTINCT [TypeDescr] FROM [Запрос1]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:db1ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:db1ConnectionString2.ProviderName %>" SelectCommand="SELECT [TypeDescr], [Organization], [Price], [Quantity], [Describtion], [NameGood] FROM [Запрос1]"></asp:SqlDataSource>
    <br />
    Фильтр категории товара<br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceZapros" DataTextField="TypeDescr" DataValueField="TypeDescr">
    </asp:DropDownList>
    <asp:CheckBox ID="CheckBox2" runat="server" Text="Не учитывать" />
    <br />
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Поиск" />
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="TypeDescr" HeaderText="Вид" SortExpression="TypeDescr" />
        <asp:BoundField DataField="Organization" HeaderText="Производитель" SortExpression="Organization" />
        <asp:BoundField DataField="Price" HeaderText="Цена" SortExpression="Price" />
        <asp:BoundField DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" AccessibleHeaderText="True" />
        <asp:BoundField DataField="Describtion" HeaderText="Описание" SortExpression="Describtion" />
        <asp:BoundField DataField="NameGood" HeaderText="Название товара" SortExpression="NameGood" />
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


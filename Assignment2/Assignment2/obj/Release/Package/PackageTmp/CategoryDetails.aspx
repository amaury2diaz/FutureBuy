<%@ Page Title="Category Details" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="Assignment2.CategoryDetails" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView ID="cProductsGridView" runat="server" AutoGenerateColumns="false" ShowHeader="false"> 
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="image" runat="server" ImageUrl='<%# "~/FileHandler.ashx?fileid=" + Eval("ProductId") %>' Width="300" /><br />
                    Name: <asp:HyperLink ID="productLink" runat="server" NavigateUrl='<%#"~/ProductDetails.aspx?productId="+ Eval("ProductId")  %>' Text='<%# Eval("Name") %>' />
                    Price: <%# Eval("Price") %>
                    Sale Price: <%# Eval("SalePrice") %><br />
                    Description: <%# Eval("ShortDescription") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no products to display</EmptyDataTemplate> 
        <PagerStyle HorizontalAlign="Center" BackColor="#B005B2" ForeColor="White" Height="50px" Font-Size="25px"/>
    </asp:GridView>
</asp:Content>

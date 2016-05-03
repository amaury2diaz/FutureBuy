<%@ Page Title="Default Admin" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment2.Admin.Default" Theme="General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Categories</h1>
    <asp:GridView ID="categoriesGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Edit Category</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="editButton" runat="server" Text="Edit" OnClick="editButton_Click" CommandArgument='<%# Eval("Id") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Delete Category</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="deleteButton" runat="server" Text="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="deleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this category?')" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Category Name</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no blogs to display</EmptyDataTemplate> 
    </asp:GridView>
    <h1>Products</h1>
    <asp:GridView ID="productsGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Edit Product</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Button ID="editpButton" runat="server" Text="Edit" OnClick="editpButton_Click" CommandArgument='<%# Eval("ProductId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Delete Product</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="deletepButton" runat="server" Text="Delete" CommandArgument='<%# Eval("ProductId") %>' OnClick="deletepButton_Click" OnClientClick="return confirm('Are you sure you want to delete this Product?')" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Product Name</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Short Description</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("ShortDescription") %>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField>
                <HeaderTemplate>
                    <b>Price</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Price") %>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>Currently there are no blogs to display</EmptyDataTemplate> 
    </asp:GridView>
</asp:Content>

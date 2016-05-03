<%@ Page Title="Cart" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Assignment2.Cart" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="cartGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true" OnRowDataBound="cartGridView_RowDataBound" SkinID="cart"> 
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Remove Product</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="deleteButton" runat="server" Text="Remove" CommandArgument='<%# Eval("Product.ProductId") %>' OnClick="deleteButton_Click" OnClientClick="return confirm('Are you sure you want to remove this product from cart?')" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <h6>Product Name</h6>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Product.Name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <h6>Product Picture</h6>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="image" runat="server" ImageUrl='<%# "~/FileHandler.ashx?fileid=" + Eval("Product.ProductId") %>' Width="300" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <h6>Product Price</h6>
                </HeaderTemplate>
                <ItemTemplate>
                   <p id="actualPrice" runat="server"> <%# ((bool)Eval("Product.IsOnSale")) ? Eval("Product.SalePrice") : Eval("Product.Price") %></p>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <h6>Short Description</h6>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Product.ShortDescription") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <h6>Quantity</h6>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="quantity" runat="server" Text='<%# Eval("amount") %>' Width="30"/>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField>
                <HeaderTemplate>
                    <b>Add a product</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="addButton" runat="server" Text="Add" CommandArgument='<%# Eval("Product.ProductId") %>' OnClick="addButton_Click" OnClientClick="return confirm('Are you sure you want to add one extra item to cart?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no products to display</EmptyDataTemplate> 
        <PagerStyle HorizontalAlign="Center" BackColor="#B005B2" ForeColor="White" Height="50px" Font-Size="25px"/>
    </asp:GridView>
    <table>
        <tr>
            <td><h4>Total: </h4></td>
            <td><asp:Label ID="totalPriceL" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="X-Large"/></td>
            <td><h4 style="color:red;">$</h4></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="buyNow" runat="server" Text="Buy Now" OnClick="buyNow_Click"/>
    <asp:Button ID="contShopping" runat="server" Text="Continue Shopping" OnClick="contShopping_Click"/>
</asp:Content>

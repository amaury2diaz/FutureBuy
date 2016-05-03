<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Assignment2.ProductDetails" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:Label ID="added" runat="server" Visible="false" Text="You cannot add more than one item of the same category to cart"/><br />
    <table>
        <tr>
            <td><h1>Product Name: </h1></td>
            <td><h1 id="pName" runat="server"></h1></td>
        </tr>
        <tr>
            <td><h1>Picture: </h1></td>
            <td><asp:Image ID="image" runat="server" Width="300" /></td>
        </tr>
        <tr>
            <td><h2>Price:</h2></td>
            <td><h2 id="pPrice" runat="server"></h2></td>
        </tr>
        <tr>
            <td><h3>Short Description: </h3></td>
            <td><h3 id="pSDescription" runat="server"></h3></td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="addToCartButton" runat="server" OnClick="addToCartButton_Click" Text="Add to Cart" />
    <br />

    <ajaxToolkit:TabContainer ID="tabs" runat="server">
        <ajaxToolkit:TabPanel ID="LongDescription" runat="server" HeaderText="Description">
            <ContentTemplate>
                <asp:Label id="pLongDescription" runat="server" />
            </ContentTemplate>
            </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="comments" runat="server" HeaderText="Comments">
            <ContentTemplate>
                <asp:Label ID="commentLabel" runat="server" Font-Size="Large">Comments: </asp:Label><br />
    <asp:TextBox
        ID="commentBox"
        runat="server"
        TextMode="MultiLine"
        Width="500" /><br />
    <asp:Button ID="submitButton" runat="server" Text="Submit Comment" OnClick="submitButton_Click" /><br />

    <asp:GridView ID="commentGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Author</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <p><%# Eval("FName") %> <%# Eval("LName") %></p>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Published</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Published") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Content</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Content") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no comments to display</EmptyDataTemplate>
    </asp:GridView>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
</asp:Content>

<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment2.Default" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 runat="server" id="welcomeHeader" style="color:#B005B2" >Welcome To the Craziest Store Ever</h1>
    <asp:GridView ID="storeGridView" runat="server" AutoGenerateColumns="false" ShowHeader="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="storeGridView_PageIndexChanging"> 
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="image" runat="server" ImageUrl='<%# "~/FileHandler.ashx?fileid=" + Eval("ProductId") %>' Width="300" /><br />
                     Name:  <b><%# Eval("Name") %></b><br />
                     Price: <b style="color:red; text-decoration:line-through;"><%# Eval("Price") %></b>
                     Sale Price: <b style="color:green;"><%# Eval("SalePrice") %></b><br />
                     Description: <b><%# Eval("ShortDescription") %></b>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no products to display</EmptyDataTemplate> 
        <PagerStyle HorizontalAlign="Center" BackColor="#B005B2" ForeColor="White" Height="50px" Font-Size="25px"/>
    </asp:GridView>
</asp:Content>

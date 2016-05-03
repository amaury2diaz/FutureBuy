<%@ Page Title="Add Category" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Assignment2.Admin.AddCategory" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
      <asp:GridView ID="categoryGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Edit Category</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="editButton" runat="server" Text="Edit" CommandArgument='<%# Eval("Id") %>' OnClick="editButton_Click" CausesValidation="false" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Categories</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Name") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no categories to display</EmptyDataTemplate> 
    </asp:GridView>
    <asp:TextBox ID="addBox" runat="server" />
     <asp:RequiredFieldValidator id="requiredaddition"
                    ControlToValidate="addBox"
                    Display="None"
                    runat="server"
                    ErrorMessage="Required Category"/>
    <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredaddition"  ID="vReq"/>
    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click"/>
</asp:Content>

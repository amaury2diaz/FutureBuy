<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="Assignment2.Admin.EditCategory" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="addBox" runat="server" />
     <asp:RequiredFieldValidator id="requiredaddition"
                    ControlToValidate="addBox"
                    Display="Static"
                    runat="server">*</asp:RequiredFieldValidator>
    <asp:Button ID="editButton" runat="server" Text="Edit" OnClick="editButton_Click"/>
</asp:Content>

<%@ Page Title="Bad Words" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="BadWords.aspx.cs" Inherits="Assignment2.Admin.BadWords" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
     <asp:GridView ID="bwGridView" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Delete Word</b>
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Button ID="deleteButton" runat="server" Text="Delete" CommandArgument='<%# Eval("BadWordId") %>' OnClick="deleteButton_Click" OnClientClick="return confirm('Are you sure?')" />
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <b>Bad Words</b>
                </HeaderTemplate>
                <ItemTemplate>
                    <%# Eval("Word") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>Currently there are no words to display</EmptyDataTemplate> 
    </asp:GridView>
    <asp:TextBox ID="addBox" runat="server" />
     <asp:RequiredFieldValidator id="requiredaddition"
                    ControlToValidate="addBox"
                    Display="None"
                    runat="server"
                    ErrorMessage="Required Category"/>
    <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredaddition"  ID="vReq"/>
    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
</asp:Content>

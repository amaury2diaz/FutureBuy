<%@ Page Title="Thank You" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="Assignment2.ThankYou" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Thank You for buying in Awful Domino 2 store your items will be deliverd shortly</h3>
    <br />
    <br />
    <br />
     <asp:Button ID="home" runat ="server" OnClick="home_Click" Text="Go Home" />
</asp:Content>

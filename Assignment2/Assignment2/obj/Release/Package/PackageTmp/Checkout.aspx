<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Assignment2.Checkout" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="manager2" />
    <table>
        <tr>
            <td><asp:Label ID="nameLabel" runat="server" Text="Name: " /></td>
            <td><asp:TextBox ID="nameBox" runat="server" /></td>
            <asp:RequiredFieldValidator ID="requirednameBox"
                ControlToValidate="nameBox"
                Display="None"
                runat="server"
                ErrorMessage="Required Credit Card Name" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requirednameBox" ID="vNBReq" />
        </tr>
        <tr>
            <td><asp:Label ID="numberLabel" runat="server" Text="Credit Card Number: " /></td>
            <td><asp:TextBox ID="numberBox" runat="server" /></td>
            <asp:RequiredFieldValidator ID="requiredNumberBox"
                ControlToValidate="numberBox"
                Display="None"
                runat="server"
                ErrorMessage="Required Credit Card Number" />
            <asp:RegularExpressionValidator id="regexNumberBox" 
                     ControlToValidate="numberBox"
                     ValidationExpression="\d{9,9}"
                     Display="None"
                     ErrorMessage="Invalid credit card number (format = 111222333)" 
                     runat="server"/>
            <ajaxToolkit:FilteredTextBoxExtender runat="server" TargetControlID="numberBox" FilterType="Numbers"/>
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredNumberBox" ID="vNUBReq" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="regexNumberBox"  ID="vNUBReg"/>
        </tr>
        <tr>
            <td><asp:Label ID="expirationDate" runat="server" Text="Expiration Date: " /></td>
            <td><asp:TextBox ID="expirationBox" runat="server"/></td>
            <ajaxToolkit:CalendarExtender runat="server" TargetControlID="expirationBox" Format="MMMM d, yyyy" PopupPosition="Right"/>
            <asp:RequiredFieldValidator ID="requiredEDate"
                ControlToValidate="expirationBox"
                Display="None"
                runat="server"
                ErrorMessage="Required Expiration Date" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredEDate" ID="vEDReq" />
        </tr>
        <tr><td><asp:Label ID="payLabel" runat="server" Text="Total To Pay: " /></td>
            <td><asp:Label ID="totalAmount" runat="server" ForeColor="Red" Font-Bold="true"/>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="proceed" runat="server" OnClick="proceed_Click" Text="Proceed" />
    <asp:Button ID="cancel" runat ="server" OnClick="cancel_Click" Text="Cancel" />
</asp:Content>

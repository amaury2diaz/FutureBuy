<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Assignment2.Admin.AddProduct" Theme="General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="manager" />
    <table>
        <tr>
            <td>
                <asp:Label ID="ddLabel" runat="server" Text="Category: " /></td>
            <td>
                <asp:DropDownList ID="categoryList" runat="server" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="nLabel" runat="server" Text="Product Name: " /></td>
            <td>
                <asp:TextBox ID="pName" runat="server" /></td>
            <asp:RequiredFieldValidator ID="requiredPName"
                ControlToValidate="pName"
                Display="None"
                runat="server"
                ErrorMessage="Required Product Name" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredPName" ID="vPNReq" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="sdLabel" runat="server" Text="Short Description: " /></td>
            <td>
                <asp:TextBox ID="pSDescription" runat="server" TextMode="MultiLine" Height="200" Width="400" /></td>

            <asp:RequiredFieldValidator ID="requiredPSDescription"
                ControlToValidate="pSDescription"
                Display="None"
                runat="server"
                ErrorMessage="Required Short Description" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredPSDescription" ID="vPSDReq" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="ldLabel" runat="server" Text="Long Description: " /></td>
            <td>
                <asp:TextBox ID="pLDescription" runat="server" TextMode="MultiLine" Height="500" Width="400" />
                <ajaxToolkit:HtmlEditorExtender ID="ldHTMLEdit" runat="server" TargetControlID="plDescription" EnableSanitization="false" />
            </td>
            <asp:RequiredFieldValidator ID="requiredPLDescription"
                ControlToValidate="pLDescription"
                Display="None"
                runat="server"
                ErrorMessage="Required Long Description" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredPLDescription" ID="vPLDReq" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="priceLabel" runat="server" Text="Product price: " /></td>
            <td>
                <asp:TextBox ID="pPrice" runat="server" /></td>
            <asp:RequiredFieldValidator ID="requiredPPrice"
                ControlToValidate="pPrice"
                Display="None"
                runat="server"
                ErrorMessage="Required Regular Price" />
            <asp:RegularExpressionValidator ID="regexPPrice"
                ControlToValidate="pPrice"
                Display="None"
                runat="server"
                ErrorMessage="Must be a positive decimal number"
                ValidationExpression="(0|[1-9](([0-9])*))(.([0-9])*)?" />
            <ajaxToolkit:FilteredTextBoxExtender runat="server" TargetControlID="pPrice" FilterType="Custom" ValidChars="1234567890."/>
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredPPrice" ID="vPPReq" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="regexPPrice" ID="vPPReg" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="saleLabel" runat="server" Text="Product sale price: " /></td>
            <td>
                <asp:TextBox ID="pSPrice" runat="server" /></td>
            <asp:RequiredFieldValidator ID="requiredPSPrice"
                ControlToValidate="pSPrice"
                Display="None"
                runat="server"
                ErrorMessage="Required Sale Price" />
            <asp:CompareValidator
                ID="ComparePrices"
                ControlToValidate="pSPrice"
                ControlToCompare="pPrice"
                Display="Dynamic"
                ErrorMessage="Sale price must be smaller than Regular Price"
                Operator="LessThan"
                Type="Double"
                runat="Server" />
            <asp:RegularExpressionValidator ID="regexPSPrice"
                ControlToValidate="pSPrice"
                Display="None"
                runat="server"
                ErrorMessage="Must be a positive decimal number"
                ValidationExpression="(0|[1-9](([0-9])*))(.([0-9])*)?" />
            <ajaxToolkit:FilteredTextBoxExtender runat="server" TargetControlID="pSPrice" FilterType="Custom" ValidChars="1234567890."/>
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="requiredPSPrice" ID="vPSPReq" />
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="comparePrices" ID="vCPComp"/>
            <ajaxToolkit:ValidatorCalloutExtender runat="server" TargetControlID="regexPSPrice" ID="vPSPReg" />
        </tr>
        <tr>
            <td>
                <asp:Label ID="isSaleLabel" runat="server" Text="Is on sale: " /></td>
            <td>
                <asp:RadioButton ID="yes" Text="Yes" Checked="True" GroupName="Available" runat="server" />
                <br />
                <asp:RadioButton ID="no" Text="No" Checked="True" GroupName="Available" runat="server" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="imageLabel" runat="server" Text="Select Image" /></td>
            <td>
                <asp:FileUpload ID="pImage" runat="server" /></td>
            <td>
                <asp:Label ID="notUploadedError" runat="server" ForeColor="Red" Font-Bold="true" /></td>
        </tr>
    </table>

    <br />
    <br />

    <asp:Button ID="createProductButton" runat="server" Text="Create Product" OnClick="createProductButton_Click" />
</asp:Content>

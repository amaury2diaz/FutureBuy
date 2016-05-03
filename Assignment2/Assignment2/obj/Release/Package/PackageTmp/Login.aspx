<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment2.Login" Theme="General"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login id="Login1" runat="server"  
                RememberMeSet="true"
                CreateUserUrl="Register.aspx" 
                OnAuthenticate="OnAuthenticate"
                DestinationPageUrl="~/Default.aspx" >
                <LayoutTemplate>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td colspan="2" style="background-color:black; text-align:center;"><b style="color:white;">Log In</b></td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Algonquin Username:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="adminPass" runat="server" Font-Bold="true">Admin Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="APassword" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </LayoutTemplate>
            </asp:Login>
</asp:Content>

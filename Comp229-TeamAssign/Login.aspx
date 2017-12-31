<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comp229_TeamAssign.Login" %>
<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="LoginPanel" runat="server" CssClass="register-panel">
    <div class="register-panel-title">
        <asp:Label Text="Login" runat="server" />
    </div>
    <div class="register-input-container">
                    <div class="col-sm-7">
                        <asp:TextBox ID="EmailLoginTextBox"
                            ToolTip="Enter your email here"
                            TextMode="SingleLine"
                            CssClass="register-input"
                            runat="server"
                            placeholder="Email" />
                    </div>
        
                    <div class="col-sm-7">
                        <asp:TextBox ID="PasswordLoginTextBox"
                            ToolTip="Enter your password here"
                            TextMode="SingleLine"
                            CssClass="register-input"
                            runat="server"
                            placeholder="Password" />
                    </div>
            <%--<div class="col-sm-12 register-input-container" style="height: 50px;">
                <asp:Button ID="LoginButton"
                    Text="Login"
                    CssClass="login-input-button"
                    OnClick="LoginrButton_Click"
                    ValidationGroup="RegistrationValidationGroup"
                    runat="server" />
            </div>--%>
        </div>
        </asp:Panel>
</asp:Content>

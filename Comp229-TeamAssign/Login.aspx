<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Comp229_TeamAssign.Login" %>

<asp:Content ID="LoginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12">
        <div class="col-sm-3">&nbsp</div>
        <div class="col-sm-6 register-input-container">
            <div class="col-sm-12 register-panel-title">
                <asp:Label ID="TitleLabel" Text="Login" runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="EmailLoginTextBox"
                    ToolTip="Enter your email here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Email" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="PasswordLoginTextBox"
                    ToolTip="Enter your password here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Password" />
            </div>
            <div class="col-sm-12 register-button-container">
                <div class="col-sm-6">
                    <asp:Button ID="LoginButon" Text="Login" CssClass="ub-book-button" runat="server" />
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="ub-book-button" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-sm-3">&nbsp</div>

    </div>
</asp:Content>

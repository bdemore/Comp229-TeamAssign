<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Comp229_TeamAssign.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12">
        <div class="col-sm-3">&nbsp</div>
        <div class="col-sm-6 register-input-container">
            <div class="col-sm-12 register-panel-title">
                <asp:Label ID="TitleLabel" Text="Registration Form" runat="server" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="FirstNameTextBox"
                    ToolTip="Enter your first name here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="First Name" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="LastNameTextBox"
                    ToolTip="Enter your last name here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Last Name" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="EmailTextBox"
                    ToolTip="Enter your email here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Email" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="PasswordTextBox"
                    ToolTip="Enter a password here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Password" />
            </div>
            <div class="col-sm-12">
                <asp:TextBox ID="ConfirmPasswordTextBox"
                    ToolTip="Confirm your password here"
                    TextMode="SingleLine"
                    CssClass="register-input"
                    runat="server"
                    placeholder="Confirm Password" />
            </div>
            <div class="col-sm-12 register-button-container">
                <div class="col-sm-6">
                    <asp:Button ID="RegisterButton" Text="Register" CssClass="ub-book-button" runat="server" />
                </div>
                <div class="col-sm-6">
                    <asp:Button ID="CancelButton" Text="Cancel" CssClass="ub-book-button" runat="server" />
                </div>
            </div>
        </div>
        <div class="col-sm-3">&nbsp</div>

        <%--  Validation for inputs --%>
        <%--<div class="col-sm-7 register-validator-message-container">
                        <asp:RequiredFieldValidator ID="FirstNameZoneTextBox_RFV"
                            ControlToValidate="FirstNameZoneTextBox"
                            Display="Dynamic"
                            ErrorMessage="First Name is required"
                            CssClass="register-input-error"
                            ValidationGroup="RegistrationValidationGroup"
                            runat="server" />
                    </div>
                    <div class="col-sm-7 register-validator-message-container">
                        <asp:RequiredFieldValidator ID="LastNameZoneTextBox_RFV"
                            ControlToValidate="LastNameZoneTextBox"
                            Display="Dynamic"
                            ErrorMessage="Last Name is required"
                            CssClass="register-input-error"
                            ValidationGroup="RegistrationValidationGroup"
                            runat="server" />
                    </div>
                    <div class="col-sm-7 register-validator-message-container">
                        <asp:RequiredFieldValidator ID="EmailZoneTextBox_RFV"
                            ControlToValidate="EmailZoneTextBox"
                            Display="Dynamic"
                            ErrorMessage="Email is required"
                            CssClass="register-input-error"
                            ValidationGroup="RegistrationValidationGroup"
                            runat="server" />
                    </div>
                    <div class="col-sm-7 register-validator-message-container">
                        <asp:RequiredFieldValidator ID="PasswordZoneTextBox_RFV"
                            ControlToValidate="PasswordZoneTextBox"
                            Display="Dynamic"
                            ErrorMessage="Passord is required"
                            CssClass="register-input-error"
                            ValidationGroup="RegistrationValidationGroup"
                            runat="server" />
                    </div>
                    <div class="col-sm-7 register-validator-message-container">
                        <asp:RequiredFieldValidator ID="ConfirmPasswordZoneTextBox_RFV"
                            ControlToValidate="ConfirmPasswordZoneTextBox"
                            Display="Dynamic"
                            ErrorMessage="Confirm Password is required"
                            CssClass="register-input-error"
                            ValidationGroup="RegistrationValidationGroup"
                            runat="server" />
                    </div>--%>
    </div>
    <%--<div class="col-sm-12 register-input-container" style="height: 50px;">
                <asp:Button ID="RegisterButton"
                    Text="Register"
                    CssClass="register-input-button"
                    OnClick="RegisterButton_Click"
                    ValidationGroup="RegistrationValidationGroup"
                    runat="server" />
        </div>
        <div class="col-sm-12 register-input-container" style="height: 50px;">
                <asp:Button ID="ClearButton"
                    Text="Clear"
                    CssClass="register-input-button"
                    OnClick="ClearPageTextBoxes"
                    ValidationGroup="RegistrationValidationGroup"
                    runat="server" />
        </div>--%>
</asp:Content>

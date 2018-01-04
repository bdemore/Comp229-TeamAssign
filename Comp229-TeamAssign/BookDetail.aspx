<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="Comp229_TeamAssign.BookDetail" %>

<asp:Content ID="BookDetailContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Error Panel --%>
    <asp:Panel ID="ErrorPanel" runat="server" CssClass="register-error-message-hidden">
        <div><%= message %></div>
    </asp:Panel>

    <div class="col-sm-12">
        <div class="book-image-container col-sm-6">
            Image
        </div>
        <div class="book-detail-container col-sm-6">
            <div>
                Title: <%= book.Title %>
            </div>
            <div>
                Authors: <%= book.Authors %>
            </div>
            <div>
                Category: <%= book.Categories %>
            </div>
            <div>
                Description <%= book.Description %>
            </div>
            <div>
                Publication Date: <%= book.PublicationDate %>
            </div>
            <div>
                Edition: <%= book.Edition %>
            </div>
            <div>
                Availability: <%= book.IsAvailable %>
            </div>
            <div>
                Quantity Available: <%= book.QuantityAvailable %>
            </div>
            <div>
                Publisher: <%= book.Publisher %>
            </div>
        </div>
        <div class="col-sm-3"></div>
        <div class="col-sm-6">
            thumbnail
        </div>
        <div class="col-sm-6">
            <% if (null != Session["LoggedUser"])
                { %>
            <div class="ub-book-button-holder">
                <asp:Button
                    ID="ReserveButton"
                    Text="Reserve"
                    CommandArgument='<%# Eval("PrimaryKey.Key") %>'
                    CssClass="ub-book-button"
                    OnClick="ReserveButton_Click"
                    runat="server" />
            </div>
            <% } %>
        </div>
    </div>
</asp:Content>

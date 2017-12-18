<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comp229_TeamAssign._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Model list --%>
    <asp:Repeater ID="ModelRepeater" runat="server">
        <ItemTemplate>
            <div class="col-sm-2">
                <div class="model-outer-border">
                    <div class="model-content">
                        <div class="model-name">
                            <a href="Model.aspx?model=<%# Eval("Name") %>">
                                <asp:Label ID="ModelLabel" Text='<%# Eval("Name") %>' runat="server" /></span>
                            </a>
                        </div>
                        <div class="model-image">
                            <a href="Model.aspx?model=<%# Eval("Name") %>">
                                <asp:Image ID="ModelImage"
                                    AlternateText='<%# Eval("Name") %>'
                                    ImageUrl='<%# Eval("ImageUrl") %>'
                                    CssClass="model-image-small"
                                    runat="server"
                                    ToolTip="Click on the image to see the model details." />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

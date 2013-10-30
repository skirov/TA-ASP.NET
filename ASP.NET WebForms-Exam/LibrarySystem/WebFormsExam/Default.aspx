<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsExam._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="span1">
            <h1>Books</h1>
        </div>
        <div class="search-button pull-right">
            <div class="form-search">
                <asp:TextBox runat="server" ID="SearchTextBox"
                    placeholder="Search by book title / author..."
                    CssClass="span3 search-query"></asp:TextBox>
                <asp:LinkButton runat="server"
                    ID="SearchButton"
                    Text="Search"
                    CssClass="btn"
                    CommandName="Search"
                    OnCommand="SearchButton_Command"></asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:Repeater ID="Category" runat="server" ItemType="WebFormsExam.Models.Category" SelectMethod="Category_GetData">
            <ItemTemplate>
                <div class="span4">
                    <h3><%#: Item.Title %></h3>
                    <asp:ListView ID="Book" DataSource="<%# Item.Books %>" ItemType="WebFormsExam.Models.Book" runat="server">
                        <ItemTemplate>
                            <p>
                                <asp:LinkButton
                                    ID="BookTitle"
                                    Text="<%#: Item.Title %>"
                                    runat="server"
                                    CommandName="SeeDetails"
                                    CommandArgument="<%# Item.Id %>"
                                    OnCommand="SeeBookDetails"></asp:LinkButton>
                            </p>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

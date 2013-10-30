<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebFormsExam.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>
            Search Results for Query <i>"<asp:Literal runat="server" ID="searchResultsTitle" Mode="Encode"></asp:Literal>"</i>:
        </h2>
    </div>
    <div class="row">
        <div class="span12 search-results">
            <ul>
                <asp:ListView runat="server" ID="searchResults" ItemType="WebFormsExam.Models.Book">
                    <LayoutTemplate>
                        <div id="itemPlaceholder" runat="server"></div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton
                                ID="singleResult"
                                runat="server"
                                CommandName="SeeRersultDetails"
                                CommandArgument="<%#: Item.Id %>"
                                OnCommand="singleResult_Command">

                <asp:Label runat="server">
                    <%#: Item.Title %>
                    <i>by <%#: Item.Author %></i>
                </asp:Label>
                            </asp:LinkButton>
                            <asp:Label runat="server">(Category: <%#: Item.Category.Title %>)</asp:Label>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
            <div class="back-link">
                <a href="/">Back to books</a>
            </div>
        </div>
    </div>
</asp:Content>

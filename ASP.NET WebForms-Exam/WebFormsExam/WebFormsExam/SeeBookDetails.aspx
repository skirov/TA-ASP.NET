<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeeBookDetails.aspx.cs" Inherits="WebFormsExam.SeeBookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1>Book Details</h1>
        <p class="book-title"><asp:Literal ID="BookTitle" runat="server" Mode="Encode"></asp:Literal></p>
        <p class="book-author"><i><asp:Literal ID="BookAuthor" runat="server" Mode="Encode"></asp:Literal></i></p>
        <p class="book-isbn"><i>ISBN <asp:Literal ID="BookISBN" runat="server" Mode="Encode"></asp:Literal></i></p>
        <p class="book-isbn"><i>Web site: <asp:HyperLink ID="BookWebSite" runat="server"></asp:HyperLink></i></p>
    </header>

    <div class="row-fluid">
        <div class="span12 book-description">
            <p>
                <i>Description:</i> <asp:Literal ID="BookDescription" runat="server" Mode="Encode"></asp:Literal>
            </p>
        </div>
    </div>

    <div class="back-link">
        <a href="/">Back to books</a>
    </div>
</asp:Content>

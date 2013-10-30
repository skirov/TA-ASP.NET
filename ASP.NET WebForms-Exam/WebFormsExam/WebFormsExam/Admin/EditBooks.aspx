<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="WebFormsExam.Admin.EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- All books grid view --%>
    <asp:GridView ID="AllBooks" runat="server"
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        ItemType="WebFormsExam.Models.Book"
        DataKeyNames="Id" PageSize="5"
        OnSelectedIndexChanged="AllBooks_SelectedIndexChanged"
        SelectMethod="AllBooks_GetData"
        DeleteMethod="AllBooks_DeleteItem">
        <Columns>
            <asp:BoundField ItemStyle-CssClass="Shorter" DataField="Title" HeaderText="Book Title" SortExpression="Title" />
            <asp:BoundField ItemStyle-CssClass="Shorter" DataField="Author" HeaderText="Book Author" SortExpression="Author" />
            <asp:BoundField ItemStyle-CssClass="Shorter" DataField="ISBN" HeaderText="Book ISBN" SortExpression="ISBN" />
            <asp:BoundField ItemStyle-CssClass="Shorter" DataField="Website" HeaderText="Book Website" SortExpression="Website" />
            <asp:BoundField ItemStyle-CssClass="Shorter" DataField="Category.Title" HeaderText="Book Category" SortExpression="CategoryName" />
            <asp:CommandField ControlStyle-CssClass="btn btn-info"
                ShowDeleteButton="true"
                ShowSelectButton="true"
                SelectText="Edit"
                HeaderText="Actions" />
        </Columns>
    </asp:GridView>

    <%-- Button For Creation --%>
    <asp:LinkButton
        ID="CreateABookButton"
        runat="server"
        CommandName="CreateABook"
        OnCommand="CreateABookButton_Command"
        Text="Create a new book"
        CssClass="btn btn-primary"></asp:LinkButton>

    <%-- Delete Book --%>
    <div id="deleteBookConteiner" runat="server" visible="false">
        <h2>
            <asp:Literal runat="server" ID="NameOfDeleteBook" Mode="Encode"></asp:Literal></h2>
        <p>Are you sure you want to delete this book</p>
        <asp:LinkButton
            ID="DeleteBookButton"
            runat="server"
            CommandName="DeleteBook"
            OnCommand="DeleteBookButton_Command"
            Text="Yes"
            CssClass="btn btn-danger"></asp:LinkButton>
        <asp:LinkButton
            ID="CancelDeletion"
            runat="server"
            CommandName="CancelDeletion"
            OnCommand="CancelDeletion_Command"
            Text="No"
            CssClass="btn"></asp:LinkButton>
    </div>


    <%-- Edit Book --%>
    <div class="row-fluid">
        <div id="editBookConteiner" runat="server" visible="false" class="span4">
            <h2>
                <asp:Literal runat="server" ID="NameOfEditBook"></asp:Literal>
            </h2>

            <asp:Label runat="server" AssociatedControlID="TexboxForBookTitle" Text="Title: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="TexboxForBookTitle"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="TexboxForBookAuthor" Text="Author(s): " CssClass="formLabel">
                <asp:TextBox runat="server" ID="TexboxForBookAuthor"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="TexboxForBookISBN" Text="ISBN: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="TexboxForBookISBN"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="TexboxForBookWebSiet" Text="Web site: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="TexboxForBookWebSiet"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="TexboxForBookDescription" Text="Description: " CssClass="formLabel">
                <asp:TextBox TextMode="MultiLine" Rows="10" Columns="20" runat="server" ID="TexboxForBookDescription"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="SelectForBookCategory" Text="Category: " CssClass="formlabel">
                <asp:DropDownList runat="server" ID="SelectForBookCategory" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
            </asp:Label>

            <asp:LinkButton
                ID="EditBookButton"
                runat="server"
                CommandName="EditBook"
                OnCommand="EditBookButton_Command"
                Text="Edit this book"
                CssClass="btn btn-success"></asp:LinkButton>
            
            <asp:LinkButton
                ID="cancelBookEdition"
                runat="server"
                CommandName="cancelBookEdition"
                OnCommand="cancelBookEdition_Command"
                Text="Cancel"
                CssClass="btn btn-warning"></asp:LinkButton>
        </div>
    </div>

    <%-- Create Book --%>
    <div class="row-fluid">
        <div id="createCategoryConteiner" runat="server" visible="false" class="span4">
            <h2>Create a book
            </h2>

            <asp:Label runat="server" AssociatedControlID="CreateTexboxForBookTitle" Text="Title: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="CreateTexboxForBookTitle"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="CreateTexboxForBookAuthor" Text="Author(s): " CssClass="formLabel">
                <asp:TextBox runat="server" ID="CreateTexboxForBookAuthor"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="CreateTexboxForBookISBN" Text="ISBN: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="CreateTexboxForBookISBN"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="CreateTexboxForBookWebSiet" Text="Web site: " CssClass="formLabel">
                <asp:TextBox runat="server" ID="CreateTexboxForBookWebSiet"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="CreateTexboxForBookDescription" Text="Description: " CssClass="formLabel">
                <asp:TextBox TextMode="MultiLine" Rows="10" Columns="20" runat="server" ID="CreateTexboxForBookDescription"></asp:TextBox>
            </asp:Label>

            <asp:Label runat="server" AssociatedControlID="CreateSelectForBookCategory" Text="Category: " CssClass="formlabel">
                <asp:DropDownList runat="server" ID="CreateSelectForBookCategory" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
            </asp:Label>

            <asp:LinkButton
                ID="CreateBookButton"
                runat="server"
                CommandName="CreateBook"
                OnCommand="CreateBookButton_Command"
                Text="Create a new book"
                CssClass="btn btn-success"></asp:LinkButton>

            <asp:LinkButton
                ID="cancelBookCreation"
                runat="server"
                CommandName="cancelBookCreation"
                OnCommand="cancelBookCreation_Command"
                Text="Cancel"
                CssClass="btn btn-warning"></asp:LinkButton>
        </div>
    </div>
</asp:Content>

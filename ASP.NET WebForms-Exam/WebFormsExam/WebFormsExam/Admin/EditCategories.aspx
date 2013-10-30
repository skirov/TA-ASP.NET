<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="WebFormsExam.Admin.EditCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- All categories grid view --%>
    <asp:GridView ID="AllCategories" runat="server"
        AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        ItemType="WebFormsExam.Models.Category"
        DataKeyNames="Id" PageSize="5"
        OnSelectedIndexChanged="AllCategories_SelectedIndexChanged"
        SelectMethod="AllCategories_GetData"
        DeleteMethod="AllCategories_DeleteItem">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Category Title" SortExpression="Title" />
            <asp:CommandField ControlStyle-CssClass="btn btn-info"
                ShowDeleteButton="true"
                ShowSelectButton="true"
                SelectText="Edit"
                HeaderText="Actions" />
        </Columns>
    </asp:GridView>

    <%-- Button For Creation --%>
    <asp:LinkButton
        ID="CreateACategoryButton"
        runat="server"
        CommandName="CreateACategory"
        OnCommand="CreateACategoryButton_Command"
        Text="Create a new category"
        CssClass="btn btn-primary"></asp:LinkButton>

    <%-- Delete Category --%>
    <div id="deleteCategoryConteiner" runat="server" visible="false">
        <h2>
            <asp:Literal runat="server" ID="NameOfDeleteCategory" Mode="Encode"></asp:Literal></h2>
        <asp:LinkButton
            ID="DeleteCategoryButton"
            runat="server"
            CommandName="DeleteCategory"
            OnCommand="DeleteCategoryButton_Command"
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

    <%-- Edit Category --%>
    <div id="editCategoryConteiner" runat="server" visible="false">
        <h2>
            <asp:Literal runat="server" ID="NameOfEditCategory" Mode="Encode"></asp:Literal></h2>
        <asp:Label runat="server" AssociatedControlID="TexboxForCategoryToEdit" Text="Category Title: "></asp:Label>
        <asp:TextBox runat="server" ID="TexboxForCategoryToEdit"></asp:TextBox>
        <p>
            <asp:LinkButton
                ID="EditCategoryButton"
                runat="server"
                CommandName="EditCategory"
                OnCommand="EditCategoryButton_Command"
                Text="Edit this category"
                CssClass="btn btn-success"></asp:LinkButton>

            <asp:LinkButton
                ID="cancelCategoryEdition"
                runat="server"
                CommandName="cancelCategoryEdition"
                OnCommand="cancelCategoryEdition_Command"
                Text="Cancel"
                CssClass="btn btn-warning"></asp:LinkButton>
        </p>
    </div>

    <%-- Create Category --%>
    <div id="createCategoryConteiner" runat="server" visible="false">
        <h2>Create a category</h2>
        <span>Category name: </span>
        <asp:TextBox runat="server" ID="TexboxForCategoryToCreate"></asp:TextBox>
        <p>
            <asp:LinkButton
                ID="CreateCategoryButton"
                runat="server"
                CommandName="CreateCategory"
                OnCommand="CreateCategoryButton_Command"
                Text="Create a category"
                CssClass="btn btn-success"></asp:LinkButton>

            <asp:LinkButton
                ID="cancelCategoryCreation"
                runat="server"
                CommandName="cancelCategoryCreation"
                OnCommand="cancelCategoryCreation_Command"
                Text="Cancel"
                CssClass="btn btn-warning"></asp:LinkButton>
        </p>
    </div>
</asp:Content>

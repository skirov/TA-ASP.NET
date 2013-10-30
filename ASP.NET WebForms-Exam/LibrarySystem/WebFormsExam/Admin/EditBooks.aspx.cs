using Error_Handler_Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;

namespace WebFormsExam.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AllBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editBookConteiner.Visible = true;
            this.deleteBookConteiner.Visible = false;
            this.createCategoryConteiner.Visible = false;

            int bookId = Convert.ToInt32(this.AllBooks.SelectedDataKey.Value);

            var context = new LibrarySystemEntities();

            var book = context.Books.Find(bookId);

            this.TexboxForBookTitle.Text = book.Title;
            this.TexboxForBookAuthor.Text = book.Author;
            this.TexboxForBookISBN.Text = book.ISBN;
            this.TexboxForBookDescription.Text = book.Description;
            this.TexboxForBookWebSiet.Text = book.WebSite;

            this.SelectForBookCategory.DataSource = context.Categories.ToList();
            this.SelectForBookCategory.DataBind();
            this.SelectForBookCategory.Items.FindByValue(book.CategoryId.ToString()).Selected = true;

            this.EditBookButton.CommandArgument = book.Id.ToString();
        }

        protected void EditBookButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                book.Title = this.TexboxForBookTitle.Text;
                book.Author = this.TexboxForBookAuthor.Text;
                book.ISBN = this.TexboxForBookISBN.Text;
                book.Description = this.TexboxForBookDescription.Text;
                book.WebSite = this.TexboxForBookWebSiet.Text;

                int selectedCategoryId = Convert.ToInt32(this.SelectForBookCategory.SelectedValue);
                Category selectedCategory = context.Categories.FirstOrDefault(c => c.Id == selectedCategoryId);

                book.Category = selectedCategory;

                context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Book '" + book.Title + "' edited.");

                this.editBookConteiner.Visible = false;

                this.AllBooks.SelectMethod = "AllBooks_GetData";
                this.AllBooks.DataBind();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<WebFormsExam.Models.Book> AllBooks_GetData()
        {
            var context = new LibrarySystemEntities();

            return context.Books.Include("Category");
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AllBooks_DeleteItem(int id)
        {
            this.deleteBookConteiner.Visible = true;
            this.editBookConteiner.Visible = false;
            this.createCategoryConteiner.Visible = false;

            var context = new LibrarySystemEntities();

            var book = context.Books.Find(id);

            this.NameOfDeleteBook.Text = "Delete " + book.Title + " book";
            this.DeleteBookButton.CommandArgument = book.Id.ToString();
        }

        protected void DeleteBookButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                context.Books.Remove(book);
                context.SaveChanges();

                this.AllBooks.SelectMethod = "AllBooks_GetData";
                this.AllBooks.DataBind();

                ErrorSuccessNotifier.AddInfoMessage("Book '" + book.Title + "' deleted.");

                this.deleteBookConteiner.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void CancelDeletion_Command(object sender, CommandEventArgs e)
        {
            this.deleteBookConteiner.Visible = false;
        }

        protected void CreateABookButton_Command(object sender, CommandEventArgs e)
        {
            var context = new LibrarySystemEntities();

            this.createCategoryConteiner.Visible = true;
            this.deleteBookConteiner.Visible = false;
            this.editBookConteiner.Visible = false;

            this.CreateSelectForBookCategory.DataSource = context.Categories.ToList();
            this.CreateSelectForBookCategory.DataBind();
        }

        protected void CreateBookButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                Book newBook = new Book();
                newBook.Title = this.CreateTexboxForBookTitle.Text;
                newBook.Author = this.CreateTexboxForBookAuthor.Text;
                newBook.ISBN = this.CreateTexboxForBookISBN.Text;
                newBook.Description = this.CreateTexboxForBookDescription.Text;
                newBook.WebSite = this.CreateTexboxForBookWebSiet.Text;

                int selectedCategoryId = Convert.ToInt32(this.CreateSelectForBookCategory.SelectedValue);
                Category selectedCategory = context.Categories.FirstOrDefault(c => c.Id == selectedCategoryId);
                newBook.Category = selectedCategory;

                context.Books.Add(newBook);
                context.SaveChanges();
                
                ErrorSuccessNotifier.AddSuccessMessage("Book '" + newBook.Title + "' created.");

                this.createCategoryConteiner.Visible = false;

                this.AllBooks.SelectMethod = "AllBooks_GetData";
                this.AllBooks.DataBind();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

        protected void cancelBookCreation_Command(object sender, CommandEventArgs e)
        {
            this.createCategoryConteiner.Visible = false;
        }

        protected void cancelBookEdition_Command(object sender, CommandEventArgs e)
        {
            this.editBookConteiner.Visible = false;
        }
    }
}
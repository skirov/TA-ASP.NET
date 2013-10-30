using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;

namespace WebFormsExam
{
    public partial class SeeBookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();

            int bookId = int.Parse(Request.Params["bookId"]);

            Book getBook = context.Books.FirstOrDefault(b => b.Id == bookId);

            this.BookTitle.Text = getBook.Title;
            this.BookAuthor.Text = getBook.Author;
            this.BookISBN.Text = getBook.ISBN;
            this.BookWebSite.Text = Server.HtmlEncode(getBook.WebSite);
            this.BookWebSite.NavigateUrl = getBook.WebSite;
            this.BookDescription.Text = getBook.Description;
        }
    }
}
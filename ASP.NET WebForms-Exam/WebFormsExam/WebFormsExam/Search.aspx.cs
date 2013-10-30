using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;

namespace WebFormsExam
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var searchQuery = Request.Params["q"];

            var context = new LibrarySystemEntities();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                var results = context.Books
                    .Where(r => r.Title.Contains(searchQuery) || r.Author.Contains(searchQuery))
                    .OrderBy(b => b.Author)
                    .ThenBy(x => x.Author)
                    .ToList();

                this.searchResultsTitle.Text = searchQuery;

                this.searchResults.DataSource = results;
                this.searchResults.DataBind();
            }
            else
            {
                var results = context.Books
                .OrderBy(b => b.Author)
                .ThenBy(x => x.Author)
                .ToList();

                this.searchResultsTitle.Text = searchQuery;

                this.searchResults.DataSource = results;
                this.searchResults.DataBind();
            }
        }

        protected void singleResult_Command(object sender, CommandEventArgs e)
        {
            int answerId = Convert.ToInt32(e.CommandArgument);
            using (LibrarySystemEntities context = new LibrarySystemEntities())
            {
                Book book = context.Books.FirstOrDefault(x => x.Id == answerId);
                Response.Redirect("SeeBookDetails.aspx?bookId=" +
                    book.Id);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsExam.Models;

namespace WebFormsExam
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<WebFormsExam.Models.Category> Category_GetData()
        {
            var context = new LibrarySystemEntities();

            return context.Categories;
        }

        protected void SeeBookDetails(object sender, CommandEventArgs e)
        {
            int answerId = Convert.ToInt32(e.CommandArgument);
            using (LibrarySystemEntities context = new LibrarySystemEntities())
            {
                Book book = context.Books.FirstOrDefault(x => x.Id == answerId);
                Response.Redirect("SeeBookDetails.aspx?bookId=" +
                    book.Id);
            }
        }

        protected void SearchButton_Command(object sender, CommandEventArgs e)
        {
            var searchQuery = this.SearchTextBox.Text;
            Response.Redirect("Search.aspx?q=" + searchQuery);
        }
    }
}
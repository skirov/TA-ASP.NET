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
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> AllCategories_GetData()
        {
            var context = new LibrarySystemEntities();

            return context.Categories;
        }

        protected void AllCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.deleteCategoryConteiner.Visible = false;
            this.createCategoryConteiner.Visible = false;
            this.editCategoryConteiner.Visible = true;

            int categoryId = Convert.ToInt32(this.AllCategories.SelectedDataKey.Value);

            var context = new LibrarySystemEntities();

            var category = context.Categories.Find(categoryId);

            this.EditCategoryButton.CommandArgument = category.Id.ToString();
            this.NameOfEditCategory.Text = "Edit " + category.Title + " category";
            this.TexboxForCategoryToEdit.Text = category.Title;
        }

        protected void EditCategoryButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                category.Title = this.TexboxForCategoryToEdit.Text;
                context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Category '" + category.Title + "' edited successfuly.");
                this.editCategoryConteiner.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.AllCategories.SelectMethod = "AllCategories_GetData";
            this.AllCategories.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void AllCategories_DeleteItem(int id)
        {
            this.editCategoryConteiner.Visible = false;
            this.createCategoryConteiner.Visible = false;
            this.deleteCategoryConteiner.Visible = true;

            var context = new LibrarySystemEntities();

            var category = context.Categories.Find(id);

            this.NameOfDeleteCategory.Text = "Delete " + category.Title + " category";
            this.DeleteCategoryButton.CommandArgument = category.Id.ToString();
        }

        protected void DeleteCategoryButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                context.Books.RemoveRange(category.Books);
                context.Categories.Remove(category);
                context.SaveChanges();

                ErrorSuccessNotifier.AddInfoMessage("Category '" + category.Title + "' deleted along with all related books.");
                this.deleteCategoryConteiner.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.AllCategories.SelectMethod = "AllCategories_GetData";
            this.AllCategories.DataBind();
        }

        protected void CreateACategoryButton_Command(object sender, CommandEventArgs e)
        {
            this.editCategoryConteiner.Visible = false;
            this.deleteCategoryConteiner.Visible = false;
            this.createCategoryConteiner.Visible = true;
        }

        protected void CreateCategoryButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var context = new LibrarySystemEntities();

                Category category = new Category();
                category.Title = this.TexboxForCategoryToCreate.Text;

                context.Categories.Add(category);
                context.SaveChanges();

                ErrorSuccessNotifier.AddSuccessMessage("Category '" + category.Title + "' created.");
                this.createCategoryConteiner.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.AllCategories.SelectMethod = "AllCategories_GetData";
            this.AllCategories.DataBind();

        }

        protected void CancelDeletion_Command(object sender, CommandEventArgs e)
        {
            this.deleteCategoryConteiner.Visible = false;
        }

        protected void cancelCategoryEdition_Command(object sender, CommandEventArgs e)
        {
            this.editCategoryConteiner.Visible = false;
        }

        protected void cancelCategoryCreation_Command(object sender, CommandEventArgs e)
        {
            this.createCategoryConteiner.Visible = false;
        }
    }
}
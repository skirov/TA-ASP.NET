using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam.Web.Models;
using Exam.Models;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoryController : BaseController
    {
        //
        // GET: /Category/
        public ActionResult Admin()
        {
            return View();
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Id = category.CategoryId,
                    Name = category.CategoryName
                };

                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();

                category.CategoryId = newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategory([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data.Categories.All().Select(CategoryViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.CategoryId);

            if (category != null && ModelState.IsValid)
            {
                existingCategory.Name = category.CategoryName;

                this.Data.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.CategoryId);

            foreach (var ticket in existingCategory.Tickets.ToList())
            {
                foreach (var comment in ticket.Comments.ToList())
                {
                    this.Data.Comments.Delete(comment);
                }
                this.Data.Tickets.Delete(ticket);
            }

            this.Data.Categories.Delete(existingCategory);

            this.Data.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
	}
}
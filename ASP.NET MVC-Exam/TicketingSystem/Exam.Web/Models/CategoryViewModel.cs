using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class CategoryViewModel
    {
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "The category between 2 and 150 symbols.")]
        public string CategoryName { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryViewModel()
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name
                };
            }
        }
    }
}
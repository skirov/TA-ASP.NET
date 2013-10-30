using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class CommentCreateModel
    {
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "The comment between 3 and 500 symbols.")]
        public string Content { get; set; }
    }
}
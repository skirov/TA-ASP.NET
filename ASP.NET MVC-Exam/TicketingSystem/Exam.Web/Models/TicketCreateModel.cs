using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketCreateModel
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The title must be between 5 and 100 symbols.")]
        [ShouldNotContainWordBug(ErrorMessage="The title cannot contain the word bug in it.")]
        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string ImageUrl { get; set; }

        [StringLength(1000, ErrorMessage = "The description must at most 1000 symbols.")]
        public string Description { get; set; }
    }
}
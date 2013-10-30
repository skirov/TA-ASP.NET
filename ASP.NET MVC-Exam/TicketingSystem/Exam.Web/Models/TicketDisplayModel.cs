using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketDisplayModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        //Optional
        public string Description { get; set; }

        public Priority Priority { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CommentDisplayModel> Comments { get; set; }
    }
}
using Exam.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketPartialDisplayModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int NumberOfComments { get; set; }

        public static Expression<Func<Ticket, TicketPartialDisplayModel>> FromTicket
        {
            get 
            {
                return ticket => new TicketPartialDisplayModel()
                {
                    AuthorName = ticket.User.UserName,
                    CategoryName = ticket.Category.Name,
                    Id = ticket.Id,
                    NumberOfComments = ticket.Comments.Count,
                    Title = ticket.Title
                };
            }
        }
    }
}
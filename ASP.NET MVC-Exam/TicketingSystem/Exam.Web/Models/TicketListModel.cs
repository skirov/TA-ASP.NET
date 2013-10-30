using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketListModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public string Priority { get; set; }

        //public static Expression<Func<Ticket, TicketListModel>> FromTicket
        //{
        //    get
        //    {
        //        return ticket => new TicketListModel()
        //        {
        //            Id = ticket.Id,
        //            Title = ticket.Title,
        //            Priority = Enum.GetName(typeof(Priority), ticket.Priority),
        //            AuthorName = ticket.User.UserName,
        //            CategoryName = ticket.Category.Name
        //        };
        //    }
        //}
    }
}
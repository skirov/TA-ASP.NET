using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exam.Web.Models;

namespace Exam.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var topCommentedTickets = this.Data.Tickets
                .All()
                .OrderByDescending(t => t.Comments.Count)
                .Take(6)
                .Select(TicketPartialDisplayModel.FromTicket)
                .ToList();

                this.HttpContext.Cache.Add("HomePageTickets", topCommentedTickets, null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["HomePageTickets"]); ;
        }
    }
}
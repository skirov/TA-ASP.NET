using Exam.Models;
using Exam.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Controllers
{
    public class TicketController : BaseController
    {
        //
        // GET: /Ticket/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var currentTicket = this.Data.Tickets.GetById(id);

            var ticketFullModel = new TicketDisplayModel()
            {
                AuthorName = currentTicket.User.UserName,
                CategoryName = currentTicket.Category.Name,
                Comments = currentTicket.Comments.AsQueryable().Select(CommentDisplayModel.FromComment),
                Description = currentTicket.Description,
                Id = currentTicket.Id,
                ImageUrl = currentTicket.ImageUrl,
                Priority = currentTicket.Priority,
                Title = currentTicket.Title
            };

            return View(ticketFullModel);
        }

        [Authorize]
        public ActionResult AddComment(CommentCreateModel commentModel, int ticketId)
        {
            var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            var ticket = this.Data.Tickets.GetById(ticketId);

            if (ModelState.IsValid)
            {
                var newComment = new Comment()
                {
                    Content = commentModel.Content,
                    Ticket = ticket,
                    User = user
                };

                this.Data.Comments.Add(newComment);
                this.Data.SaveChanges();

                return PartialView("_CommentPartial", new CommentDisplayModel() { Content = commentModel.Content, Username = this.User.Identity.Name });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid comment");
            }
        }

        [Authorize]
        public ActionResult AddTicket(TicketCreateModel ticketModel)
        {
            var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            var category = this.Data.Categories.GetById(ticketModel.CategoryId);

            if (ModelState.IsValid)
            {
                var newTicket = new Ticket()
                {
                    Title = ticketModel.Title,
                    User = user,
                    Description = ticketModel.Description,
                    ImageUrl = ticketModel.ImageUrl,
                    Priority = ticketModel.Priority,
                    Category = category
                };

                user.Points += 1;

                this.Data.Tickets.Add(newTicket);
                this.Data.SaveChanges();

                return Redirect("~/Ticket/Details/" + newTicket.Id);
            }
            return View("CreateTicket",ticketModel);
        }

        [Authorize]
        public ActionResult CreateTicket()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetCategories([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.Data.Categories.All().Select(CategoryViewModel.FromCategory);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult TicketsList()
        {
            return View();
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest]DataSourceRequest request)
        {
            var dbTickets = this.Data.Tickets.All();

            List<TicketListModel> tickets = new List<TicketListModel>();

            foreach (var ticket in dbTickets)
            {
                var ticketToAdd = new TicketListModel();
                ticketToAdd.Id = ticket.Id;
                ticketToAdd.Title = ticket.Title;
                ticketToAdd.Priority = Enum.GetName(typeof(Priority), ticket.Priority);
                ticketToAdd.AuthorName = ticket.User.UserName;
                ticketToAdd.CategoryName = ticket.Category.Name;

                tickets.Add(ticketToAdd);
            }

            return Json(tickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult SearchByCategory(int? categoryId)
        {
            IEnumerable<TicketPartialDisplayModel> ticketsByCategory = null;

            if (categoryId != null)
            {
                ticketsByCategory = this.Data.Tickets.All()
                .Where(t => t.CategoryId == categoryId)
                .Select(TicketPartialDisplayModel.FromTicket)
                .ToList();
            }
            else
            {
                ticketsByCategory = this.Data.Tickets.All()
                .Select(TicketPartialDisplayModel.FromTicket)
                .ToList();
            }

            return View("~/Views/Home/Index.cshtml", ticketsByCategory);
        }
	}
}
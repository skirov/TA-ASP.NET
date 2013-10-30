using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.Models;
using Exam.Data;

namespace Exam.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CommentController : BaseController
    {
        // GET: /Comment/
        public ActionResult Index()
        {
            var comments = this.Data.Comments.All();
            return View(comments.ToList());
        }

        // GET: /Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: /Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketId = new SelectList(this.Data.Tickets.All(), "Id", "Title", comment.TicketId);
            ViewBag.UserId = new SelectList(this.Data.Users.All(), "Id", "UserName", comment.UserId);
            return View(comment);
        }

        // POST: /Comment/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var editedComment = this.Data.Comments.GetById(comment.Id);
                editedComment.Content = comment.Content;
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: /Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: /Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.Data.Comments.GetById((int)id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var db = new ApplicationDbContext();
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreyApplication.Models;

namespace GreyApplication.Controllers
{
    public class FeedBackController : Controller
    {
        BlogContext db = new BlogContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Feedbacks.OrderByDescending(f=>f.PublicationDate).ToList());
        }


        //Author of feedback now hardcoded. Later will be chaged to User.Identity
        [HttpPost]
        public ActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Added;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
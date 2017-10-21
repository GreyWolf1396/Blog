using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreyApplication.Models;

namespace GreyApplication.Controllers
{
    public class PassController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: Pass
        public ActionResult Index()
        {
            return View(db.Passes.ToList());
        }

        public ActionResult Detail(int id)
        {
            var answers = db.Answers.Where(a => a.PassId == id).ToList();
            ViewBag.BlankTitle = db.Passes.Find(id).Title;
            return View(answers);
        }
    }
}
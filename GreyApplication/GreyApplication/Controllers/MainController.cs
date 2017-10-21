using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreyApplication.Models;

namespace GreyApplication.Controllers
{
    public class MainController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: Main
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            var article = db.Articles.Find(id);
            return View(article);
        }
    }
}
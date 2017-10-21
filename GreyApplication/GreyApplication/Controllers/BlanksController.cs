using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreyApplication.Models;


namespace GreyApplication.Controllers
{
    public class BlanksController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            return View(db.Blanks.ToList());
        }

        [HttpGet]
        public ActionResult Detail(int Id)
        {
            
            var questions = db.Questions.Where(q => q.BlankId == Id).ToList();
            foreach (var q in questions)
            {
                q.Variants = db.Variants.Where(v => v.QuestionId == q.Id);
            }
            ViewBag.BlankTitle = db.Blanks.Find(Id).Title;
            ViewBag.BlankId = Id;
            return View(questions);
        }

        [HttpPost]
        public ActionResult Detail(FormCollection formCollection)
        {
            var blank = db.Blanks.Find(int.Parse(formCollection["blankId"]));
            blank.Questions = db.Questions.Where(q => q.BlankId == blank.Id);

            Pass pass = new Pass()
            {
                AuthorId = 1, //hardcoded. TODO: Change for User.Identity
                Title = blank.Title
            };
            db.Passes.Add(pass);

            foreach (var question in blank.Questions)
            {
                Answer answer = new Answer()
                {
                    Pass = pass,
                    QustionNumber = question.Number,
                    QuestionText = question.Text,
                    AnswerText = formCollection[question.Number.ToString()]
                };
                db.Answers.Add(answer);
            }

            db.SaveChanges();
            return RedirectToAction("Detail", "Pass", new {Id = pass.Id});
        }
    }
}
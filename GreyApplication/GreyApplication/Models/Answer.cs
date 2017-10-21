using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public int PassId { get; set; }
        public virtual Pass Pass { get; set; }
        public int QustionNumber { get; set; }

        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
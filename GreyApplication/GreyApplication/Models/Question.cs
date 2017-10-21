using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public virtual IEnumerable<Variant> Variants { get; set; }

        public int BlankId { get; set; }
        public virtual Blank Blank { get; set; }

        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        Text=1,
        RadioButton=2,
        SelectOne=3,
        SelectMultiple=4
    }
}
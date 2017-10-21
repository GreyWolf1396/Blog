using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Variant
    {
        public int Id { get; set; }

        public string Text { get; set; }
        
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
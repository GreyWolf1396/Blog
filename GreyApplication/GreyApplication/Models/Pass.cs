using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Pass
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public string Title { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }
    }
}
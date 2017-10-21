using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Display(Name = "Author")]
        public string Name { get; set; }

        [Display(Name = "Articles")]
        public virtual IEnumerable<Article> Articles{ get; set;}

        [Display(Name = "Feedbacks")]
        public virtual IEnumerable<Feedback> Feedbacks { get; set; }

        [Display(Name = "Blanks")]
        public virtual IEnumerable<Pass> Passes { get; set; }
    }
}
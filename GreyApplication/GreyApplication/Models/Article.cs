using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GreyApplication.Models
{
    public class Article
    {
        
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "PublicationDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Author")]
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
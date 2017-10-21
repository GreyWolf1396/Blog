using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Display(Name = "Enter you opinion: ")]
        [Required]
        public string Text { get; set; }

        [Display(Name = "Publication Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Author")]
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
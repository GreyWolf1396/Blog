using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreyApplication.Models
{
    public class BlogContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Pass> Passes { get; set; }
        public DbSet<Blank> Blanks { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Variant> Variants { get; set; }
    }
}
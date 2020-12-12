using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class LearningPortalContext : DbContext
    {
        public LearningPortalContext()
                : base("name=LearningPortalContext")
        {
        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
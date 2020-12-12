using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }

        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public AchievementLevel Achievement { get; set; }
        public short TeacherEvaluation { get; set; }
    }
}
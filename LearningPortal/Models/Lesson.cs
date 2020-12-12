using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPortal.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int DurationInMinutes { get; set; } 

        public string CommunicationChannel { get; set; }

        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }

        public int AmountOfPeople { get;  set; }

        [ForeignKey("Topic")]
        public int? TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        [ForeignKey("Grade")]
        public int? GradeId { get; set; }
        public virtual Topic Grade { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
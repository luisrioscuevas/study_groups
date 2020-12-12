using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningPortal.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int DurationInMinutes { get; set; } 

        public string CommunicationChannel { get; set; }

        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }
    }
}
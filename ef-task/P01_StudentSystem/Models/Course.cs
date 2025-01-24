using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }


        public List<StudentCourse> StudentCourses { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Homework> HomeworkSubmissions { get; set; }

    }
}

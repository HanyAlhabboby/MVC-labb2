using System.ComponentModel.DataAnnotations;

namespace StockholmSchool5.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }


        public virtual ICollection<StudentCourseTeacher>? StudentCourseTeachers { get; set; }
    }
}

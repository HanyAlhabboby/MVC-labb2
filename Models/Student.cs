using System.ComponentModel.DataAnnotations;

namespace StockholmSchool5.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<StudentCourseTeacher>? StudentCourseTeachers { get; set; }
    }
}

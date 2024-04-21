using System.ComponentModel.DataAnnotations;

namespace StockholmSchool5.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
        //public List<Course> Courses { get; set; }
    }
}

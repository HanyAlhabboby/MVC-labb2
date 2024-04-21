using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace StockholmSchool5.Models
{

    public enum Grade
    {
        A, B, C, D, E
    }
    public class StudentCourseTeacher
    {
        [Key]
        public int StudentCouseTeacherId { get; set; }
        public Grade? Grade { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }

        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockholmSchool5.Models
{
    public class Classs
    {
        [Key]
        public int ClasssId { get; set; }
        public string Title { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}

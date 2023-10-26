using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Roll_No { get; set; }
        [Required]
        public string? Sname { get; set; }
        [Required]
        public string? City { get; set; }

        public int SPercentage { get; set; }

    }
}

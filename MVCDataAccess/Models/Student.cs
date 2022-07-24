using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Mobile {get;set;}

    
        public int EnrollmentId {get;set;}
        public List<Enrollment> Enrollments { get;set;}
    }
}

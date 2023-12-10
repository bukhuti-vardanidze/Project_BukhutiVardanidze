using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Project.DB.Entities
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
     
        [ MinLength(11), MaxLength(11)]
        [RegularExpression(@"^[0-9]+$")]
        public string? PersonNumber { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public string University { get; set; }
        public string? Faculty { get; set; }
        public byte Course { get; set; }
    }
}

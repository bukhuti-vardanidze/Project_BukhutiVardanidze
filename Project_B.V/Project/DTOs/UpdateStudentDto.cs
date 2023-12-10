namespace Project.DTOs
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Faculty { get; set; }
        public byte Course { get; set; }
    }
}

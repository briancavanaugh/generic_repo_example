namespace Infrastructure.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public required string CourseName { get; set; }
    }
}

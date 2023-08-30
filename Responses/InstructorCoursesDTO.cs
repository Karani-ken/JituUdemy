namespace JituUdemy.Responses
{
    public class InstructorCoursesDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
    }

    public class CourseDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Price { get; set; }

        public int PurchaseCount { get; set; }
    }
}

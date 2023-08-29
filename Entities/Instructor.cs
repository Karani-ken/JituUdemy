namespace JituUdemy.Entities
{
    public class Instructor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Course> Courses { get; set; }= new List<Course>();
    }
}

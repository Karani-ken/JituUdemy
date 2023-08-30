namespace JituUdemy.Requests
{
    public class AddCourse
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Guid InstructorId { get; set; }
    }
}

using JituUdemy.Entities;

namespace JituUdemy.Services.IServices
{
    public interface ICourseService
    {
        //Add course
        Task<string> AddCourseAsync(Course course);
        //Update Course
        Task<string> UpdateCourseAsync(Course course);
        //Delete Course
        Task<string> DeleteCourseAsync(Course course);
        //Get Courses
        Task<IEnumerable<Course>>GetAllCoursesAsync();
        //get a course
        Task<Course> GetCourseByIdAsync(Guid id);
    }
}

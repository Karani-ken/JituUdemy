using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddCourseAsync(Course course)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return "Course Added Successfully";
        }

        public async Task<string> DeleteCourseAsync(Course course)
        {
            _context.Remove(course);
            await _context.SaveChangesAsync();
            return "Course Deleted successfully";          
        }

        public async Task<string> UpdateCourseAsync(Course course)
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
            return "Course Updated Successsfully";            
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {

            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            return await _context.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}

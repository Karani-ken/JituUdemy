using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Responses;
using JituUdemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;
        public InstructorService(AppDbContext context)
        {
            _context=context;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Added Successfully";
      
        }

        public async Task<string> DeleteInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return "Instructor deleted Successfully";
        }


        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Updated Successfully";
        }

      public  async Task<IEnumerable<InstructorCoursesDTO>> GetAllInstructorsAsync()
        {
            return await _context.Instructors.Select(i => new InstructorCoursesDTO()
            {
                Id = i.Id,
                Name = i.Name,
                Email = i.Email,
                Courses = i.Courses.Select(c => new CourseDto()
                {
                    Name = c.Name,
                    Description = c.Description,
                    PurchaseCount = c.Users.Count(),
                    Price = c.Price
                }).ToList()
            }).ToListAsync();
        }

       public async Task<Instructor> GetInstructorByIdAsync(Guid id)
        {
            return await _context.Instructors.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

      public  async Task<InstructorCoursesDTO> GetUserandCoursesIdAsync(Guid id)
        {
          
            return await _context.Instructors.
                  Where(x => x.Id == id).
                  Select(i => new InstructorCoursesDTO()
                  {
                      Id = i.Id,
                      Name = i.Name,
                      Email = i.Email,
                      Courses = i.Courses.Select(c => new CourseDto()
                      {
                          Name = c.Name,
                          Description = c.Description,
                          PurchaseCount = c.Users.Count(),
                          Price = c.Price
                      }).ToList()
                  }).FirstOrDefaultAsync();
        }
    }
}

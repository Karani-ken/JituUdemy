using JituUdemy.Data;
using JituUdemy.Entities;
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

        public async Task<IEnumerable<Instructor>> GetAllUsersAsync()
        {
            return await _context.Instructors.ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(Guid id)
        {
            return await _context.Instructors.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateInstructorAsync(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return "Instructor Updated Successfully";
        }
    }
}

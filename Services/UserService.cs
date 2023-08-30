using JituUdemy.Data;
using JituUdemy.Entities;
using JituUdemy.Requests;
using JituUdemy.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace JituUdemy.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User added successfuly";
           
        }

        public async Task<string> BuyCourse(BuyCourse buyCourse)
        {
            var user = await _context.Users.Where(u=> u.Id == buyCourse.UserId).FirstOrDefaultAsync();
            var course = await _context.Courses.Where(c => c.Id == buyCourse.CourseId).FirstOrDefaultAsync();
            if(user != null && course != null)
            {
                //add user or course
                user.Courses.Add(course);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Invalid Ids");
        }

        public async Task<string> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return "User Deleted successfuly";
           
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return "User updated successfuly";
           
        }

    }
}

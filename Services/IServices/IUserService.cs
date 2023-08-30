using JituUdemy.Entities;
using JituUdemy.Requests;

namespace JituUdemy.Services.IServices
{
    public interface IUserService
    {
        //Adding a User
        Task<string> AddUserAsync(User user);
        //update user
        Task<string> UpdateUserAsync(User user);
        //delete
        Task<string> DeleteUserAsync(User user);
        //get all users
        Task<IEnumerable<User>> GetAllUsersAsync();

        //get one user
        Task<User> GetUserByIdAsync(Guid id);

        //buy course
        Task<string> BuyCourse(BuyCourse buyCourse);

    }
}

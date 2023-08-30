using JituUdemy.Entities;

namespace JituUdemy.Services.IServices
{
    public interface IInstructorService
    {

        //Adding a User
        Task<string> AddInstructorAsync(Instructor instructor);
        //update user
        Task<string> UpdateInstructorAsync(Instructor instructor);
        //delete
        Task<string> DeleteInstructorAsync(Instructor instructor);
        //get all users
        Task<IEnumerable<Instructor>> GetAllUsersAsync();

        //get one user
        Task<Instructor> GetInstructorByIdAsync(Guid id);
    }
}

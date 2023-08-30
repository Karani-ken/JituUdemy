using JituUdemy.Entities;
using JituUdemy.Responses;

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
       

        //get one user
        Task<Instructor> GetInstructorByIdAsync(Guid id);

        //Get All User
        Task<IEnumerable<InstructorCoursesDTO>> GetAllInstructorsAsync();

        //Get One User
        Task< InstructorCoursesDTO> GetUserandCoursesIdAsync(Guid id);
    }
}

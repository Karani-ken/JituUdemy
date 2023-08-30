using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Requests;
using JituUdemy.Responses;
using JituUdemy.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorController(IMapper mapper,IInstructorService instructorService)
        {
            _mapper= mapper;
            _instructorService= instructorService;
        }
        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> AddInstructor(AddUser newInstructor)
        {
            var Instructor = _mapper.Map<Instructor>(newInstructor);
            var res = await _instructorService.AddInstructorAsync(Instructor);
            return CreatedAtAction(nameof(AddInstructor),new SuccessMessage(200,res));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instructor>>> GetAllInstructors()
        {
            var instructors = await _instructorService.GetAllUsersAsync();
            return Ok(instructors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetByIdInstructor(Guid id)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "User not Found"));
            }
            var user = _mapper.Map<UserResponse>(response);

            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> UpdateInstructor(Guid id, AddUser UpdatedInstructor)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "User not Found"));
            }
            var user = _mapper.Map(UpdatedInstructor, response);
            var res = await _instructorService.UpdateInstructorAsync(user);

            return Ok(new SuccessMessage(201, res));

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteInstructor(Guid id)
        {
            var response = await _instructorService.GetInstructorByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "User not Found"));
            }

            var res = await _instructorService.DeleteInstructorAsync(response);

            return Ok(new SuccessMessage(200, res));
        }
    }
}

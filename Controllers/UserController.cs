using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Requests;
using JituUdemy.Responses;
using JituUdemy.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        //add a new user
        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> AddUser(AddUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            var res = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(AddUser),new SuccessMessage(201, res));
        }
        //get all users
        [HttpGet]

        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {
            var response = await _userService.GetAllUsersAsync();

            var users = _mapper.Map<IEnumerable<UserResponse>>(response);

            return Ok(users);
        }
        //get user by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if(response == null)
            {
                return NotFound(new SuccessMessage(404, "User Does not Exixst"));

            }
            var user = _mapper.Map<UserResponse>(response); //map the response to the userrResponse
            return Ok(user);
        }

        //Update user
        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> Update(Guid id, AddUser UpdatedUser)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "User Does not Exixst"));

            }
            var updated = _mapper.Map(UpdatedUser, response);
            var res = await _userService.UpdateUserAsync(updated);
            return Ok(new SuccessMessage(204, res));
        }
        //Delete a user
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteUser(Guid id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if(response == null)
            {
                return NotFound(new SuccessMessage(404, "User does not Exist"));
            }
            var res = await _userService.DeleteUserAsync(response);

            return Ok(new SuccessMessage(201, res));
        }

    }
}

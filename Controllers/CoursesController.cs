using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Requests;
using JituUdemy.Responses;
using JituUdemy.Services;
using JituUdemy.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace JituUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;

        public CoursesController(IMapper mapper, ICourseService CourseService)
        {
            _mapper = mapper;
            _courseService = CourseService;
        }

        [HttpPost]
        public async Task<ActionResult<SuccessMessage>> AddCourse(AddCourse newCourse)
        {
            var course =  _mapper.Map<Course>(newCourse);

           var res = await _courseService.AddCourseAsync(course);
            return Ok(new SuccessMessage(200, res));
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var response = await _courseService.GetAllCoursesAsync();

            var courses = _mapper.Map<IEnumerable<CourseResponse>>(response);
            return Ok(courses);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "Course Does not Exist"));
            }
            var course = _mapper.Map<CourseResponse>(response);
            return Ok(course);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessMessage>> DeleteCourse(Guid id)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "Course Does not Exist"));
            }
            var res = await _courseService.DeleteCourseAsync(response);
            return Ok(new SuccessMessage(200, res));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessMessage>> UpdateCourse(Guid id, AddCourse UpdatedCourse)
        {
            var response = await _courseService.GetCourseByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessMessage(404, "Course Does not Exist"));
            }

            var CourseUpdate = _mapper.Map(UpdatedCourse,response);
            var res = await _courseService.UpdateCourseAsync(CourseUpdate);
            return Ok(new SuccessMessage(200, res));
        }
    }
}

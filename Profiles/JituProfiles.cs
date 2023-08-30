using AutoMapper;
using JituUdemy.Entities;
using JituUdemy.Requests;
using JituUdemy.Responses;

namespace JituUdemy.Profiles
{
    public class JituProfiles:Profile
    {
        public JituProfiles()
        {
            //users
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<UserResponse, User>().ReverseMap();
            
            //Courses
            CreateMap<AddCourse, Course>().ReverseMap();
            CreateMap<UpdateCourse, Course>().ReverseMap();
            CreateMap<CourseResponse, Course>().ReverseMap();

            //Instructors
            CreateMap<AddUser, Instructor>().ReverseMap();
            CreateMap<UserResponse, Instructor>().ReverseMap();
        }
       
    }
}

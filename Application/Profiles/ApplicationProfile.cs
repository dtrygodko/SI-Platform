using AutoMapper;
using Contract.Commands.Ideas;
using Contract.Commands.Users;
using Contract.Responses.Ideas;
using Contract.Responses.Users;
using Domain.Entities;

namespace Application.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Idea, IdeaDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<AddUserCommand, User>().ForMember(m => m.Email, expression => expression.AddTransform(value => value.ToLowerInvariant()));
            CreateMap<AddIdeaCommand, Idea>();
        }
    }
}
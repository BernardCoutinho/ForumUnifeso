using AutoMapper;
using ForumUnifeso.src.API.Model;
using ForumUnifeso.src.API.View;
namespace ForumUnifeso.src.API.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Person, PersonResponse>();
            CreateMap<PersonRequest, Person>();

            CreateMap<PostRequest, Post>();
            CreateMap<Post, PostResponse>();

            CreateMap<ThreadForumDTO, ThreadForum>();
            CreateMap<ThreadForum, ThreadForumDTO>();
        }
    }
}

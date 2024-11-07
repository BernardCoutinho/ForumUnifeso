using ForumUnifeso.src.API.Base;
using ForumUnifeso.src.API.Model.User;
using ForumUnifeso.src.API.View.User;

namespace ForumUnifeso.src.API.Interface
{
    public interface IUserService : IService<User, int>
    {
        Task<User> CreateUserAsync(UserRequest request);
    }
}

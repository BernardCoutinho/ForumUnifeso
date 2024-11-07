using ForumUnifeso.src.API.Base;
using ForumUnifeso.src.API.Model.User;

namespace ForumUnifeso.src.API.Interface
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetByUsernameOrEmailAsync(string username, string email);
    }
}

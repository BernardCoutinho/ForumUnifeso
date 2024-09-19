using ForumUnifeso.src.API.Base;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumRepository : IRepository<ThreadForum, int>
    {
        Task<ThreadForum?> GetByTitleAsync(string threadForumTitle);
    }
}

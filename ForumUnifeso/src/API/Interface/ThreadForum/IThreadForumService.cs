using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumService
    {
        ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO);
        Task<List<ThreadForum>> GetAllThreadsForum();
        Task<ThreadForum?> GetThreadForumById(int threadForumId);
        Task<ThreadForum?> GetThreadForumByTitle(string threadTitle);
        Task<ThreadForum?> PutThreadForum(int threadForumId);
        Task<ThreadForum?> DeleteThreadForum(int threadForumId);
    }
}
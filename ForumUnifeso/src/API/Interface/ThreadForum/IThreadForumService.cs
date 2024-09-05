using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumService
    {
        void PostThreadForum(ThreadForum threadForum);
        Task<IEnumerable<ThreadForum>> GetAllThreadForum();
        Task<ThreadForum?> GetThreadForumById(int id);
        Task<ThreadForum?> GetThreadForumByTitle(string title);
        Task PutThreadForum(ThreadForum threadForum);
        void DeleteThreadForum(int threadForumId);
    }
}
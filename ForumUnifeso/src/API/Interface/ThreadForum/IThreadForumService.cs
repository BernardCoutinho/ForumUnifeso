using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumService
    {
        ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO);
        Task<List<ThreadForum>> GetAllThreadForum();
        Task<ThreadForum?> GetThreadForumById(int id);
        Task<ThreadForum?> GetThreadForumByTitle(string title);
        Task PutThreadForum(ThreadForum threadForum);
        void DeleteThreadForum(int threadForumId);
    }
}
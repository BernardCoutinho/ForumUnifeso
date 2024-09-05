using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumService
    {
        ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO);
        List<ThreadForum> GetAllThreadForum();
        ThreadForum GetThreadForum(int threadForumId);
        ThreadForum PutThreadForum(ThreadForum threadForum);
        void DeleteThreadForum(int threadForumId);
    }
}
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Interface
{
    public interface IThreadForumService
    {
        void PostThreadForum(ThreadForum threadForum);
        void GetAllThreadForum();
        void GetThreadForum(int threadForumId);
        void PutThreadForum(ThreadForum threadForum);
        void DeleteThreadForum(int threadForumId);
    }
}
using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Service
{
    public class ThreadForumService : IThreadForumService
    {
        // private ThreadForumRepository _threadForumRepository;

        public ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO) 
        {
            Person author = new Person(1, threadForumDTO.AuthorName);
            Post topic = new Post(1, threadForumDTO.Title, threadForumDTO.Description, DateTime.Now , author);
            ThreadForum threadForum = new ThreadForum(1, topic);
            //ThreadForum threadForum = _threadForumRepository.save(threadForum);
            return threadForum;
        }

        public List<ThreadForum> GetAllThreadForum() => new List<ThreadForum> {};
        // _threadForumRepository.getAll();

        public ThreadForum GetThreadForum(int threadForumId)
        {
            throw new NotImplementedException();
        }

        public ThreadForum PutThreadForum(ThreadForum threadForum)
        {
            throw new NotImplementedException();
        }

        public void DeleteThreadForum(int threadForumId)
        {
            throw new NotImplementedException();
        }
    }
}
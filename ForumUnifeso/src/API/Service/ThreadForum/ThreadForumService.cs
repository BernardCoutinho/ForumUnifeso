using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Service
{
    public class ThreadForumService : IThreadForumService
    {
        private readonly List<ThreadForum> _threads = new();
        public void CreateThreadForum(ThreadForum ThreadForum) 
        {
            throw new NotImplementedException();
        }

        public ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO) 
        {
            Person author = new Person(1, threadForumDTO.AuthorName);
            Post topic = new Post(1, threadForumDTO.Title, threadForumDTO.Description, DateTime.Now , author);
            ThreadForum threadForum = new ThreadForum(1, topic);
            //ThreadForum threadForum = _threadForumRepository.save(threadForum);
            return threadForum;
        }

        public async Task<List<ThreadForum>> GetAllThreadForum()
        {
            return await Task.FromResult(_threads);
        }

        public async Task<ThreadForum?> GetThreadForumById(int id)
        {
            var thread = _threads.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(thread);
        }

        public async Task<ThreadForum?> GetThreadForumByTitle(string title)
        {

            var thread = _threads.FirstOrDefault(t => t?.Topic?.Title == title);
            return await Task.FromResult(thread);
        }

        public async Task PutThreadForum(ThreadForum threadForum)
        {
            var existingThread = _threads.FirstOrDefault(t => t.Id == threadForum.Id);
            if (existingThread != null)
            {
                existingThread = threadForum;
            }
            await Task.CompletedTask;
        }

        public void DeleteThreadForum(int threadForumId)
        {
            throw new NotImplementedException();
        }
    }
}
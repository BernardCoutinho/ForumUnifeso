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

        public void DeleteThreadForum(int threadForumId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ThreadForum>> GetAllThreadForum()
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

        public void PostThreadForum(ThreadForum threadForum)
        {
            throw new NotImplementedException();
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
    }
}
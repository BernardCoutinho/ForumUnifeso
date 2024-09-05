using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;

namespace ForumUnifeso.src.API.Service
{
    public class ThreadForumService : IThreadForumService
    {
        // private readonly ThreadForumRepository _threadForumRepository;

        // public ThreadForumService(ThreadForumRepository threadForumRepository) {
        //     _threadForumRepository = threadForumRepository;
        // }

        public ThreadForum PostThreadForum(ThreadForumDTO threadForumDTO) 
        {
            Person author = new Person(1, threadForumDTO.AuthorName);
            Post topic = new Post(1, threadForumDTO.Title, threadForumDTO.Description, DateTime.Now , author);
            ThreadForum threadForum = new ThreadForum(1, topic);
            //substituir
            ThreadForum savedThreadForum = threadForum;
            //ThreadForum savedThreadForum = _threadForumRepository.Save(threadForum);
            return savedThreadForum;
        }

        public async Task<List<ThreadForum>> GetAllThreadsForum()
        {
            //substituir
            List<ThreadForum> threadsForum = new List<ThreadForum>();
            //ThreadForum threadForum = _threadForumRepository.GetAll(threadForum);
            return await Task.FromResult(threadsForum);
        }

        public async Task<ThreadForum?> GetThreadForumById(int threadId)
        {
            //substituir
            var thread = new ThreadForum();
            //ThreadForum threadForum = _threadForumRepository.GetById(threadId);
            return await Task.FromResult(thread);
        }

        public async Task<ThreadForum?> GetThreadForumByTitle(string threadTitle)
        {
            //substituir
            var thread = new ThreadForum();
            //ThreadForum threadForum = _threadForumRepository.GetByTitle(threadTitle);
            return await Task.FromResult(thread);
        }

        public async Task<ThreadForum?> PutThreadForum(int threadForumId)
        {
            //substituir
            var threadForumUpdated = new ThreadForum();
            //ThreadForum threadForumUpdated = _threadForumRepository.Update(threadForumId);
            return await Task.FromResult(threadForumUpdated);
        }

        public async Task<ThreadForum?> DeleteThreadForum(int threadForumId)
        {
            //substituir
            var threadForumDeleted = new ThreadForum();
            //ThreadForum threadForumUpdated = _threadForumRepository.Delete(threadForum);
            return await Task.FromResult(threadForumDeleted);
        }
    }
}
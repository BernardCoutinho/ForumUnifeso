using AutoMapper;
using ForumUnifeso.src.API.Base;
using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using ForumUnifeso.src.API.View;

namespace ForumUnifeso.src.API.Service
{
    public class ThreadForumService : IThreadForumService
    {
        private readonly IThreadForumRepository _threadForumRepository;

        private readonly IMapper _mapper;

        public ThreadForumService(IThreadForumRepository threadForumRepository, IMapper mapper) {
            _threadForumRepository = threadForumRepository;
            _mapper = mapper;
        }

        public async Task<ThreadForumDTO> AddAsync(ThreadForumDTO threadForumDTO)
        {
            ThreadForum threadForum = _mapper.Map<ThreadForum>(threadForumDTO);
            ThreadForum threadForumSaved = await _threadForumRepository.AddAsync(threadForum);
            return _mapper.Map<ThreadForumDTO>(threadForumSaved);
        }

        public Task<bool> DeleteAsync(ThreadForumDTO threadForumDTO)
        {
            ThreadForum threadForum = _mapper.Map<ThreadForum>(threadForumDTO);
            return _threadForumRepository.DeleteAsync(threadForum);
        }

        public Task<bool> DeleteByIdAsync(int threadForumId)
        {
            return _threadForumRepository.DeleteByIdAsync(threadForumId);
        }

        public async Task<IEnumerable<ThreadForumDTO>> GetAllAsync()
        {
            IEnumerable<ThreadForum> threadsForum = await _threadForumRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ThreadForumDTO>>(threadsForum);
        }

        public async Task<ThreadForumDTO?> GetByIdAsync(int threadForumId)
        {
            ThreadForum? threadForum = await _threadForumRepository.GetByIdAsync(threadForumId);
            return _mapper.Map<ThreadForumDTO>(threadForum);
        }

        public async Task<ThreadForumDTO?> GetByTitleAsync(string threadForumTitle)
        {
            ThreadForum? threadForum = await _threadForumRepository.GetByTitleAsync(threadForumTitle);
            return _mapper.Map<ThreadForumDTO>(threadForum);
        }

        public async Task<ThreadForumDTO> UpdateAsync(ThreadForumDTO threadForumDTO)
        {
            ThreadForum threadForum = _mapper.Map<ThreadForum>(threadForumDTO);
            ThreadForum threadForumUpdated = await _threadForumRepository.UpdateAsync(threadForum);
            return _mapper.Map<ThreadForumDTO>(threadForumUpdated);
        }
    }
}
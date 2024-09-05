using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using ForumUnifeso.src.API.Repository;
using Microsoft.Extensions.Hosting;

namespace ForumUnifeso.src.API.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository postRepository)
        {
            _repository = postRepository;
        }

        public async Task<Post> AddAsync(Post post)
        {
            return await _repository.AddAsync(post);
        }

        public Task<bool> DeleteAsync(int postId)
        {
           return _repository.DeleteByIdAsync(postId);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Post?> GetByIdAsync(int postId)
        {
            return await _repository.GetByIdAsync(postId);
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            return await _repository.UpdateAsync(post);
        }
    }
}

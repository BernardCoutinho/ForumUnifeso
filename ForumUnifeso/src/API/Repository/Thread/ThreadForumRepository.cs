using ForumUnifeso.src.API.Base;
using ForumUnifeso.src.API.Base.Context;
using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model;
using Microsoft.EntityFrameworkCore;

namespace ForumUnifeso.src.API.Repository
{
    public class ThreadForumRepository : IThreadForumRepository
    {
        private readonly PrincipalDbContext _context;

        public ThreadForumRepository(PrincipalDbContext context)
        {
            _context = context;
        }

        public async Task<ThreadForum> AddAsync(ThreadForum threadForum)
        {
            _context.ThreadForum.Add(threadForum);
            await _context.SaveChangesAsync();
            return threadForum;
        }

        public async Task<bool> DeleteAsync(ThreadForum threadForum)
        {
            _context.ThreadForum.Remove(threadForum);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int threadForumId)
        {
            ThreadForum? threadForum = await GetByIdAsync(threadForumId);

            if (threadForum is not null)
            {
                _context.ThreadForum.Remove(threadForum);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ThreadForum>> GetAllAsync()
        {
            return await _context.ThreadForum.ToListAsync();
        }

        public async Task<ThreadForum?> GetByIdAsync(int threadForumId)
        {
            return await _context.ThreadForum.FindAsync(threadForumId);
        }

        public async Task<ThreadForum?> GetByTitleAsync(string threadForumTitle)
        {
            return await _context.ThreadForum.FirstOrDefaultAsync(threadForum =>
                threadForum.Topic != null && threadForum.Topic.Title == threadForumTitle
            );
        }

        public async Task<ThreadForum> UpdateAsync(ThreadForum threadForum)
        {
            _context.ThreadForum.Update(threadForum);
            await _context.SaveChangesAsync();
            return threadForum;
        }
    }
}

namespace ForumUnifeso.src.API.Interface
{
    using ForumUnifeso.src.API.Base;
    using ForumUnifeso.src.API.View;
    public interface IThreadForumService : IService<ThreadForumDTO, int>
    {
        Task<ThreadForumDTO?> GetByTitleAsync(string threadForumTitle);
    }
}

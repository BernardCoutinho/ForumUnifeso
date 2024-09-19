namespace ForumUnifeso.src.API.Base
{
    public interface IService<TDTO, TId>
    {
        Task<TDTO?> GetByIdAsync(TId id);
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> AddAsync(TDTO dto);
        Task<TDTO> UpdateAsync(TDTO dto);
        Task<bool> DeleteAsync(TDTO dto);
        Task<bool> DeleteByIdAsync(TId id);
    }
}

namespace ForumUnifeso.src.API.Interface.Login
{
    public interface ILoginService
    {
        Task<string> Authenticate(string username, string password);
    }
}

namespace FoodHelper.Logic.Services.Base
{
    public interface IAuthService
    {
        Task<string> Register(string email, string username, string password);
        Task<string> Login(string email, string password);
    }
}

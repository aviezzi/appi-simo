namespace AppiSimo.Client.Abstract
{
    using Model.Auth;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<User> TryLoadUser();
        Task SignIn();
        Task<User> SignedIn();
        Task SignOut();
    }
}
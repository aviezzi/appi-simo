using System.Threading.Tasks;
using AppiSimo.Client.Model.Auth;

namespace AppiSimo.Client.Abstract
{
    public interface IAuthService
    {
        User User { get; }
        
        Task TryLoadUser();
        Task SignIn();
        Task SignedIn();
        Task SignOut();
    }
}
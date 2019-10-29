using System.Threading.Tasks;
using AppiSimo.Client.Model.Auth;

namespace AppiSimo.Client.Abstract
{
    using System.Reactive.Subjects;

    public interface IAuthService
    {
        BehaviorSubject<User> UserSubject { get; }

        Task TryLoadUser();
        Task SignIn();
        Task SignedIn();
        Task SignOut();
    }
}
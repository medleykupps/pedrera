using System.Security.Principal;

namespace Pedrera.Core.Mvc.Security
{
    public interface IWebSecurity<TUser>
    {
        bool IsApplicationLogin { get; }
        bool IsAdministrator { get; }
        bool IsInRole(string role);

        bool IsSignedIn();
        bool SignIn(TUser user);
        bool SignOut();

        AuthoriseResult Authorise();
        AuthoriseResult Authorise(string[] roles, string[] users);

        TUser GetCurrentUser();
    }
}

using System.Security.Principal;

namespace Pedrera.Core.Mvc.Security
{
    public interface IWebSecurity
    {
        IPrincipal CurrentPrincipal { get; }
        bool IsApplicationLogin { get; }
        int? CurrentPrincipalId { get; }
        bool IsAdministrator { get; }
        bool IsInRole(string role);
        bool SignIn(IIdentity identity);
        bool SignIn(string username);
    }
}

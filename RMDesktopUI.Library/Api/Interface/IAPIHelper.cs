using RMDesktopUI.Library.Models.User;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Interface
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }

        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoggedInUserModel> GetLoggedInUserInfo(string token);
    }
}
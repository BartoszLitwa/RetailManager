using Microsoft.AspNet.Identity;
using RMDataManager.Library;
using RMDataManager.Library.DataAccess;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<UserModel> GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return (await data.GetUserById(userId)).First();
        }
    }
}

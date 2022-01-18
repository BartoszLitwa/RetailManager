using Microsoft.AspNet.Identity;
using RMDataManager.Library;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        public async Task<List<UserModel>> GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return await data.GetUserById(userId);
        }
    }
}

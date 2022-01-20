using RMDataManager.Library.Models;
using RMDataManager.Library.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        [HttpPost]
        public async Task Post(SaleModel sale)
        {
            
        }
    }
}

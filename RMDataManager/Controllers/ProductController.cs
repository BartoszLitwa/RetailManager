using RMDataManager.Library.DataAccess;
using RMDataManager.Library.Models.Sale;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: Product
        [HttpGet]
        public async Task<List<ProductModel>> Get()
        {
            ProductData data = new ProductData();

            return await data.GetProductsAsync();
        }
    }
}
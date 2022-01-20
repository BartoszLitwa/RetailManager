using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models.Sale;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class ProductData
    {
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { };

            var output = await sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", p, "RMData");

            return output;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = id };

            var output = await sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", p, "RMData");

            return output.FirstOrDefault();
        }
    }
}

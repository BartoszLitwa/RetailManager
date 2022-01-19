using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}

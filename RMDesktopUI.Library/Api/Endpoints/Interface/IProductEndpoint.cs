using RMDesktopUI.Library.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Endpoints.Interface
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAllAsync();
    }
}
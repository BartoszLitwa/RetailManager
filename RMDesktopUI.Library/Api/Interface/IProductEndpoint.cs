using RMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Interface
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAllAsync();
    }
}
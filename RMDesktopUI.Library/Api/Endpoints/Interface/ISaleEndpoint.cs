using RMDesktopUI.Library.Models.Sale;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Endpoints.Interface
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}
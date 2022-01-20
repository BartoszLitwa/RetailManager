using RMDesktopUI.Library.Api.Endpoints.Interface;
using RMDesktopUI.Library.Api.Interface;
using RMDesktopUI.Library.Models.Sale;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Endpoints
{
    public class SaleEndpoint : ISaleEndpoint
    {
        private IAPIHelper _apiHelper;

        public SaleEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Sale", sale))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Log successfukk cakk
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

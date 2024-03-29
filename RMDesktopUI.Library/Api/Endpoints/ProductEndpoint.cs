﻿using RMDesktopUI.Library.Api.Endpoints.Interface;
using RMDesktopUI.Library.Api.Interface;
using RMDesktopUI.Library.Models.Product;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api.Endpoints
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;

        public ProductEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("api/Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

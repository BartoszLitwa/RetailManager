using RMDataManager.Library.Models;
using RMDataManager.Library.Models.DataBaseModels;
using RMDataManager.Library.Models.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.DataAccess
{
    public class SaleData
    {
        public async Task SaveSale(SaleModel sale)
        {
            // TODO: Make this SOLID/DRY/BETTER
            // Start filling in the model we will save to the database
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();

            for (int i = 0; i < sale.SaleDetails.Count; i++)
            {
                var detail = new SaleDetailDBModel 
                { 
                   ProductId = sale.SaleDetails[i].Id,
                   Quantity = sale.SaleDetails[i].QuantityInrCart
                };

                // Get the information about the product

                details.Add(detail);
            }
            // Fill in the available informartion
            // Save the sale model
            // Get the Id from the sale model
            // Finish Filling in the sale detail models
            // Save the sale detail models
        }
    }
}

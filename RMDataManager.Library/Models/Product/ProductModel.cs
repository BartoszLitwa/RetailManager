using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Models.Sale
{
    public class ProductModel
    {
        /// <summary>
        /// The Unique id of the product
        /// </summary>
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public int TaxId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDataManager.Library.Models.DataBaseModels
{
    public class SaleDBModel
    {
        public string CashierId { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
    }
}

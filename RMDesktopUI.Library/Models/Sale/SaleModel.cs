using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Models.Sale
{
    public class SaleModel
    {
        public List<SaleDetailModel> SaleDetails { get; set; } = new List<SaleDetailModel>();

        public static explicit operator HttpCompletionOption(SaleModel v)
        {
            throw new NotImplementedException();
        }
    }
}

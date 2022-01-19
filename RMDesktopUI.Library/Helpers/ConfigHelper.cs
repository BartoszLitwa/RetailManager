using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["TaxRate"];

            bool isValidTaxRate = double.TryParse(rateText, out double output);

            if (!isValidTaxRate)
            {
                throw new ConfigurationErrorsException("The tax rate is not set up properly");
            }

            return output;
        }

        public string GetTaxRatePercentage()
        {
            return string.Format("{0:P2}", GetTaxRate());
        }
    }
}

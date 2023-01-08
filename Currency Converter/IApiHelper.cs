using Currency_Converter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    public interface IApiHelper
    {
        Task<CurrencyCodeResponseModel> GetCurrencyCode();

        Task<ConversionResponseModel> GetConversion(string cbFrom, string cbTo);
    }
}

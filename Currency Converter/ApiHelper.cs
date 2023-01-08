using Currency_Converter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient httpClient;
        public ApiHelper()
        {
            Initialize();
        }
        private void Initialize()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<CurrencyCodeResponseModel> GetCurrencyCode()
        {
            string API_KEY = "45617e3f3cebbe7ca86b24ed";
            string URL = $"https://v6.exchangerate-api.com/v6/{API_KEY}/codes";
            using (HttpResponseMessage response = await httpClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    CurrencyCodeResponseModel currencyCodeResponseModel = await response.Content.ReadAsAsync<CurrencyCodeResponseModel>();
                    return currencyCodeResponseModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<ConversionResponseModel> GetConversion(string cbFrom, string cbTo)
        {
            string API_KEY = "45617e3f3cebbe7ca86b24ed";
            string URL = $"https://v6.exchangerate-api.com/v6/{API_KEY}/pair/{cbFrom}/{cbTo}";
            using (HttpResponseMessage response = await httpClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    ConversionResponseModel conversionResponseModel = await response.Content.ReadAsAsync<ConversionResponseModel>();
                    return conversionResponseModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

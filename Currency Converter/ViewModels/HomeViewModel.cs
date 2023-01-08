using Caliburn.Micro;
using Currency_Converter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Currency_Converter.ViewModels
{
    public class HomeViewModel: Conductor<object>
    {       
        private IApiHelper _apiHelper;
        private ObservableCollection<ObservableCollection<string>> codesList;
        private ObservableCollection<CurrencyCodeModel> formattedCodesList;
        private double convertedValue;
        private CurrencyCodeModel cbFrom;
        private CurrencyCodeModel cbTo;
        private double convertionRate;
        private ConversionResponseModel conversionResponse;
        private string txtValueToBeConverted;
        private string lastUpdatedDateTime;
        private Visibility chipVisibility;
        private string formattedConvertedValue;
        private string conversionFormula;
        private Boolean isLoading;

        public Boolean IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; NotifyOfPropertyChange(nameof(IsLoading)); }
        }


        public string ConversionFormula
        {
            get { return conversionFormula; }
            set { conversionFormula = value; NotifyOfPropertyChange(nameof(conversionFormula)); }
        }


        public string FormattedConvertedValue
        {
            get { return formattedConvertedValue; }
            set { formattedConvertedValue = value; NotifyOfPropertyChange(nameof(FormattedConvertedValue)); }
        }


        public Visibility ChipVisibility
        {
            get { return chipVisibility; }
            set { chipVisibility = value; NotifyOfPropertyChange(nameof(ChipVisibility)); }
        }


        public string LastUpdatedDateTime
        {
            get { return lastUpdatedDateTime; }
            set { lastUpdatedDateTime = value; NotifyOfPropertyChange(nameof(LastUpdatedDateTime)); }
        }


        public string TxtValueToBeConverted
        {
            get { return txtValueToBeConverted; }
            set { txtValueToBeConverted = value; }
        }


        public ConversionResponseModel ConversionResponse
        {
            get { return conversionResponse; }
            set { conversionResponse = value; }
        }


        public double ConversionRate
        {
            get { return convertionRate; }
            set { convertionRate = value; }
        }


        public CurrencyCodeModel CbTo
        {
            get { return cbTo; }
            set { cbTo = value; }
        }


        public CurrencyCodeModel CbFrom
        {
            get { return cbFrom; }
            set { cbFrom = value; }
        }


        public double ConvertedValue
        {
            get { return convertedValue; }
            set { convertedValue = value; NotifyOfPropertyChange(nameof(ConvertedValue)); }
        }


        public ObservableCollection<CurrencyCodeModel> FormattedCodesList
        {
            get { return formattedCodesList; }
            set { formattedCodesList = value;}
        }

        public CurrencyCodeResponseModel codeResponseModel { get; set; }

 
        public ObservableCollection<ObservableCollection<string>> CodesList
        {
            get { return codesList; }
            set { codesList = value; }
        }


        // constructor
        public HomeViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            codesList = new ObservableCollection<ObservableCollection<string>>();
            formattedCodesList = new ObservableCollection<CurrencyCodeModel>();
            conversionResponse = new ConversionResponseModel();
            ChipVisibility = Visibility.Collapsed;
            IsLoading = false;
            LoadCodeList();
        }

        public async Task LoadCodeList()
        {
            codeResponseModel = await _apiHelper.GetCurrencyCode();
            codesList = codeResponseModel.Supported_Codes;
            foreach (var code in codesList)
            {
                formattedCodesList.Add(new CurrencyCodeModel() { Code = code[0], FullForm = code[1] });
            }
        }

        public async Task ConvertBtnPressed()
        {
            IsLoading = true;
            conversionResponse = await _apiHelper.GetConversion(CbFrom.Code.ToString(), CbTo.Code.ToString());
            
            ConversionRate = Convert.ToDouble(conversionResponse.Conversion_Rate);
            ConvertedValue = Convert.ToDouble(TxtValueToBeConverted) * ConversionRate;
            FormattedConvertedValue = $"{ConvertedValue} {CbTo.FullForm}";
            ConversionFormula = $"1 {CbFrom.Code} = {ConversionRate} {CbTo.Code}";
            LastUpdatedDateTime = conversionResponse.Time_Last_Update_UTC.Substring(0, 16);
            IsLoading= false;
            ChipVisibility = Visibility.Visible;
        }
    }
}

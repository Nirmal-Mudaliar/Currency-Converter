using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class CurrencyCodeResponseModel
    {
		private string result;
		private ObservableCollection<ObservableCollection<string>> supported_codes;

		public ObservableCollection<ObservableCollection<string>> Supported_Codes
        {
			get { return supported_codes; }
			set { supported_codes = value; }
		}

		public string Result
		{
			get { return result; }
			set { result = value; }
		}

	}
}

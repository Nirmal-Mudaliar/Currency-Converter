using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class ConversionResponseModel
    {
		private string result;
		private string time_last_update_utc;
		private string base_code;
		private string target_code;
		private string conversion_rate;

		public string Conversion_Rate
        {
			get { return conversion_rate; }
			set { conversion_rate = value; }
		}


		public string Target_Code
        {
			get { return target_code; }
			set { target_code = value; }
		}


		public string Base_Code
        {
			get { return base_code; }
			set { base_code = value; }
		}


		public string Time_Last_Update_UTC
        {
			get { return time_last_update_utc; }
			set { time_last_update_utc = value; }
		}


		public string Result
		{
			get { return result; }
			set { result = value; }
		}

	}
}

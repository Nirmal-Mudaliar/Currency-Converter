using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class CurrencyCodeModel
    {
		private string code;
		private string fullForm;

		public string FullForm
		{
			get { return fullForm; }
			set { fullForm = value; }
		}


		public string Code
		{
			get { return code; }
			set { code = value; }
		}

	}
}

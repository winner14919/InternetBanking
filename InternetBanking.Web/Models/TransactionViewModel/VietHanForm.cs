using InternetBanking.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBanking.Web.Models.TransactionViewModel
{
	public class VietHanForm : InformationForm
	{
		public override decimal MoneyValue
		{
			get
			{
				return this._moneyvalue;
			}
			set
			{
				if (value >= ValidateCurrency.MinValue("JPY") && value <= ValidateCurrency.MaxValue("JPY"))
					_moneyvalue = value;
			}
		}
	}
}

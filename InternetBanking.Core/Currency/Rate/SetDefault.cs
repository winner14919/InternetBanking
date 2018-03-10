using InternetBanking.Core.Currency.ForeignCurrency;
using InternetBanking.Core.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.Rate
{
    public static class SetDefault
    {
		public static void Set()
		{
			BuyRate<JPY>.ranges.Add(ValidateCurrency.MinValue("JPY"), 293);
			BuyRate<JPY>.ranges.Add(10000, 245);

			SellRate<JPY>.ranges.Add(ValidateCurrency.MinValue("JPY"), 202);
			SellRate<JPY>.ranges.Add(10000, 207);

			BuyRate<KRW>.ranges.Add(ValidateCurrency.MinValue("KRW"), 293);
			BuyRate<KRW>.ranges.Add(100000, 245);

			SellRate<KRW>.ranges.Add(ValidateCurrency.MinValue("KRW"), 202);
			SellRate<KRW>.ranges.Add(100000, 207);

		}
    }
}

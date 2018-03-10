using InternetBanking.Core.Currency.ForeignCurrency;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.Rate
{
	public class SellRate<T> where T : IForeignCurrency
	{
		public static SortedList<decimal, decimal> ranges = new SortedList<decimal, decimal>();

		void Change(KeyValuePair<decimal, decimal> pair)
		{
			SellRate<T>.ranges[pair.Key] = pair.Value;
		}

	}
}

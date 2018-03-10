using InternetBanking.Core.Currency;
using InternetBanking.Core.Currency.ForeignCurrency;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Admin
{
    public static class Resource
    {
		public static Dictionary<string, decimal> resources;

		public static void Init()
		{
			resources = new Dictionary<string, decimal>();
			resources.Add("YachoNhatBan", 10000000);
			resources.Add("NagaBankHanQuoc", 10000000);
			resources.Add("VietinBank", 100000000);
			resources.Add("VietComBank", 1000000000);
			resources.Add("AgriBank", 100000000);
		}

		public static void Change(KeyValuePair<string, decimal> pair)
		{
			resources[pair.Key] = pair.Value;
		}

    }
}

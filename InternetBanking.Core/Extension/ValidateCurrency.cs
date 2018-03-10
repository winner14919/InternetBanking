using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Extension
{
    public static class ValidateCurrency
    {
		public static decimal MinValue(string money)
		{
			switch (money)
			{
				case "JPY":
					return 1000m;
				case "KRW":
					return 10000m;
				default:
					return 0m;
			}
		}

		public static decimal MaxValue(string money)
		{
			switch (money)
			{
				case "JPY":
					return 1000000m;
				case "KRW":
					return 10000000m;
				default:
					return 0m;
			}
		}
    }
}

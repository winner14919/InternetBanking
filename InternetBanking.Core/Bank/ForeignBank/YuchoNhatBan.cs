using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.ForeignBank
{
	public class YuchoNhatBan : ForeignBank
	{
		public string Name => "YachoNhatBan";

		public string Nation => "Japan";

		public string Currency => "JPY";

		public bool IsAvailableAccount(string accountId)
		{
			//
			return true;
		}

		public bool IsValidate(string accountId, string password)
		{
			//
			return true;
		}
	}
}

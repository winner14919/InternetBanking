using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.ForeignBank
{
	public class NagaBankHanQuoc : ForeignBank
	{
		public string Name => "NagaBankHanQuoc";

		public string Nation => "Korea";

		public string Currency => "KRW";

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

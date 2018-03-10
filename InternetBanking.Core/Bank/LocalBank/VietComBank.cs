using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.LocalBank
{
	public class VietComBank : LocalBank
	{
		public override string Name => "VietComBank";

		public override bool IsAvailableAccount(string accountId)
		{
			//
			return true;
		}

		public override bool IsValidate(string accountId, string password)
		{
			//
			return true;
		}
	}
}

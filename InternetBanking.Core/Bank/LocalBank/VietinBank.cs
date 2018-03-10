using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.LocalBank
{
	public class VietinBank : LocalBank
	{
		public override string Name => "VietinBank";

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

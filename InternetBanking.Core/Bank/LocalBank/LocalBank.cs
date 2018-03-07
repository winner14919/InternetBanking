using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.LocalBank
{
	public abstract class LocalBank : IBank
	{
		public abstract string Name { get; }

		public string Nation => "Viet Nam";

		public string Currency => "VND";

		public abstract bool IsAvailableAccount(string accountId);

		public abstract bool IsValidate(string accountId, string password);
	}
}

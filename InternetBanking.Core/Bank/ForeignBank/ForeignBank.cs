using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank.ForeignBank
{
	public abstract class ForeignBank : IBank
	{
		public abstract string Name { get; }

		public abstract string Nation { get; }

		public abstract string Currency { get; }

		public abstract bool IsAvailableAccount(string accountId);

		public abstract bool IsValidate(string accountId, string password);
	}
}

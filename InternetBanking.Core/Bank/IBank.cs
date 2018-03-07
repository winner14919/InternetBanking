using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank
{
    public interface IBank
    {
		string Name { get; }
		string Nation { get; }
		string Currency { get; }
		bool IsAvailableAccount(string accountId);
		bool IsValidate(string accountId, string password);

    }
}

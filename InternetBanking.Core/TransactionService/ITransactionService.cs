using InternetBanking.Core.Bank;
using InternetBanking.Core.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.TransactionService
{
    public interface ITransactionService
    {
		TransactionOrder Order { get; set; }
		IBank SenderBank { get; set; }
		IBank ReceiverBank { get; set; }
		bool IsAvailable();
		void Confirm();
		void Send();
    }
}

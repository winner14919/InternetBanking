using System;
using System.Collections.Generic;
using System.Text;
using InternetBanking.Core.Admin;
using InternetBanking.Core.Bank;
using InternetBanking.Core.Bank.ForeignBank;
using InternetBanking.Core.Bank.LocalBank;
using InternetBanking.Core.Order;

namespace InternetBanking.Core.TransactionService
{
	public class TransferService : ITransactionService
	{
		public TransferService(IRepository<TransactionOrder> repo)
		{
			this._repo = repo;
		}

		private IRepository<TransactionOrder> _repo;

		public IBank SenderBank { get; set; }
		public IBank ReceiverBank { get; set; }

		public TransactionOrder Order { get; set; }

		public bool IsAvailable()
		{
			if (ReceiverBank is LocalBank)
			{
				if (Resource.resources[ReceiverBank.Name] < Order.Value.ChangeToVND(Order.Action).Value)
				{
					return false;
				}
			}
			else
			{
				if (Resource.resources[ReceiverBank.Name] < Order.Value.Value)
				{
					return false;
				}
			}
			return true;
		}

		public void Confirm()
		{
			_repo.Create(Order);
		}

		public void Send()
		{
			//

		}
	}
}

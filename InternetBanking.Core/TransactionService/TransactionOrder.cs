using InternetBanking.Core.Currency;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.TransactionService
{
    public class TransactionOrder
    {
		public Guid Id { get; }
		public string UserId { get; }
		public string SenderAccountId { get; }
		public string SenderName { get; }
		public string ReceiverAccoutId { get; }
		public string ReceiverName { get; }
		public ICurrency Value { get; }
		public ICurrency Fee { get; }
    }
}

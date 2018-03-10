using InternetBanking.Core.Currency;
using InternetBanking.Core.Currency.ForeignCurrency;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InternetBanking.Core.Order
{
    public class TransactionOrder
    {
		public TransactionOrder()
		{
			this.Time = DateTime.Now;
		}

		[Key]
		public int Id { get; set; }
		public string UserId { get; private set; }
		public string SenderAccountId { get; private set; }
		public string SenderName { get; private set; }
		public string ReceiverAccoutId { get; private set; }
		public string ReceiverName { get; private set; }

		[NotMapped]
		public IForeignCurrency Value { get; private set; }

		public ActionTransfer Action { get; private set; }
		public DateTime Time { get; private set; }

		public static TransactionOrder Create(string userId, string senderAccountId,string senderName, string receiverAccountId, string receiverName, IForeignCurrency value, ActionTransfer action)
		{
			var order = new TransactionOrder();
			order.UserId = userId;
			order.SenderAccountId = senderAccountId;
			order.SenderName = senderName;
			order.ReceiverAccoutId = receiverAccountId;
			order.ReceiverName = receiverName;
			order.Value = value;
			order.Action = action;

			return order;
		}

    }
}

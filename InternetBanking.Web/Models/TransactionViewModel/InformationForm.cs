using InternetBanking.Core;
using InternetBanking.Core.Bank;
using InternetBanking.Core.Currency.Rate;
using InternetBanking.Core.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetBanking.Web.Models.TransactionViewModel
{
    public abstract class InformationForm
    {
		protected decimal _moneyvalue;
		protected string _email;


		public string senderbank { get; set; }
		public string receiverbank { get; set; }
		public ActionTransfer action { get; set; }
		public abstract decimal MoneyValue { get; set; }
		public string SenderAccoutId { get; set; }
		public string SenderAccountName { get; set; }
		public string ReceiverAccoutId { get; set; }
		public string ReceiverAccountName { get; set; }
		public string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
			}
		}
		public string Phone { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.ForeignCurrency
{
	public interface IForeignCurrency : ICurrency
	{
		VND ChangeToVND(ActionTransfer action);
	}
}

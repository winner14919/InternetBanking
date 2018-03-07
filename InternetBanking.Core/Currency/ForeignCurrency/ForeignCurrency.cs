using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.ForeignCurrency
{
	public abstract class ForeignCurrency : ICurrency
	{
		public abstract string Name { get; }
		public abstract decimal Value { get; }

		public abstract void ChangeToVND();
	}
}

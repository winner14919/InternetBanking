using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency
{
	public class VND : ICurrency
	{
		public VND(decimal value)
		{
			this.Value = value;
		}
		public string Name => "VND";
		public decimal Value { get; }
	}
}

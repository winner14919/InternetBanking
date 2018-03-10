using InternetBanking.Core.Currency.Rate;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.ForeignCurrency
{
	public class KRW : IForeignCurrency
	{
		public KRW(decimal value)
		{
			this.Value = value;
		}

		public string Name => "KRM";

		public decimal Value { get; set; }

		public VND ChangeToVND(ActionTransfer action)
		{
			switch (action)
			{
				case ActionTransfer.Buy:
					{
						var ranges = BuyRate<KRW>.ranges;
						if (this.Value < ranges.Keys[0])
							return new VND(0);
						for (int i = ranges.Count-1; i>=0; i--)
						{
							if (this.Value >= ranges.Keys[i])
								return new VND(this.Value * ranges.Values[i]);
						}
						return null;
					}

				case ActionTransfer.Sell:
					{
						var ranges = SellRate<KRW>.ranges;
						if (this.Value < ranges.Keys[0])
							return new VND(0);
						for (int i = ranges.Count - 1; i >= 0; i--)
						{
							if (this.Value >= ranges.Keys[i])
								return new VND(this.Value * ranges.Values[i]);
						}
						return null;
					}
				default:
					return null;
			}
		}
	}
}

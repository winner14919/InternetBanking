using InternetBanking.Core.Currency.Rate;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency.ForeignCurrency
{
	public class JPY : IForeignCurrency
	{
		public JPY(decimal value)
		{
			this.Value = value;
		}

		public string Name { get => "JPY"; }

		public decimal Value { get; set; }

		public VND ChangeToVND(ActionTransfer action)
		{
			switch (action)
			{
				case ActionTransfer.Buy:
					{
						var ranges = BuyRate<JPY>.ranges;

						for (int i = ranges.Count-1; i >=0; i--)
						{
							if (this.Value >= ranges.Keys[i])
								return new VND(this.Value * ranges.Values[i]);
						}

						return null;
					}

				case ActionTransfer.Sell:
					{
						var ranges = SellRate<JPY>.ranges;
						if (this.Value < ranges.Keys[0])
							return new VND(0);
						for (int i = ranges.Count-1; i >=0; i--)
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

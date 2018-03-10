using InternetBanking.Core.Bank.ForeignBank;
using InternetBanking.Core.Bank.LocalBank;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Bank
{
    public static class CreateBank
    {
		public static IBank Create(string name)
		{
			switch (name)
			{
				case "VietinBank":
					return new VietinBank();
				case "VietcomBank":
					return new VietComBank();
				case "AgriBank":
					return new AgriBank();
				case "NagaBankHanQuoc":
					return new NagaBankHanQuoc();
				case "YuchoNhatBan":
					return new YuchoNhatBan();
				default:
					return null;
			}
		}

    }
}

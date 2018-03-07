using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Core.Currency
{
    public interface ICurrency
    {
		string Name { get; }
		decimal Value { get;}
    }
}

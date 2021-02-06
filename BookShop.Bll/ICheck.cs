using System;

namespace BookShop.Bll
{
	public interface ICheck
	{
		IShop Shop { get; }
		IBook Book { get; }
		DateTime DateTime { get; }

		void Print();
	}
}

using System;

namespace BookShop.Bll
{
	public interface ICheck
	{
		IShop Shop { get; }
		IBook Book { get; }
		DateTime dateTime { get; }

		void Print();
	}
}

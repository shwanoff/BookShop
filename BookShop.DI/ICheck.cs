using System;

namespace BookShop.DI
{
	public interface ICheck
	{
		IShop Shop { get; set; }
		IBook Book { get; set; }
		DateTime DateTime { get; set; }
	}
}

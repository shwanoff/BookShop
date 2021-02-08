using System.Collections.Generic;

namespace BookShop.DI
{
	public interface IShop
	{
		string Name { get; set; }
		string Address { get; set; }

		void Add(IBook book);
		IEnumerable<IBook> GetAllBooks();
		ICheck Sell(IBook book);
	}
}

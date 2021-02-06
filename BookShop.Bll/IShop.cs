using System.Collections.Generic;

namespace BookShop.Bll
{
	public interface IShop
	{
		string Name { get; }
		string Address { get; }

		void Add(IBook book);
		IEnumerable<IBook> GetAllBooks();
		ICheck Sell(IBook book);
	}
}

using BookShop.DI;
using System.Collections.Generic;

namespace BookShop.Data.Memory
{
	public class BookMemoryData : IData<IBook>
	{
		private readonly List<IBook> _books;

		public BookMemoryData()
		{
			_books = new List<IBook>();
		}

		public void Add(IBook item)
		{
			_books.Add(item);
		}

		public IEnumerable<IBook> ReadAll()
		{
			return _books;
		}

		public void Remove(IBook item)
		{
			_books.Remove(item);
		}
	}
}

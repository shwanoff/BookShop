using BookShop.Bll;
using System.Collections.Generic;

namespace BookShop.Data.Memory
{
	public class InMemoryData : IData<IBook>, IData<ICheck>
	{
		private readonly List<IBook> _books;
		private readonly List<ICheck> _checks;

		public InMemoryData()
		{
			_books = new List<IBook>();
			_checks = new List<ICheck>();
		}

		public void Add(ICheck item)
		{
			_checks.Add(item);
		}

		public void Add(IBook item)
		{
			_books.Add(item);
		}

		public IEnumerable<ICheck> ReadAll()
		{
			return _checks;
		}

		IEnumerable<IBook> IData<IBook>.ReadAll()
		{
			return _books;
		}
	}
}

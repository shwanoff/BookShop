using BookShop.DI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Bll
{
	public class Shop : IShop
	{
		private readonly IData<IBook> _bookData;
		private readonly IData<ICheck> _checkData;

		public string Name { get; set; }
		public string Address { get; set; }

		public Shop(IData<IBook> bookData, IData<ICheck> checkData)
		{
			_bookData = bookData ?? throw new ArgumentNullException(nameof(bookData));
			_checkData = checkData ?? throw new ArgumentNullException(nameof(checkData));
		}

		public void Add(IBook book)
		{
			_bookData.Add(book);
		}

		public IEnumerable<IBook> GetAllBooks()
		{
			return _bookData.ReadAll();
		}

		public ICheck Sell(IBook book)
		{
			_bookData.Remove(book);

			var check = new Check()
			{
				Book = book,
				Shop = this,
				DateTime = DateTime.Now
			};

			_checkData.Add(check);
			return check;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

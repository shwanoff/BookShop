using System;
using System.Collections.Generic;

namespace BookShop.Bll
{
	public class Shop : IShop
	{
		private readonly IData<IBook> _bookData;
		private readonly IData<ICheck> _checkData;

		public string Name { get; }
		public string Address { get; }

		public Shop(string name, string address, IData<IBook> bookData, IData<ICheck> checkData)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));

			_bookData = bookData ?? throw new ArgumentNullException(nameof(bookData));
			_checkData = checkData ?? throw new ArgumentNullException(nameof(checkData));

			Name = name;
			Address = address;
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
			var check = new Check(this, book);
			_checkData.Add(check);
			return check;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

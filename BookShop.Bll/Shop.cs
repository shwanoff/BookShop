using System;
using System.Collections.Generic;

namespace BookShop.Bll
{
	public class Shop : IShop
	{
		public string Name { get; }
		public string Address { get; }

		public Shop(string name, string address)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(address)) throw new ArgumentNullException(nameof(address));

			Name = name;
			Address = address;
		}

		public void Add(IBook book)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IBook> GetAllBooks()
		{
			throw new NotImplementedException();
		}

		public ICheck Sell(IBook book)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}

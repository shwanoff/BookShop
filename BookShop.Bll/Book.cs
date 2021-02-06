using System;

namespace BookShop.Bll
{
	public class Book : IBook
	{
		public string Name { get; }
		public string Author { get; }
		public int Price { get; }

		public Book(string name, string author, int price)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(author)) throw new ArgumentNullException(nameof(author));
			if (price < 0) throw new ArgumentException("Price < 0", nameof(price));

			Name = name;
			Author = author;
			Price = price;
		}

		public override string ToString()
		{
			return $"{Author} {Name}";
		}
	}
}

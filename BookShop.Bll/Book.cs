using BookShop.DI;
using System;

namespace BookShop.Bll
{
	public class Book : IBook
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public int Price { get; set; }

		public override string ToString()
		{
			return $"{Author} {Name}";
		}
	}
}

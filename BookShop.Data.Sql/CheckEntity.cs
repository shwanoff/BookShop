using BookShop.DI;
using System;

namespace BookShop.Data.Sql
{
	public class CheckEntity : ICheck
	{
		public int Id { get; set; }
		public string ShopName { get; set; }
		public string BookName { get; set; }
		public IShop Shop { get; set; }
		public IBook Book { get; set; }
		public DateTime DateTime { get; set; }

		public CheckEntity() { }

		public CheckEntity(ICheck item)
		{
			Id = 0;
			Shop = item.Shop;
			ShopName = item.Shop.Name;
			Book = item.Book;
			BookName = item.Book.Name;
			DateTime = item.DateTime;
		}

		public override string ToString()
		{
			return DateTime.ToString();
		}
	}
}

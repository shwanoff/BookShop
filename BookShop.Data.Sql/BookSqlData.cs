using BookShop.DI;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Data.Sql
{
	public class BookSqlData : IData<IBook>
	{
		public void Add(IBook item)
		{
			using(var db = new BookShopContext())
			{
				var book = new BookEntity(item);
				db.Books.Add(book);
				db.SaveChanges();
			}
		}

		public IEnumerable<IBook> ReadAll()
		{
			using (var db = new BookShopContext())
			{
				return db.Books.ToList();
			}
		}

		public void Remove(IBook item)
		{
			using (var db = new BookShopContext())
			{
				var book = db.Books.SingleOrDefault(b => b.Author.Equals(item.Author) &&
					b.Name.Equals(item.Name) &&
					b.Price.Equals(item.Price));
				db.Books.Remove(book);
				db.SaveChanges();
			}
		}
	}
}

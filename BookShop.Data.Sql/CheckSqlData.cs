using BookShop.DI;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Data.Sql
{
	public class CheckSqlData : IData<ICheck>
	{
		public void Add(ICheck item)
		{
			using(var db = new BookShopContext())
			{
				var check = new CheckEntity(item);
				db.Checks.Add(check);
				db.SaveChanges();
			}
		}

		public IEnumerable<ICheck> ReadAll()
		{
			using (var db = new BookShopContext())
			{
				return db.Checks.ToList();
			}
		}

		public void Remove(ICheck item)
		{
			using (var db = new BookShopContext())
			{
				var check = new CheckEntity(item);
				db.Checks.Remove(check);
				db.SaveChanges();
			}
		}
	}
}

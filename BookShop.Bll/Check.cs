using System;

namespace BookShop.Bll
{
	public class Check : ICheck
	{
		public IShop Shop { get; }
		public IBook Book { get; }
		public DateTime DateTime { get; }

		public Check(IShop shop, IBook book)
		{
			Shop = shop ?? throw new ArgumentNullException(nameof(shop));
			Book = book ?? throw new ArgumentNullException(nameof(book));

			DateTime = DateTime.Now;
		}

		public void Print()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return DateTime.ToString();
		}
	}
}

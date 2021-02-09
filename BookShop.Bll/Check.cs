using BookShop.DI;
using System;

namespace BookShop.Bll
{
	public class Check : ICheck
	{
		public IShop Shop { get; set; }
		public IBook Book { get; set; }
		public DateTime DateTime { get; set; }

		public override string ToString()
		{
			return DateTime.ToString();
		}
	}
}

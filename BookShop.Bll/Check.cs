using BookShop.DI;
using System;

namespace BookShop.Bll
{
	public class Check : ICheck
	{
		public IShop Shop { get; set; }
		public IBook Book { get; set; }
		public DateTime DateTime { get; set; }

		public string Print()
		{
			return $"Новая продажа в магазине {Shop.Name}\r\n" +
				   $"по адресу {Shop.Address}\r\n" +
				   $"{DateTime}\r\n\r\n" +
				   $"Наименование товара: {Book}\r\n" +
				   $"Стоимость: {Book.Price}₽\r\n";
		}

		public override string ToString()
		{
			return DateTime.ToString();
		}
	}
}

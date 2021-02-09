using BookShop.DI;
using BookShop.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.App.Cmd
{
	partial class Program
	{
		#region DI - Внедрение зависимости
		private static Configuration _configuration;

		private static IBook CreateBook(string name, string author, int price)
		{
			var book = _configuration.Container.GetInstance<IBook>();
			book.Author = author;
			book.Name = name;
			book.Price = price;

			var shop = _configuration.Container.GetInstance<IShop>();
			shop.Add(book);

			return book;
		}

		private static ICheck CreateCheck(IBook book)
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			var check = shop.Sell(book);

			return check;
		}

		private static IShop CreateShop(string name, string address)
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			shop.Name = name;
			shop.Address = address;

			return shop;
		}

		private static IEnumerable<IBook> GetAllBooks()
		{
			var shop = _configuration.Container.GetInstance<IShop>();
			var books = shop.GetAllBooks();

			return books;
		}
		#endregion

		static void Main(string[] args)
		{
			try
			{
				_configuration = new Configuration();

				var shop = CreateShop("Black Books", "13 Little Bevan Street, Bloomsbury, London");

				Console.OutputEncoding = Encoding.UTF8;
				Console.WriteLine("Добрый день. Добро пожаловать в панель управления магазином");
				Console.WriteLine("Пожалуйста, введите нужную команду или help для помощи");
				Console.WriteLine();

				while(true)
				{
					switch(ReadCommand())
					{
						case Command.Exit:
							Environment.Exit(0);
							break;
						case Command.Help:
							WriteHelpMessage();
							break;
						case Command.AddBook:
							AddBook();
							break;
						case Command.GetAllBooks:
							ShowAllBooks();
							break;
						case Command.SellBook:
							SellBook();
							break;
						default:
							WriteErrorMessage("Не обрабатываемая команда. Свяжитесь с разработчиком");
							break;
					}
				}
			}
			catch(Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				Console.ReadLine();
			}
		}

		private static void AddBook()
		{
			Console.WriteLine("Добавление новой книги");

			var author = ReadNotEmptyLine("Имя автора");
			var name = ReadNotEmptyLine("Название книги");
			var price = ReadIntLine("Стоимость книги");

			var book = CreateBook(name, author, price) ?? throw new Exception("Ошибка при добавлении книги");

			Console.WriteLine($"Книга [{book}] успешно добавлена");
			Console.WriteLine();
		}

		private static void ShowAllBooks()
		{
			Console.WriteLine("Список всех доступных в магазине книг:");

			var books = GetAllBooks();
			foreach (var book in books)
			{
				Console.WriteLine($"\t{book}");
			}
			Console.WriteLine();
		}

		private static void SellBook()
		{
			Console.WriteLine("Новая продажа книги");

			IBook book;
			while (true)
			{
				var name = ReadNotEmptyLine("Название книги");
				var books = GetAllBooks();
				var result = books.FirstOrDefault(b => b.Name.Equals(name));

				if(result != null)
				{
					book = result;
					break;
				}

				WriteErrorMessage("Данная книга не найдена");
			}

			var check = CreateCheck(book);
			Console.WriteLine($"Новая продажа в магазине {check.Shop.Name}");
			Console.WriteLine($"по адресу {check.Shop.Address}");
			Console.WriteLine($"{check.DateTime}");
			Console.WriteLine($"Наименование товара: {check.Book}");
			Console.WriteLine($"Стоимость: {check.Book.Price}₽");
			Console.WriteLine();
		}
	}
}

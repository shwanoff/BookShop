using BookShop.Bll;
using BookShop.Data.Memory;
using System;
using System.Linq;
using System.Text;

namespace BookShop.App.Cmd
{
	partial class Program
	{
		#region DI - Внедрение зависимости
		private static IBook CreateBook(string name, string author, int price)
		{
			var book = new Book(name, author, price);
			return book;
		}

		private static ICheck CreateCheck(IShop shop, IBook book)
		{
			var check = new Check(shop, book);
			return check;
		}

		private static IShop CreateShop(string name, string address)
		{
			var data = new InMemoryData();

			var shop = new Shop(name, address, data, data);
			return shop;
		}
		#endregion

		static void Main(string[] args)
		{
			try
			{
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
							AddBook(shop);
							break;
						case Command.GetAllBooks:
							GetAllBooks(shop);
							break;
						case Command.SellBook:
							SellBook(shop);
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

		private static void AddBook(IShop shop)
		{
			Console.WriteLine("Добавление новой книги");

			var author = ReadNotEmptyLine("Имя автора");
			var name = ReadNotEmptyLine("Название книги");
			var price = ReadIntLine("Стоимость книги");

			var book = CreateBook(name, author, price) ?? throw new Exception("Ошибка при добавлении книги");

			shop.Add(book);
			Console.WriteLine("Книга успешно добавлена");
			Console.WriteLine();
		}

		private static void GetAllBooks(IShop shop)
		{
			Console.WriteLine("Список всех доступных в магазине книг:");

			var books = shop.GetAllBooks();
			foreach(var book in books)
			{
				Console.WriteLine($"\t{book}");
			}
			Console.WriteLine();
		}

		private static void SellBook(IShop shop)
		{
			Console.WriteLine("Новая продажа книги");

			IBook book;
			while (true)
			{
				var name = ReadNotEmptyLine("Название книги");
				var books = shop.GetAllBooks();
				var result = books.FirstOrDefault(b => b.Name.Equals(name));

				if(result != null)
				{
					book = result;
					break;
				}

				WriteErrorMessage("Данная книга не найдена");
			}

			var check = CreateCheck(shop, book);
			check.Print();
			Console.WriteLine();
		}
	}
}

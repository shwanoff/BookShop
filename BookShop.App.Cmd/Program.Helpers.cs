using System;

namespace BookShop.App.Cmd
{
	partial class Program
	{
		private static string ReadNotEmptyLine(string title)
		{
			while (true)
			{
				Console.Write($"Введите {title}: ");
				var input = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(input))
				{
					return input;
				}

				WriteErrorMessage($"Значение {title} не должен быть пустым");
			}
		}

		private static int ReadIntLine(string title)
		{
			while (true)
			{
				var input = ReadNotEmptyLine(title);
				if (int.TryParse(input, out int result))
				{
					return result;
				}

				WriteErrorMessage($"Введите целое число");
			}
		}

		private static void WriteErrorMessage(string message)
		{
			var color = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"ОШИБКА! {message}");
			Console.ForegroundColor = color;
		}

		private static Command ReadCommand()
		{
			while (true)
			{
				var input = ReadNotEmptyLine("команду");
				if (Enum.TryParse(input, true, out Command command))
				{
					return command;
				}

				WriteErrorMessage("Не известная команда. Введите help для подсказки");
			}
		}

		private static void WriteHelpMessage()
		{
			Console.WriteLine($"{Command.AddBook} - Добавить новую книгу;");
			Console.WriteLine($"{Command.GetAllBooks} - Вывести полный список доступных книг;");
			Console.WriteLine($"{Command.SellBook} - Продать книгу;");
			Console.WriteLine($"{Command.Exit} - Выход из приложения;");
			Console.WriteLine($"{Command.Help} - Помощь;");
			Console.WriteLine();
		}
	}
}

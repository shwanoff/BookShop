using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookShop.Data.Sql;
using System.Linq;
using BookShop.Data.Memory;

namespace BookShop.Bll.Tests
{
	[TestClass()]
	public class ShopTests
	{
		[TestMethod(), TestCategory("Integration")]
		public void Sell_NewBook_CheckCreatedInDb()
		{
			// Arrange
			var bookData = new BookSqlData();
			var checkData = new CheckSqlData();
			var shop = new Shop(bookData, checkData);

			var book = new Book
			{
				Author = "TestAuthor",
				Name = "TestName",
				Price = 100
			};

			// Act
			shop.Add(book);
			var books = shop.GetAllBooks().ToList() ;
			var check = shop.Sell(book);

			// Assert
			Assert.IsNotNull(books);
			Assert.IsNotNull(check);
		}

		[TestMethod(), TestCategory("Unit")]
		public void Sell_NewBook_CheckCreatedInMemory()
		{
			// Arrange
			var bookData = new BookMemoryData();
			var checkData = new CheckMemoryData();
			var shop = new Shop(bookData, checkData);

			var book = new Book
			{
				Author = "TestAuthor",
				Name = "TestName",
				Price = 100
			};

			// Act
			shop.Add(book);
			var books = shop.GetAllBooks().ToList();
			var check = shop.Sell(book);

			// Assert
			Assert.IsNotNull(books);
			Assert.IsNotNull(check);
		}
	}
}
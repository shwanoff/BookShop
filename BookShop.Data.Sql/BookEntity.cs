using BookShop.DI;

namespace BookShop.Data.Sql
{
	public class BookEntity : IBook
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int Price { get; set; }

		public BookEntity() { }

		public BookEntity(IBook item)
		{
			Id = 0;
			Name = item.Name;
			Author = item.Author;
			Price = item.Price;
		}

		public override string ToString()
		{
			return $"{Author} {Name}";
		}
	}
}

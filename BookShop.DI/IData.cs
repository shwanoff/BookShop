using System.Collections.Generic;
namespace BookShop.DI
{
	public interface IData<T>
	{
		IEnumerable<T> ReadAll();
		void Add(T item);
		void Remove(T item);
	}
}

using System.Collections.Generic;
namespace BookShop.Bll
{
	public interface IData<T>
	{
		IEnumerable<T> ReadAll();
		void Add(T item);
	}
}

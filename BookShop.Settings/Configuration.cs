using BookShop.Bll;
using BookShop.Data.Memory;
using BookShop.Data.Sql;
using BookShop.DI;
using SimpleInjector;

namespace BookShop.Settings
{
	public class Configuration
	{
		public Container Container { get; }

		public Configuration()
		{
			Container = new Container();

			Setup();
		}

		public virtual void Setup()
		{
			Container.Register<IBook, Book>(Lifestyle.Transient);
			Container.Register<ICheck, Check>(Lifestyle.Transient);
			Container.Register<IShop, Shop>(Lifestyle.Singleton);
			Container.Register<IData<IBook>, BookSqlData>(Lifestyle.Singleton);
			Container.Register<IData<ICheck>, CheckSqlData>(Lifestyle.Singleton);
		}
	}
}

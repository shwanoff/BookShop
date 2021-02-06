namespace BookShop.Bll
{
    public interface IBook
    {
        string Name { get; }
        string Author { get; }
        int Price { get; }
    }
}

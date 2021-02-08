namespace BookShop.DI
{
    public interface IBook
    {
        string Name { get; set; }
        string Author { get; set; }
        int Price { get; set; }
    }
}

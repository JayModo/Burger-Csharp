namespace BurgerShack.Interfaces
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
    }
}
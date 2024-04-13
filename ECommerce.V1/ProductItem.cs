namespace ECommerce.V1;

public class ProductItem : IComparable
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Id => this.GetHashCode();

    public ProductItem(string? name, decimal price, string? description)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    // public override string ToString()
    // {
    //     return $"{Name}\t{Price:C0}"
    //          + $"\n--> {Description}";
    // }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public int CompareTo(object? obj)
    {
        if (obj is ProductItem other)
            return Name.CompareTo(other.Name);
        return 0;
    }
}

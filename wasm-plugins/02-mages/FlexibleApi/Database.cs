public class Database
{
    public List<Product> Products { get; set; }

    public Database()
    {
        // Seed with sample data
        Products =
        [
            new Product { Id = 1, Name = "Laptop", Price = 999.99 },
            new Product { Id = 2, Name = "Phone", Price = 599.49 },
            new Product { Id = 3, Name = "Keyboard", Price = 49.99 }
        ];
    }

    public int AddProduct(string name, double price)
    {
        var id = Products.Count + 1;
        Products.Add(new Product
        {
            Id = id,
            Name = name,
            Price = price
        });
        return id;
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

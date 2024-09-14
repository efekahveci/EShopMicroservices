namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if(await session.Query<Product>().AnyAsync(cancellation))
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);

    }
    private static List<Product> GetPreconfiguredProducts()
    {
        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Category, f => [f.Commerce.Department()])
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.ImageFile, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(10, 1000)));

        return productFaker.Generate(20);
    }
}

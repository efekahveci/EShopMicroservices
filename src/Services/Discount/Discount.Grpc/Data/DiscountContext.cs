using Bogus;

namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(GetPreconfiguredDiscount());
    }

    private static List<Coupon> GetPreconfiguredDiscount()
    {
        var couponFaker = new Faker<Coupon>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Amount, f => f.Random.Int(10, 100));

        return couponFaker.Generate(20);
    }
}

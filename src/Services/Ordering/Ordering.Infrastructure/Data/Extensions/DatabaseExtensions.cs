using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;
namespace Ordering.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitializeDbAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();

        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();

        var customers = GetPreconfiguredCustomers();
        var products = GetPreconfiguredProducts();

        await AddDataAsync(context.Customers, () => customers);
        await AddDataAsync(context.Products, () => products);

        var orders = GetPreconfiguredOrders(customers);
        await AddDataAsync(context.Orders, () => orders);

        var orderItems = GetPreconfiguredOrderItems(orders, products);
        await AddDataAsync(context.OrderItems, () => orderItems);

        await context.SaveChangesAsync();
    }

    private static async Task AddDataAsync<T>(DbSet<T> dbSet, Func<List<T>> getPreconfiguredData) where T : class
    {
            var data = getPreconfiguredData();
            await dbSet.AddRangeAsync(data);
    }

    private static List<Customer> GetPreconfiguredCustomers()
    {
        return new Faker<Customer>()
            .RuleFor(o => o.Id, f => CustomerId.Of(Guid.NewGuid()))
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .Generate(10);
    }

    private static List<Product> GetPreconfiguredProducts()
    {
        return new Faker<Product>()
            .RuleFor(p => p.Id, f => ProductId.Of(Guid.NewGuid()))
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(10, 1000)))
            .Generate(20);
    }

    private static List<Order> GetPreconfiguredOrders(List<Customer> customers)
    {
        return new Faker<Order>()
            .RuleFor(o => o.Id, f => OrderId.Of(Guid.NewGuid()))
            .RuleFor(o => o.CustomerId, f => customers[f.Random.Number(0, customers.Count - 1)].Id)
            .RuleFor(o => o.OrderName, f => OrderName.Of(f.Random.AlphaNumeric(5)))
            .RuleFor(o => o.ShippingAddress, f => Address.Of(
                f.Name.FirstName(),
                f.Name.LastName(),
                f.Internet.Email(),
                f.Address.StreetAddress(),
                f.Address.Country(),
                f.Address.State(),
                f.Address.ZipCode()[..5]))
            .RuleFor(o => o.BlingAddress, f => Address.Of(
                f.Name.FirstName(),
                f.Name.LastName(),
                f.Internet.Email(),
                f.Address.StreetAddress(),
                f.Address.Country(),
                f.Address.State(),
                f.Address.ZipCode()[..5]))
            .RuleFor(o => o.Payment, f => Payment.Of(
                f.Name.FullName(),
                f.Finance.CreditCardNumber(),
                f.Random.String2(3, "0123456789"),
                f.Date.Future().ToString("MM/yy"),
                f.Random.Number(1, 3)
            ))
            .RuleFor(o => o.Status, f => OrderStatus.Pending)
            .Generate(10);
    }




    private static List<OrderItem> GetPreconfiguredOrderItems(List<Order> orders, List<Product> products)
    {
        return new Faker<OrderItem>()
            .RuleFor(oi => oi.Id, f => OrderItemId.Of(Guid.NewGuid()))
            .RuleFor(oi => oi.OrderId, f => orders[f.Random.Number(0, orders.Count - 1)].Id)
            .RuleFor(oi => oi.ProductId, f => products[f.Random.Number(0, products.Count - 1)].Id)
            .RuleFor(oi => oi.Quantity, f => f.Random.Number(1, 5))
            .RuleFor(oi => oi.Price, f => decimal.Parse(f.Commerce.Price(10, 500)))
            .Generate(50);
    }

}

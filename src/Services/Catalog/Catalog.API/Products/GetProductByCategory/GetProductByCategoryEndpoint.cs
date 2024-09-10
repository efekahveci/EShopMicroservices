namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryRequest(string Category) : IQuery<GetProductByCategoryResponse>;
public record GetProductByCategoryResponse(IEnumerable<Product> Products);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string Category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(Category));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
            .WithName("GetProductByCategory")
            .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Products by Category")
            .WithDescription("Get all products by category.");
    }
}

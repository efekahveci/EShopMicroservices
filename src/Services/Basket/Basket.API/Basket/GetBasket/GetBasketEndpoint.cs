namespace Basket.API.Basket.GetBasket;

public record GetBasketRequest(string UserName);
public record GetBasketResponse(ShoppingCart ShoppingCart);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName), ct);
            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
            .WithName("GetBasket")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Retrieves the shopping cart for the specified user.")
            .WithDescription("Retrieves the shopping cart for the specified user.");


    }
}

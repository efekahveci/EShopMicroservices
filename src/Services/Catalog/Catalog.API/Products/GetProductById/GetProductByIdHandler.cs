namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Guid) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting product by id {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Guid, cancellationToken);

        return product is not null ? new GetProductByIdResult(product) : throw new ProductNotFoundException(query.Guid);
    }
}


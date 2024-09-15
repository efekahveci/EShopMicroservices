namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotNull().WithMessage("Username is required");
    }
}

public class DeleteBasketCommandHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    // Dependency Injection for database or cache can be done here
    public Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // Simulate deleting the basket logic
        // Example: database.RemoveBasket(command.UserName);

        var isDeleted = true; // Assume the deletion is successful for this example

        return Task.FromResult(new DeleteBasketResult(isDeleted));
    }
}

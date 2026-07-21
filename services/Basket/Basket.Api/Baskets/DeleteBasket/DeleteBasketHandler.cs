using Basket.Api.Data;

namespace Basket.Api.Baskets.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);
public class DeleteBasketHandler 
    (IBasketRepository repository,ILogger<DeleteBasketHandler> logger)
    : ICommandHandler<DeleteBasketCommand,DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken=default)
    {
        logger.LogInformation("this is request.UserName : {@request}", request.UserName);
        await repository.DeleteBasket(request.UserName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}

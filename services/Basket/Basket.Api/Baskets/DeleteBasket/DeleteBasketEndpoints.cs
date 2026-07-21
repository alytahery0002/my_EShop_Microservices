using Mapster;

namespace Basket.Api.Baskets.DeleteBasket;

//public record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(bool IsSuccess);

public class DeleteBasketEndpoints  :ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app) 
    {
        app.MapDelete("/DeleteBasket/{userName}", async (string UserName ,ISender sender ) =>
        {
            var result = await sender.Send(new DeleteBasketCommand(UserName));
            var response = result.Adapt<DeleteBasketResponse>();

            return response;
        });
    }
}

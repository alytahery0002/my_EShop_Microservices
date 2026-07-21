using Mapster;

namespace Basket.Api.Baskets.GetBasket;

//public record GetBasketReuest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoints: ICarterModule

{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/GetBasket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response); ;

        });
    }
}

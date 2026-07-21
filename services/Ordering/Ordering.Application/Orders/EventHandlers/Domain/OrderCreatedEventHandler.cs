using MassTransit;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler 
    (IPublishEndpoint publishEndpoint, ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent orderCreatedEvent,CancellationToken cancellationToken) 
    {
        logger.LogInformation("Domain event Handle: {DomainEvent}", orderCreatedEvent.GetType().Name);

        var orderCreatedIntegrationEvent = orderCreatedEvent.order.ToOrderDto();
        await publishEndpoint.Publish(orderCreatedEvent,cancellationToken);

    }
}

using MediatR;
using OrderManagement.Data;
using OrderManagement.Models;


namespace OrderManagement.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly WriteDbContext _writeContext;

        public CreateOrderCommandHandler(WriteDbContext writeContext)
        {
            _writeContext = writeContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(0, request.CustomerId, request.Items);
            _writeContext.Orders.Add(order);
            await _writeContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}

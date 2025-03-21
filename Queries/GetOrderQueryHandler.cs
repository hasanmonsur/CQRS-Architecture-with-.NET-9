using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Queries
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly ReadDbContext _readContext;

        public GetOrderQueryHandler(ReadDbContext readContext)
        {
            _readContext = readContext;
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _readContext.OrderDtos.FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
            return order ?? throw new Exception("Order not found");
        }
    }
}

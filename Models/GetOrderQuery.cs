using MediatR;

namespace OrderManagement.Models
{
    public record GetOrderQuery(int OrderId) : IRequest<OrderDto>;
}

using MediatR;

namespace OrderManagement.Commands
{
    // Commands/CreateOrderCommand.cs

    public record CreateOrderCommand(int CustomerId, List<string> Items) : IRequest<int>;

}

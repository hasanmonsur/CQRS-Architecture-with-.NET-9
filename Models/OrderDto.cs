namespace OrderManagement.Models
{

    public record OrderDto(int Id, int CustomerId, int ItemCount, DateTime CreatedAt);

}

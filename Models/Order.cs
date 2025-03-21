namespace OrderManagement.Models
{
    public record Order(int Id, int CustomerId, List<string> Items);
}

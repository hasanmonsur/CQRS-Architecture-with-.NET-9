using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Commands;
using OrderManagement.Data;
using OrderManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<WriteDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WriteConnection")));
builder.Services.AddDbContext<ReadDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ReadConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Endpoints
app.MapPost("/orders", async (IMediator mediator, CreateOrderCommand command) =>
{
    var orderId = await mediator.Send(command);
    // Simulate syncing read model (in practice, use events or a background job)
    var writeContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<WriteDbContext>();
    var readContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ReadDbContext>();
    var order = await writeContext.Orders.FindAsync(orderId);
    readContext.OrderDtos.Add(new OrderDto(orderId, order.CustomerId, order.Items.Count, DateTime.UtcNow));
    await readContext.SaveChangesAsync();
    return Results.Created($"/orders/{orderId}", new { OrderId = orderId });
});

app.MapGet("/orders/{id}", async (IMediator mediator, int id) =>
{
    var order = await mediator.Send(new GetOrderQuery(id));
    return Results.Ok(order);
});


app.Run();

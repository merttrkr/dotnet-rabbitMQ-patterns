using BasketService.Infrastructure.Persistence;
using BasketService.Infrastructure.Persistence.Repositories;
using BasketService.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PSQLServer")));

builder.Services.AddScoped<IBasketRepository,BasketRepository>();
builder.Services.AddScoped<IBasketItemRepository,BasketItemRepository>();
//builder.Services.AddMassTransit(x =>
//{
//    x.AddConsumer<AddedToBasketConsumer>();

//    x.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host("localhost", h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });

//        cfg.ReceiveEndpoint("basket-service", e =>
//        {
//            e.ConfigureConsumer<AddedToBasketConsumer>(context);
//        });
//    });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

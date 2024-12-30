using CoffeeShop.Application.Services;
using CoffeeShop.Core.Interfaces;
using CoffeeShop.GraphQL.Mutations.Orders;
using CoffeeShop.GraphQL.Queries;
using CoffeeShop.Infrastructure;
using CoffeeShop.Infrastructure.Context;
using GraphQL.Mutations.Products;
using GraphQL.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://studio.apollographql.com", "http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<CoffeeContext>();

builder.Services.AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<ProductQueries>()
    .AddTypeExtension<OrderQueries>()
    .AddMutationType(d => d.Name("Mutation"))
    .AddTypeExtension<ProductMutations>()
    .AddTypeExtension<OrderMutations>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();
app.MapGraphQLVoyager();

app.Run();

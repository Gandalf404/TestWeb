using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using TestAPI.Converters;
using TestAPI.Interfaces;
using TestAPI.Models;
using TestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options => 
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
// });
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
    options.MapType<DateOnly>(() => new OpenApiSchema 
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2024-09-01")
    }));
builder.Services.AddDbContext<InvoicesContext>(options => 
{
    options.UseNpgsql("Server=127.0.0.1;Database=invoices;Username=postgres;Password=mclooter131;");
});
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IKitRepository, KitRepository>();
builder.Services.AddScoped<IPartRepository, PartRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
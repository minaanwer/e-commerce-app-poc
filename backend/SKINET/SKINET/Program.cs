using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
//var logger = services.GetRequiredService<ILogger>();
    try
    {
      await context.Database.MigrateAsync();
      await  StoreContextSeed.SeedAsync(context);
    }
    catch(Exception ex)
    {
     // logger.LogError(ex, "error ocurred during migration");
    }

app.Run();
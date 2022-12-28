using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PRUEBA_ANARContext>(options =>
{
    options.UseSqlServer("Data Source=JAVB2807;Initial Catalog=PRUEBA_ANAR;Persist Security Info=True;User ID=sa;Password=123;MultipleActiveResultSets=true");
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var contect = scope.ServiceProvider.GetRequiredService<PRUEBA_ANARContext>();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

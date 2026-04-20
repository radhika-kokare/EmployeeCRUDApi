using EmployeeCRUDApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services
builder.Services.AddControllers();

// ✅ Swagger (important)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Database (choose one)

// 👉 Option 1: InMemory DB (easy for testing)
builder.Services.AddDbContext<CrudDemoDbContext>(options =>
    options.UseInMemoryDatabase("CrudDemoDB"));

/*
// 👉 Option 2: SQL Server (real database)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
*/

var app = builder.Build();

// ✅ Middleware pipeline

// Swagger should be enabled
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
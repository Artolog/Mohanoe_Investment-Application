using Microsoft.EntityFrameworkCore;
using MIP_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext (VERY important for migrations)
builder.Services.AddDbContext<MIPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MIP_DB")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();



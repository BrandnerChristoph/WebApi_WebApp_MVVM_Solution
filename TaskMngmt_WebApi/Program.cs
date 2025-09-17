using Microsoft.EntityFrameworkCore;
using TaskMngmt_WebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    builder.Services.AddDbContext<TaskItemDbContext>(x => x.UseInMemoryDatabase("TaskItems"));

// Optional - Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

var app = builder.Build();

// add init data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    InitData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Optional - Swagger
        app.UseSwagger();
        app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

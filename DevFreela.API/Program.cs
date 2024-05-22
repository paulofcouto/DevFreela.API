using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();

var configuration = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(
    options => options.UseSqlServer(configuration, t => t.MigrationsAssembly("DevFreela.Infrastructure"))
);

//Utilizar banco de dados em memoria com EntityFramework
//builder.Services.AddDbContext<DevFreelaDbContext>(options =>
//            options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));

builder.Services.AddMediatR(t => t.RegisterServicesFromAssembly(typeof(CreateProjectCommandHandler).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

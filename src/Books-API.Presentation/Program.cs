using Books_API.Core.Repositories;
using Books_API.Core.Services;
using Books_API.Infrastructure.Repositories;
using Books_API.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBooksRepository>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDb");

    return new BooksMongoRepository(connectionString!);
});

builder.Services.AddSingleton<IBooksService, BooksService>();

builder.Services.AddCors(options => {
    options.AddPolicy("Users-API", corsBuilder => {
        corsBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
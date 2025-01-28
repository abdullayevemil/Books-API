using Books_API.Core.Models;
using Books_API.Core.Repositories;
using Books_API.Core.Services;
using Books_API.Infrastructure.Repositories;
using Books_API.Infrastructure.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MongoDb");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBooksRepository>(options =>
{
    return new BooksMongoRepository(connectionString!);
});

builder.Services.AddSingleton<IBooksService, BooksService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Users-API", corsBuilder =>
    {
        corsBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var client = new MongoClient(connectionString);

    var booksDb = client.GetDatabase("BooksDb");

    var booksCollection = booksDb.GetCollection<Book>("Books");

    var book = await booksCollection.FindAsync(book => book.Id == 1);

    if (book.Any() == false)
    {
        booksCollection.InsertOne(new Book
        {
            Id = 1,
            Name = "Nineteen Eighty-Four",
            Author = "George Orwell",
            Pages = 385,
            Tags = [
                "Classics", "Dystopian"
            ]
        });

        booksCollection.InsertOne(new Book
        {
            Id = 2,
            Name = "Animal Farm",
            Author = "George Orwell",
            Pages = 280,
            Tags = [
                "Classics", "Psychology"
            ]
        });

        booksCollection.InsertOne(new Book
        {
            Id = 3,
            Name = "The Sign of the Four",
            Author = "Arthur Conan Doyle",
            Pages = 140,
            Tags = [
                "Classics", "Detective"
            ]
        });
    }
}

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
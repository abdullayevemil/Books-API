namespace Books_API.Infrastructure.Repositories;

using MongoDB.Driver;
using Books_API.Core.Models;
using Books_API.Core.Repositories;

public class BooksMongoRepository : IBooksRepository
{
    private readonly MongoClient client;
    private readonly IMongoDatabase booksDb;

    public BooksMongoRepository(string mongoDbConnectionoString)
    {
        this.client = new MongoClient(mongoDbConnectionoString);

        this.booksDb = this.client.GetDatabase("BooksDb");
    }

    public async Task<Book[]> GetBooksAsync(int[] bookIds)
    {
        var booksCollection = this.booksDb.GetCollection<Book>("Books");

        var books = await booksCollection.FindAsync(book => bookIds.Contains(book.Id));

        return books.ToList().ToArray();
    }
}
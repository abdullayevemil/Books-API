namespace Books_API.Infrastructure.Services;

using Books_API.Core.Models;
using Books_API.Core.Repositories;
using Books_API.Core.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository bookRepository;

    public BooksService(IBooksRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<Book[]> GetBooksAsync(int[]? bookIds)
    {
        ArgumentNullException.ThrowIfNull(bookIds, nameof(bookIds));

        var books = await this.bookRepository.GetBooksAsync(bookIds);

        return books;
    }
}
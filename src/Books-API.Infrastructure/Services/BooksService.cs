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

    public async Task<Book> GetBookByIdAsync(int? bookId)
    {
        ArgumentNullException.ThrowIfNull(bookId, nameof(bookId));

        var books = await this.bookRepository.GetBookByIdAsync((int)bookId);

        return books;
    }
}
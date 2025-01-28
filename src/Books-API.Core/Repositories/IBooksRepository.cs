namespace Books_API.Core.Repositories;

using Books_API.Core.Models;

public interface IBooksRepository
{
    Task<Book> GetBookByIdAsync(int bookId);
}
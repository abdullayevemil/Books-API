namespace Books_API.Core.Services;

using Books_API.Core.Models;

public interface IBooksService
{
    Task<Book> GetBookByIdAsync(int? bookIds);
}
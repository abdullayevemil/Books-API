namespace Books_API.Presentation.Controllers;

using Books_API.Core.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]/[action]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService booksService;

    public BooksController(IBooksService booksService)
    {
        this.booksService = booksService;
    }

    [HttpGet]
    [Route("/api/[controller]/[action]/{bookId}")]
    public async Task<IActionResult> GetBookAsync(int? bookId)
    {
        var book = await booksService.GetBookByIdAsync(bookId);

        return base.Ok(book);
    }
}
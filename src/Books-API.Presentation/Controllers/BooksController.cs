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
    public async Task<IActionResult> GetBooksAsync(int[]? booksIds)
    {
        var books = await booksService.GetBooksAsync(booksIds);

        return base.Ok(books);
    }
}
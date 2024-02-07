using BookApi.Helpers;
using BookApi.Models.DTO;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post(BookDTO item)
        {
            return Ok(await _bookService.Save(item));
        }
    }
}

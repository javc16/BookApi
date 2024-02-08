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

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetById(int id)
        {
            return Ok(await _bookService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<Response>> Post(BookDTO item)
        {
            return Ok(await _bookService.Save(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDTO>> Put(int id,BookDTO item)
        {
            
            return Ok(await _bookService.Put(id,item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BookDTO>> DeleteById(int id)
        {
            return Ok(await _bookService.Delete(id));
        }
    }
}

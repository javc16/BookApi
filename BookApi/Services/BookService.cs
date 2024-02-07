using BookApi.DBContext.Repository;
using BookApi.Helpers;
using BookApi.Models;
using BookApi.Models.DTO;
using BookApi.Constants;

using System.Reflection.Metadata;
using BookApi.Domain;

namespace BookApi.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _context;
        private readonly BookDomain _bookDomain;

        public BookService(IRepository<Book> context, BookDomain bookDomain)
        {
            _context = context;
            _bookDomain = bookDomain;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var books = _context.GetAll();
            var booksDTO = BookDTO.FromModelToDTO(books);
            return booksDTO;
        }

        public async Task<Response> GetById(int id)
        {
            var book = await _context.GetById(id);
            if (book == null)
            {
                return new Response
                {
                    Status = ConstantVariable.Failed,
                    Message = $"{ConstantVariable.This} {ConstantVariable.Book} with id: {id} {ConstantVariable.DoesNotExist}"
                };
            }
            var bookDTO = BookDTO.FromModelToDTO(book);
            return new Response
            {
                Status = ConstantVariable.Sucess,
                Message = "Retrieved Sucefully",
                Data = bookDTO
            };
        }

        public Task<Response> Save(BookDTO bookDTO)
        {
            var books = _context.GetAll();
            var existingBook = books.FirstOrDefault(x => x.Id.Equals(bookDTO.Id));
            if (_bookDomain.DuplicateBook(existingBook, bookDTO))
            {
                return Task.FromResult(new Response
                {
                    Status = ConstantVariable.Failed,
                    Message = $"{ConstantVariable.This} {ConstantVariable.Book} with id:{bookDTO.Name} {ConstantVariable.Duplicated}"
                });
            }

            var book = BookDTO.FromDtoToModel(bookDTO);
            _context.Add(book);
            _context.SaveChanges();
            return Task.FromResult(new Response
            {
                Status = ConstantVariable.Sucess,
                Message = $"{ConstantVariable.This} {ConstantVariable.Book} {ConstantVariable.SucefullyRegister}",
                Data = bookDTO
            });
        }
    }
}

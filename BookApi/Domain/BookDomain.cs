using BookApi.Models;
using BookApi.Models.DTO;

namespace BookApi.Domain
{
    public class BookDomain
    {
        public bool DuplicateBook(Book book, BookDTO bookDTO)
        {
            if (book != null && book.Name.Equals(bookDTO.Name))
            {
                return true;
            }
            return false;
        }
    }
}

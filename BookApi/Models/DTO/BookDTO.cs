namespace BookApi.Models.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }

        public static BookDTO FromModelToDTO(Book book)
        {

            return book != null ? new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Pages = book.Pages,
                PublicationDate = book.PublicationDate,
            } : new BookDTO();
        }

        public static IEnumerable<BookDTO> FromModelToDTO(IEnumerable<Book> books)
        {
            if (books == null)
            {
                return new List<BookDTO>();
            }
            List<BookDTO> clienteData = new List<BookDTO>();

            foreach (var item in books)
            {
                clienteData.Add(FromModelToDTO(item));
            }

            return clienteData;
        }

        public static Book FromDtoToModel(BookDTO bookDTO)
        {
            return bookDTO != null ? new Book.Builder().WithName(bookDTO.Name)
                .WithPages(bookDTO.Pages).WithPublicationDate(bookDTO.PublicationDate).Build() : new Book();
        }
    }
}

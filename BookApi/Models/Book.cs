namespace BookApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Pages { get; set; }
        public DateTime PublicationDate { get; set; }


        public class Builder
        {
            private Book _book = new Book();

            public Builder WithName(string? name)
            {
                _book.Name = name;
                return this;
            }

            public Builder WithPages(int pages)
            {
                _book.Pages = pages;
                return this;
            }

            public Builder WithPublicationDate(DateTime publicationDate)
            {
                _book.PublicationDate = publicationDate;
                return this;
            }          

            public Book Build()
            {
                return _book;
            }
        }
    }
}

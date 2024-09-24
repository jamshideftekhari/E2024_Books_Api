using E2024_Books_Api.Models;

namespace E2024_Books_Api.Repository
{
    public class BookRepo
    {
        private int _nextId = 1;
        private readonly List<Book> Data;
        

        public BookRepo() { 
            Data = new List<Book>();
            Data.Add(new Book { Id = _nextId++, Author = "Author 1", Description = "Description 1", Price = 500, Title = "Title 1" });
            Data.Add(new Book { Id = _nextId++, Author = "author 2", Description = "Description 2", Price = 600, Title = "Title 2"}  );           
        }

        public List<Book> GetAll()
        {
            return new List<Book>(Data);
        }

        public Book? GetById(int id)
        {
            //return Data[id];
            // or
            return Data.Find(x => x.Id == id);
        }

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            Data.Add(book);
            return book;
        }

        public Book? Update(int id, Book updates) {

            Book? book = GetById(id);
            if (book != null)
            {
                book.Title = updates.Title;
                book.Description = updates.Description;
                book.Price = updates.Price;
                book.Author = updates.Author;
                return book;
            }
            return null;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                Data.Remove(book);
                return book;
            }
            return null;
        }

    }
}

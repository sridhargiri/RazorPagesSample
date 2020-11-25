using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM
{
    public class BookRepository
    {
        private BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public void AddBook(string title, string author)
        {
            _context.Books.Add(new Book { Title = title, Author = author });
            _context.SaveChanges();
        }

        public List<Book> FetchBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

    }
}

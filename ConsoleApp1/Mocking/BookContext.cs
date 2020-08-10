using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Mocking
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public BookContext()
        {

        }
        public virtual DbSet<Book> Books { get; set; }
    }
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime DatePublished { get; set; }

        public Book()
        {
            DatePublished = new DateTime();
        }
    }
}

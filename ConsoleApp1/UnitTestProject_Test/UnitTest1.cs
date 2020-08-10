using MM;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject_Test
{
    [TestClass]
    public class BookRepositoryTests
    {

        [TestMethod]
        public void FetchBooksTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Book> books = new List<Book>
            {
                new Book
                {
                    Title = "Hamlet",
                    Author = "William Shakespeare"
                },
                new Book
                {
                    Title = "A Midsummer Night's Dream",
                    Author = "William Shakespeare"
                }

            }.AsQueryable();

            // To query our database we need to implement IQueryable 
            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            // Act - fetch books
            var repository = new BookRepository(mockContext.Object);
            var actual = repository.FetchBooks();

            // Asset
            // Ensure that 2 books are returned and
            // the first one's title is "Hamlet"
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual("Hamlet", actual.First().Title);
        }
        [TestMethod]
        public void CreateBookTest()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory implementations of you context and sets
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            // Act - Add the book
            var repository = new BookRepository(mockContext.Object);
            repository.AddBook("Macbeth1", "William Shakespeare1");

            // Assert
            // These two lines of code verifies that a book was added once and
            // we saved our changes once.
            mockContext.Verify(m => m.Books.Add(It.IsAny<Book>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
        [TestMethod]
        public void Char_Success()
        {
            MM.Controllers.ValuesController values = new MM.Controllers.ValuesController();
            var response=values.Get("", '\0', 0);
            Assert.IsTrue(response.Result is Microsoft.AspNetCore.Mvc.ActionResult);
            

        }
    }
}

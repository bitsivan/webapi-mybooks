using Data;
using Data.Model;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Name=book.Name,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = book.DateAdded,
                PublisherId=book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorId)
            {
                var _book_author = new BookAuthor()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.BooksAuthors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()=> _context.Books.ToList();
        public BookAuthorsVM GetBookById(int bookId)
        {
            var _bookAuthors = _context.Books.Where(n=>n.Id==bookId).Select(book => new BookAuthorsVM()
            {
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = book.DateAdded,
                PublisherName = book.Publisher.Name,
                AuthorNames=book.Book_Authors.Select(n=>n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookAuthors;
        }

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book!=null)
            {
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookbyId(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if(_book!=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}

using EntityFrameworkDemo.DbContexts;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly BookDbContext _context;
        public BookManagementService(BookDbContext context)
        {
            this._context = context;
        }

        public async Task<Book> GetBookById(string id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await this._context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Object>> GetBooksByAuthId(string authId)
        {
            var query = from a in _context.Authors
                        join b in _context.Books on a.AuthorID equals b.AuthID into bookGroup
                        from bg in bookGroup.DefaultIfEmpty()
                        where a.AuthorID == authId 
                        select new { BookTitle = bg.Title, AuthorFirstName = a.FirstName };

            var result = await query.ToListAsync();

            return result;
        }
    }
}

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
    }
}

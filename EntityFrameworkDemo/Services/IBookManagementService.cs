using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo.Services
{
    public interface IBookManagementService
    {
        public Task<IEnumerable<Book>> GetAllBooks();

        public Task<Book> GetBookById(string id);
    }
}

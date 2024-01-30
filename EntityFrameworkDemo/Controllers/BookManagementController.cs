using EntityFrameworkDemo.Models;
using EntityFrameworkDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookManagementController : ControllerBase
    {
        private readonly IBookManagementService _bookManagementService;

        public BookManagementController(
            IBookManagementService bookManagementService)
        {
            this._bookManagementService = bookManagementService;
        }

        [HttpGet("books", Name = "GetAllBooks")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookManagementService.GetAllBooks();
        }

        [HttpGet("book/{id}", Name = "GetBookById")]
        public async Task<Book> GetBookById(string id)
        {
            return await _bookManagementService.GetBookById(id);
        }

        [HttpGet("bookByAuthor/{authId}", Name = "GetBookByAuthId")]
        public async Task<IEnumerable<Object>> GetBookByAuthId(string authId)
        {
            return await _bookManagementService.GetBooksByAuthId(authId);
        }
    }
}

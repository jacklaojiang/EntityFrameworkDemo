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

        [HttpGet(Name = "GetAllBooks")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookManagementService.GetAllBooks();
        }

        [HttpGet(Name = "GetBookById")]
        public async Task<Book> GetBookById(string id)
        {
            return await _bookManagementService.GetBookById(id);
        }
    }
}

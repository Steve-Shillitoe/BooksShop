using BooksShop.Models;
namespace BooksShop.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooksAsync();
    }
}

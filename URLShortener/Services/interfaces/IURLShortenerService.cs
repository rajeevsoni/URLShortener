using System.Threading.Tasks;

namespace URLShortener.Services
{
    public interface IURLShortenerService
    {
        Task<string> SaveURL(string url);
        Task<string> GetURL(string hashedURL);
    }
}

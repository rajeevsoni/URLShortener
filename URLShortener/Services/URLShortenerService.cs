using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Data.DBContext;
using URLShortener.Data.Entities;
using URLShortener.Utils;

namespace URLShortener.Services
{
    public class URLShortenerService : IURLShortenerService
    {
        private readonly ILogger<URLShortenerService> _logger;
        private readonly Func<URLShortenerDBContext> _dbContextProvider;

        public URLShortenerService(Func<URLShortenerDBContext> dbContextProvider, ILogger<URLShortenerService> logger)
        {
            _dbContextProvider = dbContextProvider;
            _logger = logger;
        }


        public async Task<string> GetURL(string hashedURL)
        {
            using(var dbContext = _dbContextProvider())
            {
                var urlInfo = await dbContext.URLInfos.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.HashedURL == hashedURL);
                return urlInfo.URL;
            }
        }

        public async Task<string> SaveURL(string url)
        {
            using (var dbContext = _dbContextProvider())
            {
                var hashedURL = HashGenerator.Generate_SHA256_Hash(url);
                var urlInfo = await dbContext.URLInfos.SingleOrDefaultAsync(x => x.HashedURL == hashedURL);
                if(urlInfo == null)
                {
                    urlInfo = new URLInfo() { URL = url, CreatedOn = DateTime.UtcNow };
                    urlInfo.HashedURL = hashedURL;
                    dbContext.URLInfos.Add(urlInfo);
                    await dbContext.SaveChangesAsync();
                }
                return urlInfo.HashedURL;
            }
        }
    }
}

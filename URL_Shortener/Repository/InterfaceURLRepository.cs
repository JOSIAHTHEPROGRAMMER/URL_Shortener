using Microsoft.EntityFrameworkCore;
using URL_Shortener.Models;
using URL_Shortener.URLData;

namespace URL_Shortener.Repository
{
    public interface InterfaceURLRepository
    {
        Task<URLMapping> GetMappingShortCodeAsync(string code);

        Task<URLMapping> GetMappingOriginalAsync(string url);

        Task SaveMapping(URLMapping mapping);
    }


    public class URLRepo(URLDbContext context) : InterfaceURLRepository
    {
        public async Task<URLMapping> GetMappingOriginalAsync(string url)
        {
            return await context.Mapping.FirstOrDefaultAsync(x=>x.Url ==  url);
        }

        public async Task<URLMapping> GetMappingShortCodeAsync(string code)
        {
            return await context.Mapping.FirstOrDefaultAsync(x => x.ShortCode == code);
        }

        public async Task SaveMapping(URLMapping mapping)
        {
            context.Mapping.Add(mapping);
            await context.SaveChangesAsync();
            return;

        }
    }

}

using URL_Shortener.helper;
using URL_Shortener.Models;
using URL_Shortener.Repository;

namespace URL_Shortener.Services
{
    public interface IService
    {
        Task<String> ShortenUrlAsync(string url);
        Task<String> GetOriginalAsync(string url);
    }


    public class UrlService(InterfaceURLRepository URLRepo, IHelper Helper) : IService
    {
        public async Task<string> GetOriginalAsync(string url)
        {
           var check = await URLRepo.GetMappingShortCodeAsync(url);
            return check == null ? null! : check.Url;
        }

        public async Task<string> ShortenUrlAsync(string url)
        {
            bool valid = Helper.IsValidUrl(url);

            if(!valid) return null!;

            var checkMap = await URLRepo.GetMappingOriginalAsync(url);

            if (checkMap == null) {

                var code = Helper.GenerateShortcode();
                var mapping = new URLMapping
                {
                    Url = url,
                    ShortCode = code
                };

                await URLRepo.SaveMapping(mapping);
                return Helper.ConstructUrl(code);



                
            }

            return Helper.ConstructUrl(checkMap!.ShortCode);


        }
    }

}

namespace URL_Shortener.helper
{
    public interface IHelper
    {
        string ConstructUrl(string code);
        string GenerateShortcode();

        bool IsValidUrl(string url);

    }


    public class Helper(IHttpContextAccessor httpContextAccessor) : IHelper
    {
        public string ConstructUrl(string code)
        {
            var req = httpContextAccessor.HttpContext?.Request;
            if (req == null) return string.Empty;

            // Build full base URL (scheme://host)
            var baseUrl = $"{req.Scheme}://{req.Host}";

            return $"{baseUrl}/{code}";
        }


        public string GenerateShortcode()
        {
            return Guid.NewGuid().ToString("n")[..8] ;
        }

        public bool IsValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return false ;

            return Uri.TryCreate(url,UriKind.Absolute, out var uri) && 
                (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp) ;
        }
    }
}


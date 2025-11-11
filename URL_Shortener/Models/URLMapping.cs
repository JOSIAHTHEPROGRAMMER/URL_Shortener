namespace URL_Shortener.Models
{
    public class URLMapping
    {
        public int Id { get; set; }

        public string ShortCode { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

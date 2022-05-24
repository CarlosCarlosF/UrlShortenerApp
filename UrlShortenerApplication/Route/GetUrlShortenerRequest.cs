using ServiceStack;

namespace UrlShortenerApplication
{
    [FallbackRoute("/{ShortLink}")]
    public class GetUrlShortenerRequest
    {
        public string ShortLink { get; set; }
    }
}

using ServiceStack;
namespace UrlShortenerApplication
{
    [Route("/shorten", Verbs = "POST")]
    public class UrlShortenerRequest
    {
       public string Url { get; set; }
    }

}

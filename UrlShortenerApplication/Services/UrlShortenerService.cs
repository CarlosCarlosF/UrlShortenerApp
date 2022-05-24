using DomainModel;
using Infrastracture;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Net;

namespace UrlShortenerApplication
{
    public class UrlShortenerService : Service
    {
        private readonly ICachingService _cachingService;

        public UrlShortenerService(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        public UrlShortenerResponse Post(UrlShortenerRequest request)
        {
            var shortenedLink = new ShortenedLink()
            {
                OriginalLink = request.Url,
                ShortLink = GenerateRandomString()
            };
            var key = _cachingService.BuildKey(shortenedLink.ShortLink);

          _cachingService.CacheData<ShortenedLink>(shortenedLink, key);

            return new UrlShortenerResponse()
            {
                ShortenedLink = shortenedLink.ShortLink,
                OriginalLink = shortenedLink.OriginalLink
            };
        }

        public HttpResult Get(GetUrlShortenerRequest request)
        {
            var key = _cachingService.BuildKey(request.ShortLink); 
            var origanlLink = _cachingService.GetDataFromCache<ShortenedLink>(key);
            if (origanlLink == null) return new HttpResult(HttpStatusCode.NotFound);
            return HttpResult.Redirect(origanlLink.OriginalLink, HttpStatusCode.MovedPermanently);
        }

        public string GenerateRandomString()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var Charsarr = new char[4];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }
    }
}

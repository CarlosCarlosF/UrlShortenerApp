using MongoDB.Bson.Serialization.Attributes;

namespace DomainModel
{
    public class ShortenedLink
    {
        public string OriginalLink { get; set; }

        [BsonId]
        public string ShortLink { get; set; }

    }
}

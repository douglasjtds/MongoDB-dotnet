using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;


namespace Alura.GoogleMaps.Web.Models
{
    public class Aeroporto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Loc { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}
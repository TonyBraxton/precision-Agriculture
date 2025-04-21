using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AgricultureOptimization.Models
{
    public class Crop
    {
        [BsonId] // Tells MongoDB to map the _id field to this property
        public ObjectId _id { get; set; }
        public string? label { get; set; }
        public double crop_density { get; set; }
        public double growth_stage { get; set; }

    }
}

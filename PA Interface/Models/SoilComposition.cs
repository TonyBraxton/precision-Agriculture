using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AgricultureOptimization.Models
{
    public class SoilComposition
    {
        [BsonId] // Tells MongoDB to map the _id field to this property
        public ObjectId _id { get; set; }
        public double organic_matter { get; set; }
        public double ph { get; set; }
        public double P { get; set; }
        public double K { get; set; }
        public double N { get; set; }
        public double soil_moisture { get; set; }
        public double soil_type { get; set; }
        public double NBR { get; set; }
        public double SFI { get; set; }


    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureOptimization.Models
{
    public class Weather
    {
        [BsonId] // Tells MongoDB to map the _id field to this property
        public ObjectId _id { get; set; }


        //[BsonElement("co2_concentration")]   // when your db has trouble recognizing the variables you create here
        public double co2_concentration { get; set; }
        public double temperature { get; set; }
        public double rainfall { get; set; }

        public double humidity { get; set; }
        public double sunlight_exposure { get; set; }
        public double wind_speed { get; set; }
        public double WAI { get; set; }
        public double THI { get; set; }
        public double PP { get; set; }
    }
}

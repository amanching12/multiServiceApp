using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherApi.Models;

public class WeatherData{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }  // MongoDB's _id field

    [BsonElement("LocationId")]
    public required string LocationId { get; set; }

    [BsonElement("WeatherDescription")]
    public string? WeatherDescription { get; set; }

    [BsonElement("TemperatureCelsius")]
    public double TemperatureCelsius { get; set; }
}
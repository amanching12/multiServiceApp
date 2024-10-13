namespace WeatherApi.AppSettings;

public class DBConfig{
    public required string DatabaseProvider {get;set;}
    public required string DatabaseName{get;set;}
    public required string DBConnectionString {get;set;}

}
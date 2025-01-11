using Newtonsoft.Json;

public class ExampleStorage 
{
    [JsonProperty(PropertyName = "RC")]
    public int RoundScore { get; set; }
    [JsonProperty(PropertyName = "BC")]
    public int BestScore { get; set; }
}

using Newtonsoft.Json;

namespace P3L_V1.Model;

public class PaginationLink
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("active")]
    public bool Active { get; set; }
}
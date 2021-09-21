using System;
using System.Text.Json.Serialization;

namespace Training.Entity
{
    public class Catalog
    {
        [JsonPropertyName("id")]

        public int Id { get; set; }

        [JsonPropertyName("name")]

        public string Name{ get; set; }

        [JsonPropertyName("createAt")]

        public DateTime CreateAt { get; set; }
        
        [JsonPropertyName("modifiedAt")]

        public DateTime ModifiedAt { get; set; }

    }
}

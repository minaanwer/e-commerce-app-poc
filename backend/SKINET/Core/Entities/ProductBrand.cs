using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class ProductBrand : BaseEntity
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}
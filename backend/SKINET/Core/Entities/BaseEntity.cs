using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BaseEntity
    {

        [JsonPropertyName("Id")]
        public int Id { get; set; }

    }
}

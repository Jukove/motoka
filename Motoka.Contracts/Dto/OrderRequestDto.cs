using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Contracts.Dto
{
    public class OrderRequestDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("fare")]
        public decimal Fare { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

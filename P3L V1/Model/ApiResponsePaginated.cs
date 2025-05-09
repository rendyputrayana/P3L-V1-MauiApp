using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class ApiResponsePaginated<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public PaginatedData<T> Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

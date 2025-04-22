using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class LoginData
    {
        [JsonProperty("pengguna")]
        public Pengguna Pengguna { get; set; }
    }
}

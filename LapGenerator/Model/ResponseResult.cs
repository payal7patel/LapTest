using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapGenerator.Model
{
    public class ResponseResult<T>
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}

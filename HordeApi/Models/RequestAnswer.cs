using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi.Models
{
    /// <summary>
    /// <c>RequestAnswer</c> is an object you receive on text generation request. <br />
    /// API docs <see href="https://stablehorde.net/api/">link</see>  <br /> <br />
    /// the id is needed if further api calls as an argument to identify your processed request
    /// </summary>
    public class RequestAnswer
    {
        public string id { get; set; }
        public double kudos { get; set; }
    }
}

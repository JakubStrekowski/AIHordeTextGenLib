using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi.Models
{
    /// <summary>
    /// <c>RequestStatusKobold</c> is an object you receive on generation status request. <br />
    /// API docs <see href="https://stablehorde.net/api/">link</see> 
    /// </summary>
    public class RequestStatusKobold
    {
        public int finished
        {
            get; set;
        }
        public int processing { get; set; }
        public int restarted { get; set; }
        public int waiting { get; set; }
        public bool done { get; set; }
        public bool faulted { get; set; }
        public int wait_time { get; set; }
        public int queue_position { get; set; }
        public double kudos { get; set; }
        public bool is_possible { get; set; }
        public List<GenerationKobold> generations { get; set; }
    }
}

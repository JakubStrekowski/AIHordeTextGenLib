using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi.Models
{
    public class GenerationKobold
    {
        public string worker_id { get; set; }
        public string worker_name { get; set; }
        public string model { get; set; }
        public string state { get; set; }
        public string text { get; set; }
        public int seed { get; set; }

        public List<GenerationMetadataKobold> gen_metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi.Models
{
    public class AiModelParams
    {
        public int n { get; set; }
        public bool frmtadsnsp { get; set; }
        public bool frmtrmblln { get; set; }
        public bool frmtrmspch { get; set; }
        public bool frmttriminc { get; set; }
        public int max_context_length { get; set; }
        public int max_length { get; set; }
        public float rep_pen { get; set; }
        public int rep_pen_range { get; set; }
        public float rep_pen_slope { get; set; }
        public bool singleline { get; set; }
        public float temperature { get; set; }
        public int tfs { get; set; }
        public float top_a { get; set; }
        public int top_k { get; set; }
        public float top_p { get; set; }
        public float typical { get; set; }
        public bool use_default_badwordsids { get; set; }
        public string[] stop_sequence { get; set; }
        public float min_p { get; set; }
        public float dynatemp_range { get; set; }
        public float dynatemp_exponent { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi.Models
{
    /// <summary>
    /// <c>RequestAnswer</c> contains all settings about text generation model. <br />
    /// API docs <see href="https://stablehorde.net/api/">link</see>  <br /> <br />
    /// </summary>
    public class HordeApiRequestContent
    {
        public string prompt { get; set; }
        public AiModelParams @params { get; set; }
        public string softprompt { get; set; }
        public bool trusted_workers { get; set; }
        public bool slow_workers { get; set; }
        public bool worker_blacklist { get; set; }
        public bool dry_run { get; set; }
        public bool disable_batching { get; set; }

        public HordeApiRequestContent()
        {
            prompt = string.Empty;
            @params = new AiModelParams
            {
                n = 1,
                frmtadsnsp = false,
                frmtrmblln = false,
                frmtrmspch = false,
                frmttriminc = false,
                max_context_length = 2048,
                max_length = 512,
                rep_pen = 1.09f,
                rep_pen_range = 512,
                rep_pen_slope = 2.4f,
                singleline = false,
                temperature = 0.65f,
                tfs = 1,
                top_a = 1,
                top_k = 0,
                top_p = 0.9f,
                typical = 1,
                use_default_badwordsids = false,
                stop_sequence = new string[] { "string" },
                min_p = 0,
                dynatemp_range = 0,
                dynatemp_exponent = 1,
            };
            softprompt = "string";
            trusted_workers = false;
            slow_workers = true;
            worker_blacklist = false;
            dry_run = false;
            disable_batching = false;
        }
    }
}

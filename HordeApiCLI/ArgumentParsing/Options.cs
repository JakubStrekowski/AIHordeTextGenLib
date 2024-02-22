using CommandLine.Text;
using CommandLine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HordeApiCLI.ArgumentParsing
{
    /// <summary>
    /// <c>Options</c> contains all cli arguments. <br /><br />
    /// apiKey - Set api key, if not set it defaults to guest api key: 0000000000 <br />
    /// user - Set user nickname <br />
    /// assistant - Set assistant nickname <br />
    /// prompt - Set initial prompt to describe assistant's behaviour <br />
    /// showDebug - Print system outputs about retrieving API calls and queue wait time <br />
    /// showErrors - Print error outputs about connection failures <br />
    /// </summary>
    internal class Options
    {
        private const string defaultPrompt = @"Add answers of Assistant in dialogue. Generate only Assistant answers.
You are a helpful assistant. \r\n
You help User in whatever he/she requests.
Answers should be always thoughtful and precise.
Use emojis and light humor in the theme of the conversations subject.

-------------------
";

        [Option('k', "apiKey", Required = false, Default = "0000000000", HelpText = "Set api key, if not set it defaults to guest api key: 0000000000")]
        public string ApiKey { get; set; }

        [Option('u', "user", Required = false, Default = "User", HelpText = "Set user nickname")]
        public string User { get; set; }

        [Option('a', "assistant", Required = false, Default = "Assistant", HelpText = "Set assistant nickname")]
        public string Assistant { get; set; }

        [Option('p', "prompt", Required = false, Default = defaultPrompt, HelpText = "Set initial prompt to describe assistant's behaviour")]
        public string Prompt { get; set; }

        [Option('d', "showDebug", Required = false, Default = true, HelpText = "Print system outputs about retrieving API calls and queue wait time")]
        public bool Debug { get; set; }

        [Option('e', "showErrors", Required = false, Default = true, HelpText = "Print error outputs about connection failures")]
        public bool Errors { get; set; }
    }
}

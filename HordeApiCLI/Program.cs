using CommandLine;
using HordeApi;
using HordeApi.Models;
using HordeApiCLI.ArgumentParsing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HordeApiCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var result = Parser.Default.ParseArguments<Options>(args)
                   .WithParsed(StartChat)
                   .WithNotParsed(ParseErrors);
        }

        private static void StartChat(Options o)
        {
            Chat chat = new Chat();
            chat.ChatLoop(o).Wait();
        }

        private static void ParseErrors(IEnumerable<Error> errs)
        {
            Console.WriteLine("Incorrect arguments, run with --help to check manual");
            Console.WriteLine("Press any key to close the app.");
            Console.ReadKey();
        }
    }
}

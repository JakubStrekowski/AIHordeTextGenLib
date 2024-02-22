using HordeApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HordeApi
{
    /// <summary>
    /// <c>HordeApiCaller</c> has async methods to send text generation requests to HordeAI API. <br />
    /// API docs <see href="https://stablehorde.net/api/">link</see> <br /> <br />
    /// You can change models settings in Settings member.
    /// </summary>
    public class HordeApiCaller
    {
        public HordeApiRequestContent Settings { get; set; }
        public HordeApiCaller()
        {
            Settings = new HordeApiRequestContent();
        }

        /// <summary>
        /// Sends a request to HordeAI to generate text <br />
        /// API docs <see href="https://stablehorde.net/api/">link</see> <br /> <br />
        /// <param name="prompt">Initial text on which the model will base the next text generation</param> <br />  <br />
        /// <param name="apiKey">Api key to your HordeAI account, use "0000000000" if you want to request as guest</param> <br />  <br />
        /// <returns>Returns a json response string, deserialize it to RequestAnswer</returns>
        /// </summary>
        public async Task<string> SendGenerateRequest(string prompt, string apiKey)
        {
            Settings.prompt = prompt;
            var textGenRequest = Settings;
            var jsonString = JsonConvert.SerializeObject(textGenRequest);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            client.DefaultRequestHeaders.Add("apikey", apiKey);
            client.DefaultRequestHeaders.Add("Client-Agent", "unknown:0:unknown");

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://stablehorde.net/api/v2/generate/text/async", content);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Asks for current status of generated text <br />
        /// API docs <see href="https://stablehorde.net/api/">link</see> <br /> <br />
        /// <param name="requestId">Id of the request your received from SendGenerateRequest method</param> <br />  <br />
        /// <returns>Returns a json response string, deserialize it to RequestStatusKobold</returns>
        /// </summary>
        public async Task<string> SendStatusCheck(string requestId)
        {
            var statusClient = new HttpClient();
            statusClient.DefaultRequestHeaders.Clear();
            statusClient.DefaultRequestHeaders.Add("accept", "application/json");
            statusClient.DefaultRequestHeaders.Add("Client-Agent", "unknown:0:unknown");

            var statusResponse = await statusClient.GetAsync($"https://stablehorde.net/api/v2/generate/text/status/{requestId}");
            return await statusResponse.Content.ReadAsStringAsync();
        }
    }
}

using HordeApi;
using HordeApi.Models;
using HordeApiCLI.ArgumentParsing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApiCLI
{
    internal class Chat
    {
        private Logger _logger;
        private HordeApiCaller _apiCaller;

        public Chat()
        {
            _logger = new Logger();
            _apiCaller = new HordeApiCaller();
        }

        public async Task ChatLoop(Options o)
        {
            string combinedInput;
            string logs = string.Empty;

            if (!o.Debug)
            {
                _logger.SetVerboseLevels(ELogSource.System, false);
            }
            if (!o.Errors)
            {
                _logger.SetVerboseLevels(ELogSource.Error, false);
            }

            while (true)
            {
                logs += $"{o.User}: ";
                _logger.Write(ELogSource.Standard, $"{o.User}: ");

                string userInput = Console.ReadLine();

                if (userInput == "/exit" ||
                    userInput == "/quit")
                {
                    return;
                }

                logs += userInput + $"\n{o.Assistant}: ";
                combinedInput = o.Prompt + logs;

                string result = await _apiCaller.SendGenerateRequest(combinedInput, o.ApiKey);
                RequestAnswer requestAnswer = JsonConvert.DeserializeObject<RequestAnswer>(result);

                if (requestAnswer.id == null)
                {
                    _logger.WriteLine(ELogSource.System, ($"SYSTEM: {result}"));
                    continue;
                }

                await Task.Delay(1000);

                bool taskfinished = false;
                bool firstStatus = true;
                
                while (!taskfinished)
                {
                    string statusResult = await _apiCaller.SendStatusCheck(requestAnswer.id);
                    RequestStatusKobold requestStatus = JsonConvert.DeserializeObject<RequestStatusKobold>(statusResult);

                    if (firstStatus && requestStatus.queue_position != 0)
                    {
                        firstStatus = false;
                        _logger.WriteLine(ELogSource.System, $"SYSTEM: in queue, number = {requestStatus.queue_position}");
                    }

                    if (requestStatus == null)
                    {
                        _logger.WriteLine(ELogSource.Error, $"ERROR: {statusResult}");
                        return;
                    }
                    if (requestStatus.faulted)
                    {
                        _logger.WriteLine(ELogSource.Error, $"ERROR: {statusResult}");
                        return;
                    }
                    if (requestStatus.done)
                    {
                        taskfinished = true;
                    }
                    if (requestStatus.wait_time > 0)
                    {
                        _logger.WriteLine(ELogSource.System, $"SYSTEM: in progress, estimated wait time = {requestStatus.wait_time} seconds");
                        await Task.Delay(requestStatus.wait_time * 1000);
                    }
                    else
                    {
                        await Task.Delay(2000);
                    }
                }

                string endResult = await _apiCaller.SendStatusCheck(requestAnswer.id);
                RequestStatusKobold endStatus = JsonConvert.DeserializeObject<RequestStatusKobold>(endResult);

                string[] removeBy = new string[1] { $"{o.User}:" };
                string stripped = endStatus.generations[0].text.Split(removeBy, 2, StringSplitOptions.RemoveEmptyEntries)[0];
                logs += stripped;

                if (stripped.EndsWith("\n"))
                {
                    stripped = stripped.Substring(stripped.Length - 1);
                }
                _logger.WriteLine(ELogSource.Standard, $"{o.Assistant}: {stripped}");

            }
        }
    }
}

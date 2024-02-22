using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HordeApiCLI
{
    internal enum ELogSource
    {
        Standard,
        System,
        Error
    }

    internal class Logger
    {
        private const string DateTimePattern = "HH:mm:ss";

        private Dictionary<ELogSource, bool> _shouldPrint = new Dictionary<ELogSource, bool> 
        {
            { ELogSource.Standard, true }, 
            { ELogSource.System, true },
            { ELogSource.Error, true },
        };


        public void WriteLine(ELogSource source, string message)
        {
            Write(source, message + '\n');
        }

        public void Write(ELogSource source, string message)
        {
            if (!_shouldPrint[source]) return;

            DateTime now = DateTime.Now;

            switch (source)
            {
                default:
                case ELogSource.Standard:
                    WriteColor($"{now.ToString(DateTimePattern)} {message}", null);
                    break;
                case ELogSource.System:
                    WriteColor($"{now.ToString(DateTimePattern)} {message}", ConsoleColor.Yellow);
                    break;
                case ELogSource.Error:
                    WriteColor($"{now.ToString(DateTimePattern)} {message}", ConsoleColor.Red);
                    break;
            }
        }

        public void SetVerboseLevels(ELogSource source, bool value) 
        {
            _shouldPrint[source] = value;
        }

        private void WriteColor(string text, ConsoleColor? color)
        {
            if (color != null)
            {
                Console.ForegroundColor = (ConsoleColor)color;
            }
            Console.Write(text);
            Console.ResetColor();
        }
    }
}

using Logging.Net;
using Logging.Net.Loggers;
using System;
using System.Diagnostics;

namespace FlappyBird
{
    public class DebugLogger : ILoggingAddition
    {
        LogFileLogger fl = new LogFileLogger("flappy.log");
        public void ProcessMessage(string s, ConsoleColor color)
        {
            try
            {
                fl.ProcessMessage(s, color);
            }
            catch (Exception ex)
            {

            }
            Debug.WriteLine(s);
        }
    }
}
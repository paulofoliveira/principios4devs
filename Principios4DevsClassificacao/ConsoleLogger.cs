using System;

namespace Principios4DevsClassificacao
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string mensagem)
        {
            Console.WriteLine(mensagem);
        }
    }
}

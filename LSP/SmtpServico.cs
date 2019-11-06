using System;

namespace LSP
{
    internal class SmtpServico : INotificacaoServico
    {
        public void EnviarEmail(string remetente, string mensagem)
        {
            // Procedimento de enviar e-mail ...
        }

        public void EnviarSms(string numero, string mensagem)
        {
            throw new NotImplementedException(); // Bad =/
        }
    }
}

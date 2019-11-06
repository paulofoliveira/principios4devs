namespace LSP
{
    internal interface INotificacaoServico
    {
        void EnviarEmail(string remetente, string mensagem);
        void EnviarSms(string numero, string mensagem);
    }
}

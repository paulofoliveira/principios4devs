namespace Principios4DevsClassificacao
{
    internal class ClassificacaoPadraoContexto : IClassificacaoContexto
    {
        public ClassificacaoServico Servico { get; set; }

        public Classificador CriarClassificadorPorApolice(Apolice apolice, IClassificacaoContexto contexto)
        {
            return new ClassificadorFabrica().Criar(apolice, contexto);
        }

        public void Log(string mensagem)
        {
            new ConsoleLogger().Log(mensagem);
        }

        public string RecuperarApoliceDaFonte()
        {
            return new ApoliceArquivoFonte().RecuperarApoliceDaFonte();
        }

        public Apolice RecuperarPorJsonString(string apoliceJson)
        {
            return new ApoliceSerializador().RecuperarPorJsonString(apoliceJson);
        }
    }
}

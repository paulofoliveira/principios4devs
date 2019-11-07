namespace Principios4DevsClassificacao
{
    internal interface IClassificacaoContexto : ILogger
    {
        ClassificacaoServico Servico { get; set; }
        Classificador CriarClassificadorPorApolice(Apolice apolice, IClassificacaoContexto contexto);
        Apolice RecuperarPorJsonString(string apoliceJson);
        string RecuperarApoliceDaFonte();
    }
}

namespace Principios4DevsClassificacao
{
    internal class DesconhecidoClassificador : Classificador
    {
        public DesconhecidoClassificador(ClassificacaoServico servico, ConsoleLogger logger) : base(servico, logger)
        {
        }

        public override void Classificar(Apolice apolice)
        {
            _logger.Log("Tipo de apólice desconhecida.");
        }
    }
}

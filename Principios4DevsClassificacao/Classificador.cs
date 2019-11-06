namespace Principios4DevsClassificacao
{
    internal abstract class Classificador
    {
        protected readonly ClassificacaoServico _servico;
        protected ConsoleLogger _logger;

        public Classificador(ClassificacaoServico servico, ConsoleLogger logger)
        {
            _servico = servico;
            _logger = logger;
        }

        public abstract void Classificar(Apolice apolice);
    }
}

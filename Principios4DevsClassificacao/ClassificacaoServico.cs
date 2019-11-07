namespace Principios4DevsClassificacao
{
    internal class ClassificacaoServico
    {
        private readonly ILogger _logger;

        public ClassificacaoServico(ILogger logger)
        {
            Contexto.Servico = this;
            _logger = logger;
        }

        //public ClassificacaoServico() : this(new ConsoleLogger())
        //{

        //}

        public IClassificacaoContexto Contexto { get; set; } = new ClassificacaoPadraoContexto();

        public decimal Classificacao { get; set; }

        public void Classificar()
        {
            _logger.Log("Iniciando classificação.");

            _logger.Log("Carregando apólice.");

            var apoliceJson = Contexto.RecuperarApoliceDaFonte();

            var apolice = Contexto.RecuperarPorJsonString(apoliceJson);

            var classificador = Contexto.CriarClassificadorPorApolice(apolice, Contexto);

            classificador.Classificar(apolice);

            _logger.Log("Classificação completada.");
        }
    }
}

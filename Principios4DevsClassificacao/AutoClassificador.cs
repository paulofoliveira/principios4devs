namespace Principios4DevsClassificacao
{
    internal class AutoClassificador : Classificador
    {
        public AutoClassificador(ClassificacaoServico servico, ConsoleLogger logger) : base(servico, logger)
        {

        }

        public override void Classificar(Apolice apolice)
        {
            _logger.Log("Classificando apólice Auto...");
            _logger.Log("Validando apólice.");

            if (string.IsNullOrEmpty(apolice.Marca))
            {
                _logger.Log("Apólice Auto deve especificar uma marca.");
                return;
            }

            if (apolice.Marca == "BMW")
            {
                if (apolice.Dedutivel < 500)
                {
                    _servico.Classificacao = 1000m;
                }
                else
                    _servico.Classificacao = 900m;
            }
        }
    }
}

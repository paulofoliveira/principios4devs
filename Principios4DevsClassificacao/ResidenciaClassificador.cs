namespace Principios4DevsClassificacao
{
    internal class ResidenciaClassificador : Classificador
    {  
        public ResidenciaClassificador(ClassificacaoServico servico, ConsoleLogger logger) : base(servico, logger)
        {
       
        }

        public override void Classificar(Apolice apolice)
        {
            _logger.Log("Classificando apólice Residencia...");
            _logger.Log("Validando apólice.");

            if (apolice.ValorTitulo == 0 || apolice.ValorVenal == 0)
            {
                _logger.Log("Apólice Residencia deve especificar um valor de título ou valor venal.");
                return;
            }
            if (apolice.ValorTitulo < 0.8m * apolice.ValorVenal)
            {
                _logger.Log("Valor insuficiente.");
                return;
            }

            _servico.Classificacao = apolice.ValorTitulo * 0.05m;
        }
    }
}

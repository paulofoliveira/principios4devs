using System;

namespace Principios4DevsClassificacao
{
    internal class SaudeClassificador : Classificador
    {
        public SaudeClassificador(ClassificacaoServico servico, ConsoleLogger logger) : base(servico, logger)
        {
        }

        public override void Classificar(Apolice apolice)
        {
            _logger.Log("Classificando apólice Saúde...");
            _logger.Log("Validando apólice.");

            if (apolice.QtdVidas == 0)
            {
                _logger.Log("Apólice Saúde deve conter uma quantidade de vidas.");
                return;
            }

            var fator = apolice.Cooparticipacao ? 0.25 : 0;

            _servico.Classificacao = (100m * apolice.QtdVidas) * (decimal)(1d + fator);
        }
    }
}

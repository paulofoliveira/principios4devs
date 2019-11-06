using System;

namespace Principios4DevsClassificacao
{
    internal class VidaClassificador
    {
        private readonly ClassificacaoServico _servico;
        private ConsoleLogger _logger;

        public VidaClassificador(ClassificacaoServico servico, ConsoleLogger logger)
        {
            _servico = servico;
            _logger = logger;
        }

        public void Classificar(Apolice apolice)
        {
            _logger.Log("Classificando apólice Vida...");
            _logger.Log("Validando apólice.");

            if (apolice.DataNascimento == DateTime.MinValue)
            {
                _logger.Log("Apólice de vida deve conter data de nascimento.");
                return;
            }

            if (apolice.DataNascimento < DateTime.Today.AddYears(-100))
            {
                _logger.Log("Pessoas centenárias não são permitidas.");
                return;
            }

            if (apolice.Total == 0)
            {
                _logger.Log("Apólice de vida deve conter total.");
                return;
            }

            var idade = DateTime.Today.Year - apolice.DataNascimento.Year;

            if (apolice.DataNascimento.Month == DateTime.Today.Month &&
                 DateTime.Today.Day < apolice.DataNascimento.Day ||
                 DateTime.Today.Month < apolice.DataNascimento.Month)
            {
                idade--;
            }

            decimal baseClassificacao = apolice.Total * idade / 200;

            if (apolice.Fumante)
            {
                _servico.Classificacao = baseClassificacao * 2;
                return;
            }

            _servico.Classificacao = baseClassificacao;
        }
    }
}

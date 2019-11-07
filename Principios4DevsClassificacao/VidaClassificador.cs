using System;

namespace Principios4DevsClassificacao
{
    internal class VidaClassificador : Classificador
    {
        public VidaClassificador(IClassificacaoContexto contexto) : base(contexto)
        {

        }

        public override void Classificar(Apolice apolice)
        {
            _contexto.Log("Classificando apólice Vida...");
            _contexto.Log("Validando apólice.");

            if (apolice.DataNascimento == DateTime.MinValue)
            {
                _contexto.Log("Apólice de vida deve conter data de nascimento.");
                return;
            }

            if (apolice.DataNascimento < DateTime.Today.AddYears(-100))
            {
                _contexto.Log("Pessoas centenárias não são permitidas.");
                return;
            }

            if (apolice.Total == 0)
            {
                _contexto.Log("Apólice de vida deve conter total.");
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
                _contexto.Servico.Classificacao = baseClassificacao * 2;
                return;
            }

            _contexto.Servico.Classificacao = baseClassificacao;
        }
    }
}

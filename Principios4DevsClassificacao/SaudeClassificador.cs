namespace Principios4DevsClassificacao
{
    internal class SaudeClassificador : Classificador
    {
        public SaudeClassificador(IClassificacaoContexto contexto) : base(contexto)
        {
        }

        public override void Classificar(Apolice apolice)
        {
            _contexto.Log("Classificando apólice Saúde...");
            _contexto.Log("Validando apólice.");

            if (apolice.QtdVidas == 0)
            {
                _contexto.Log("Apólice Saúde deve conter uma quantidade de vidas.");
                return;
            }

            var fator = apolice.Cooparticipacao ? 0.25 : 0;

            _contexto.Servico.Classificacao = (100m * apolice.QtdVidas) * (decimal)(1d + fator);
        }
    }
}

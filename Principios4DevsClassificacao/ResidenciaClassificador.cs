namespace Principios4DevsClassificacao
{
    internal class ResidenciaClassificador : Classificador
    {
        public ResidenciaClassificador(IClassificacaoContexto contexto) : base(contexto)
        {

        }

        public override void Classificar(Apolice apolice)
        {
            _contexto.Log("Classificando apólice Residencia...");
            _contexto.Log("Validando apólice.");

            if (apolice.ValorTitulo == 0 || apolice.ValorVenal == 0)
            {
                _contexto.Log("Apólice Residencia deve especificar um valor de título ou valor venal.");
                return;
            }
            if (apolice.ValorTitulo < 0.8m * apolice.ValorVenal)
            {
                _contexto.Log("Valor insuficiente.");
                return;
            }

            _contexto.Servico.Classificacao = apolice.ValorTitulo * 0.05m;
        }
    }
}

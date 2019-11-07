namespace Principios4DevsClassificacao
{
    internal class AutoClassificador : Classificador
    {
        public AutoClassificador(IClassificacaoContexto contexto) : base(contexto)
        {

        }

        public override void Classificar(Apolice apolice)
        {
            _contexto.Log("Classificando apólice Auto...");
            _contexto.Log("Validando apólice.");

            if (string.IsNullOrEmpty(apolice.Marca))
            {
                _contexto.Log("Apólice Auto deve especificar uma marca.");
                return;
            }

            if (apolice.Marca == "BMW")
            {
                if (apolice.Dedutivel < 500)
                {
                    _contexto.Servico.Classificacao = 1000m;
                }
                else
                    _contexto.Servico.Classificacao = 900m;
            }
        }
    }
}

namespace Principios4DevsClassificacao
{
    internal class DesconhecidoClassificador : Classificador
    {
        public DesconhecidoClassificador(IClassificacaoContexto contexto) : base(contexto)
        {
        }

        public override void Classificar(Apolice apolice)
        {
            _contexto.Log("Tipo de apólice desconhecida.");
        }
    }
}

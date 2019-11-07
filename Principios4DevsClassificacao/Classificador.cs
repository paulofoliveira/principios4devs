namespace Principios4DevsClassificacao
{
    internal abstract class Classificador
    {
        protected readonly IClassificacaoContexto _contexto;

        public Classificador(IClassificacaoContexto contexto)
        {
            _contexto = contexto;
        }

        public abstract void Classificar(Apolice apolice);
    }
}

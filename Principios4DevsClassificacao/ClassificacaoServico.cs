namespace Principios4DevsClassificacao
{
    internal class ClassificacaoServico
    {
        public ClassificacaoServico()
        {
            Contexto.Servico = this;
        }

        public IClassificacaoContexto Contexto { get; set; } = new ClassificacaoPadraoContexto();
        
        public decimal Classificacao { get; set; }

        public void Classificar()
        {         
            Contexto.Log("Iniciando classificação.");

            Contexto.Log("Carregando apólice.");

            var apoliceJson = Contexto.RecuperarApoliceDaFonte();

            var apolice = Contexto.RecuperarPorJsonString(apoliceJson);

            var classificador = Contexto.CriarClassificadorPorApolice(apolice, Contexto);

            classificador.Classificar(apolice);

            Contexto.Log("Classificação completada.");
        }
    }
}

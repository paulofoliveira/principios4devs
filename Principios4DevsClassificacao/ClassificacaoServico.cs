namespace Principios4DevsClassificacao
{
    internal class ClassificacaoServico
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public ApoliceArquivoFonte Fonte { get; set; } = new ApoliceArquivoFonte();
        public ApoliceSerializador Serializador { get; set; } = new ApoliceSerializador();
        public decimal Classificacao { get; set; }

        public void Classificar()
        {
            Logger.Log("Iniciando classificação.");

            Logger.Log("Carregando apólice.");

            var apoliceJson = Fonte.RecuperarApoliceDaFonte();

            var apolice = Serializador.RecuperarPorJsonString(apoliceJson);

            var fabricaDeClassificadores = new ClassificadorFabrica();

            var classificador = fabricaDeClassificadores.Criar(apolice, this);

            classificador.Classificar(apolice);
          
            Logger.Log("Classificação completada.");
        }
    }
}

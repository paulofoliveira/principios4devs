using System;

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

            switch (apolice.Tipo)
            {
                case ApoliceTipo.Vida:

                    var classificador1 = new VidaClassificador(this, Logger);
                    classificador1.Classificar(apolice);

                    break;
                case ApoliceTipo.Residencia:

                    var classificador2 = new ResidenciaClassificador(this, Logger);
                    classificador2.Classificar(apolice);

                    break;
                case ApoliceTipo.Automovel:

                    var classificador3 = new AutoClassificador(this, Logger);
                    classificador3.Classificar(apolice);

                    break;
                default:
                    Logger.Log("Apólice não encontrada.");
                    break;
            }

            Logger.Log("Classificação completada.");
        }
    }
}

using System.IO;

namespace Principios4DevsClassificacao
{
    internal interface IApoliceArquivoFonte
    {
        string RecuperarApoliceDaFonte();
    }

    internal class ApoliceArquivoFonte
    {
        public string RecuperarApoliceDaFonte()
        {
            return File.ReadAllText("apolice.json");
        }
    }
}

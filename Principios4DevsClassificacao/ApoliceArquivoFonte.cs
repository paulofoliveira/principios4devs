﻿using System.IO;

namespace Principios4DevsClassificacao
{
    internal class ApoliceArquivoFonte
    {
        public string RecuperarApoliceDaFonte()
        {
            return File.ReadAllText("apolice.json");
        }
    }
}
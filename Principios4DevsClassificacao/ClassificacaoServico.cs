using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace Principios4DevsClassificacao
{
    internal class ClassificacaoServico
    {
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public ApoliceArquivoFonte ApoliceFonte { get; set; } = new ApoliceArquivoFonte();

        public decimal Classificacao { get; set; }

        public void Classificar()
        {
            Logger.Log("Iniciando classificação.");

            Logger.Log("Carregando apólice.");

            var apoliceJson = ApoliceFonte.RecuperarApoliceDaFonte();

            var apolice = JsonConvert.DeserializeObject<Apolice>(apoliceJson, new StringEnumConverter());

            switch (apolice.Tipo)
            {
                case ApoliceTipo.Vida:
                    Logger.Log("Classificando apólice Vida...");
                    Logger.Log("Validando apólice.");

                    if (apolice.DataNascimento == DateTime.MinValue)
                    {
                        Logger.Log("Apólice de vida deve conter data de nascimento.");
                        return;
                    }

                    if (apolice.DataNascimento < DateTime.Today.AddYears(-100))
                    {
                        Logger.Log("Pessoas centenárias não são permitidas.");
                        return;
                    }

                    if (apolice.Total == 0)
                    {
                        Logger.Log("Apólice de vida deve conter total.");
                        return;
                    }

                    var idade = DateTime.Today.Year - apolice.DataNascimento.Year;

                    if (apolice.DataNascimento.Month == DateTime.Today.Month &&
                         DateTime.Today.Day < apolice.DataNascimento.Day ||
                         DateTime.Today.Month < apolice.DataNascimento.Month)
                    {
                        idade--;
                    }

                    decimal baseClassificacao = apolice.Total * idade / 200;

                    if (apolice.Fumante)
                    {
                        Classificacao = baseClassificacao * 2;
                        break;
                    }

                    Classificacao = baseClassificacao;

                    break;
                case ApoliceTipo.Residencia:

                    Logger.Log("Classificando apólice Residencia...");
                    Logger.Log("Validando apólice.");

                    if (apolice.ValorTitulo == 0 || apolice.ValorVenal == 0)
                    {
                        Logger.Log("Apólice Residencia deve especificar um valor de título ou valor venal.");
                        return;
                    }
                    if (apolice.ValorTitulo < 0.8m * apolice.ValorVenal)
                    {
                        Logger.Log("Valor insuficiente.");
                        return;
                    }

                    Classificacao = apolice.ValorTitulo * 0.05m;

                    break;
                case ApoliceTipo.Automovel:

                    Logger.Log("Classificando apólice Auto...");
                    Logger.Log("Validando apólice.");

                    if (string.IsNullOrEmpty(apolice.Marca))
                    {
                        Logger.Log("Apólice Auto deve especificar uma marca.");
                        return;
                    }

                    if (apolice.Marca == "BMW")
                    {
                        if (apolice.Dedutivel < 500)
                        {
                            Classificacao = 1000m;
                        }
                        else
                            Classificacao = 900m;
                    }

                    break;
                default:
                    Logger.Log("Apólice não encontrada.");
                    break;
            }

            Logger.Log("Classificação completada.");
        }
    }
}

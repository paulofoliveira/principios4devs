using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace Principios4DevsClassificacao
{
    internal class ClassificacaoServico
    {
        public decimal Classificacao { get; set; }

        public void Classificar()
        {
            Console.WriteLine("Iniciando classificação.");

            Console.WriteLine("Carregando apólice.");

            var apoliceJson = File.ReadAllText("apolice.json");

            var apolice = JsonConvert.DeserializeObject<Apolice>(apoliceJson, new StringEnumConverter());

            switch (apolice.Tipo)
            {
                case ApoliceTipo.Vida:
                    Console.WriteLine("Classificando apólice Vida...");
                    Console.WriteLine("Validando apólice.");

                    if (apolice.DataNascimento == DateTime.MinValue)
                    {
                        Console.WriteLine("Apólice de vida deve conter data de nascimento.");
                        return;
                    }

                    if (apolice.DataNascimento < DateTime.Today.AddYears(-100))
                    {
                        Console.WriteLine("Pessoas centenárias não são permitidas.");
                        return;
                    }

                    if (apolice.Total == 0)
                    {
                        Console.WriteLine("Apólice de vida deve conter total.");
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

                    Console.WriteLine("Classificando apólice Residencia...");
                    Console.WriteLine("Validando apólice.");

                    if (apolice.ValorTitulo == 0 || apolice.ValorVenal == 0)
                    {
                        Console.WriteLine("Apólice Residencia deve especificar um valor de título ou valor venal.");
                        return;
                    }
                    if (apolice.ValorTitulo < 0.8m * apolice.ValorVenal)
                    {
                        Console.WriteLine("Valor insuficiente.");
                        return;
                    }

                    Classificacao = apolice.ValorTitulo * 0.05m;

                    break;
                case ApoliceTipo.Automovel:

                    Console.WriteLine("Classificando apólice Auto...");
                    Console.WriteLine("Validando apólice.");

                    if (string.IsNullOrEmpty(apolice.Marca))
                    {
                        Console.WriteLine("Apólice Auto deve especificar uma marca.");
                        return;
                    }

                    if (apolice.Marca == "BMW")
                    {
                        if (apolice.Dedutivel < 500)
                        {
                            Classificacao = 1000m;
                        }

                        Classificacao = 900m;
                    }

                    break;
                default:
                    Console.WriteLine("Apólice não encontrada.");
                    break;
            }
        }
    }
}

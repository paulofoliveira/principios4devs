using System;

namespace Principios4DevsClassificacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Principios4DevsClassificacao iniciando...");

            var servico = new ClassificacaoServico();

            servico.Classificar();

            if (servico.Classificacao > 0)
            {
                Console.WriteLine($"Classificação: {servico.Classificacao}");
            }
            else
            {
                Console.WriteLine("Nenhuma classificação foi produzida");
            }

            Console.ReadKey();
        }
    }
}

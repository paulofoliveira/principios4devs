using System;

namespace ProblemaClassicoCalculoDaArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo x = new Quadrado();
          
            x.Largura = 4;
            x.Altura = 5;

            var resultado = AreaCalculadora.CalcularArea(x);

            // Esperado = 20 pois o subtipo é um retângulo, mesmo instânciando um quadrado.

            Console.WriteLine($"Resultado: {resultado}");
            Console.ReadKey();
        }
    }
}

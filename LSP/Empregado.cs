using System;

namespace LSP
{
    internal class Empregado
    {
        public string Nome { get; set; }
        public virtual decimal Salario => 5000;

        public void Imprimir()
        {
            Console.WriteLine(this);
        }
    }
}

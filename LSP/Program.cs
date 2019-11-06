using System;
using System.Collections.Generic;

namespace LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            var empregados = new List<Empregado>();

            empregados.Add(new Empregado() { Nome = "Paulo" });
            empregados.Add(new Empregado() { Nome = "João" });
            empregados.Add(new Empregado() { Nome = "Daniel" });
            empregados.Add(new Gerente() { Nome = "Diego" });

            #region Type Checking

            // Forma errada:

            foreach (var empregado in empregados)
            {
                if (empregado is Gerente)
                {
                    Helpers.ImprimirGerente(empregado as Gerente);
                    continue;
                }

                Helpers.ImprimirEmpregado(empregado);
            }

            // Forma correta:

            foreach (var empregado in empregados)
            {
                empregado.Imprimir();
            }

            // OU

            foreach (var empregado in empregados)
            {
                Helpers.ImprimirEmpregado(empregado);
            }

            #endregion

            #region Null Checking

            // Null Checking

            foreach (var empregado in empregados)
            {
                if (empregado == null)
                {
                    Console.WriteLine("Empregado não encontrado.");
                    continue;
                }
            }

            // Neste caso é melhor usar o Type Checking

            foreach (var empregado in empregados)
            {
                if (empregado is Gerente)
                {
                    Console.WriteLine("Empregado é um gerente.");
                }
            }

            #endregion



        }
    }
}

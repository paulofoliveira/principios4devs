using System;

namespace SRP
{
    internal class CalculadoraDeSalario02
    {
        public decimal Calcula(Funcionario funcionario)
        {
            if (Cargo.Desenvolvedor.Equals(funcionario.GetCargo()))
                return new DezOuVintePorCentoRegraDeCalculo().Calcular(funcionario);

            if (Cargo.DBA.Equals(funcionario.GetCargo()) || Cargo.Tester.Equals(funcionario.GetCargo()))
                return new QuinzeOuVinceCincoPorCentoRegraDeCalculo().Calcular(funcionario);

            throw new Exception("Funcionário inválido.");
        }
    }
}

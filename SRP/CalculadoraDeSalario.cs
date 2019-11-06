using System;

namespace SRP
{
    class CalculadoraDeSalario
    {
        public decimal Calcula(Funcionario funcionario)
        {
            if (Cargo.Desenvolvedor.Equals(funcionario.GetCargo()))
                return DezOuVintePorCento(funcionario);

            if (Cargo.DBA.Equals(funcionario.GetCargo()) || Cargo.Tester.Equals(funcionario.GetCargo()))
                return QuinzeOuVinteCincoPorCento(funcionario);

            throw new Exception("Funcionário inválido.");
        }

        private decimal QuinzeOuVinteCincoPorCento(Funcionario funcionario)
        {
            // Lógica para calculo de 15 a 25%
            throw new NotImplementedException();
        }

        private decimal DezOuVintePorCento(Funcionario funcionario)
        {
            // Lógica para calculo de 10 a 20%
            throw new NotImplementedException();
        }
    }
}

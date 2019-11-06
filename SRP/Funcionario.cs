namespace SRP
{
    internal class Funcionario
    {
        private Cargo _cargo;
        public string Nome { get; set; }
        public Cargo GetCargo() => _cargo;
    }
}

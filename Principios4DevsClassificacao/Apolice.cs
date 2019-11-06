using System;

namespace Principios4DevsClassificacao
{
    internal class Apolice
    {
        public ApoliceTipo Tipo { get; set; }

        #region Vida
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Fumante { get; set; }
        public decimal Total { get; set; }

        #endregion

        #region Residencia

        public string Endereco { get; set; }
        public decimal Tamanho { get; set; }
        public decimal ValorVenal { get; set; }
        public decimal ValorTitulo { get; set; }

        #endregion

        #region Automovel

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public decimal Dedutivel { get; set; }

        #endregion

        #region Saude
        public int QtdVidas { get; set; }
        public bool Cooparticipacao { get; set; }

        #endregion

    }
}

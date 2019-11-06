using System;

namespace Principios4DevsClassificacao
{
    internal class ClassificadorFabrica
    {
        public Classificador Criar(Apolice apolice, ClassificacaoServico servico)
        {
            try
            {
                return (Classificador)Activator.CreateInstance(Type.GetType($"Principios4DevsClassificacao.{apolice.Tipo}Classificador"),
                    new object[] { servico, servico.Logger });
            }
            catch
            {
                return new DesconhecidoClassificador(servico, servico.Logger);
            }
        }
    }
}

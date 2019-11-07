using System;

namespace Principios4DevsClassificacao
{
    internal class ClassificadorFabrica
    {
        public Classificador Criar(Apolice apolice, IClassificacaoContexto contexto)
        {
            try
            {
                return (Classificador)Activator.CreateInstance(Type.GetType($"Principios4DevsClassificacao.{apolice.Tipo}Classificador"),
                    new object[] { contexto });
            }
            catch
            {
                return new DesconhecidoClassificador(contexto);
            }
        }
    }
}

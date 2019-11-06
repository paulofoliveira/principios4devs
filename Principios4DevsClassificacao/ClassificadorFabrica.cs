namespace Principios4DevsClassificacao
{
    internal class ClassificadorFabrica
    {
        public Classificador Criar(Apolice apolice, ClassificacaoServico servico)
        {
            switch (apolice.Tipo)
            {
                case ApoliceTipo.Vida:
                    return new VidaClassificador(servico, servico.Logger);

                case ApoliceTipo.Residencia:
                    return new ResidenciaClassificador(servico, servico.Logger);

                case ApoliceTipo.Automovel:
                    return new AutoClassificador(servico, servico.Logger);

                default:
                    return null;
            }
        }
    }
}

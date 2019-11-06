namespace ProblemaClassicoCalculoDaArea
{
    // Quadrado como subtipo do Retangulo.

    internal class Quadrado : Retangulo
    {
        private int _altura;
        private int _largura;

        public override int Altura
        {
            get { return _altura; }
            set
            {
                _altura = value;
                _largura = value;
            }
        }

        public override int Largura
        {
            get { return _largura; }
            set
            {
                _largura = value;
                _altura = value;            
            }
        }
    }
}

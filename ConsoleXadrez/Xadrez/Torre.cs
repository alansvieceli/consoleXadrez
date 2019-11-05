using Tabuleiro;

namespace Xadrez {
    class Torre : Peca {

        private enum IncQualCampo {
            LINHA,
            COLUNA
        }

        public Torre(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "T";
        }

        private void verificarPecas(int linha, int coluna, Posicao pos, bool[,] matriz, IncQualCampo inc, int valorInc) {
            pos.definirValores(linha, coluna);
            while (base.tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                Peca peca = base.tabuleiro.getPeca(pos);
                if ((peca != null) && (peca.cor != cor)) {
                    break; //má pratica
                }

                if (inc.Equals(IncQualCampo.LINHA))
                    pos.linha = pos.linha + valorInc;
                else
                    pos.coluna = pos.coluna + valorInc;
            }
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matriz = new bool[base.tabuleiro.linhas, base.tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            verificarPecas(base.posicao.linha - 1, base.posicao.coluna, pos, matriz, IncQualCampo.LINHA, -1);

            //abaixo
            verificarPecas(base.posicao.linha + 1, base.posicao.coluna, pos, matriz, IncQualCampo.LINHA, 1);

            //direita
            verificarPecas(base.posicao.linha, base.posicao.coluna + 1, pos, matriz, IncQualCampo.COLUNA, 1);

            //esquerda
            verificarPecas(base.posicao.linha, base.posicao.coluna - 1, pos, matriz, IncQualCampo.COLUNA, -1);

            return matriz;
        }
    }
}

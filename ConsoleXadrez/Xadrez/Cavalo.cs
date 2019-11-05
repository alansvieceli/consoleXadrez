using Tabuleiro;

namespace Xadrez {

    class Cavalo : Peca {

        public Cavalo(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "C";
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[base.tabuleiro.linhas, base.tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);
            if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
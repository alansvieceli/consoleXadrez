using Tabuleiro;

namespace Xadrez {
    class Peao : Peca {

        private PartidaXadrez partida;

        public Peao(Tabuleiro.Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = base.tabuleiro.getPeca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos) {
            return base.tabuleiro.getPeca(pos) == null;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[base.tabuleiro.linhas, base.tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Vermelha) {
                pos.definirValores(base.posicao.linha - 1, base.posicao.coluna);
                if (base.tabuleiro.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha - 2, base.posicao.coluna);
                Posicao p2 = new Posicao(base.posicao.linha - 1, base.posicao.coluna);
                if (base.tabuleiro.posicaoValida(p2) && livre(p2) && base.tabuleiro.posicaoValida(pos) && livre(pos) && base.qtdeMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha - 1, base.posicao.coluna - 1);
                if (base.tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha - 1, base.posicao.coluna + 1);
                if (base.tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaespecial en passant
                if (base.posicao.linha == 3) {
                    Posicao esquerda = new Posicao(base.posicao.linha, base.posicao.coluna - 1);
                    if (base.tabuleiro.posicaoValida(esquerda) && existeInimigo(esquerda)) {
                        mat[esquerda.linha - 1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(base.posicao.linha, base.posicao.coluna + 1);
                    if (base.tabuleiro.posicaoValida(direita) && existeInimigo(direita)) {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            } else {
                pos.definirValores(base.posicao.linha + 1, base.posicao.coluna);
                if (base.tabuleiro.posicaoValida(pos) && livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha + 2, base.posicao.coluna);
                Posicao p2 = new Posicao(base.posicao.linha + 1, base.posicao.coluna);
                if (base.tabuleiro.posicaoValida(p2) && livre(p2) && base.tabuleiro.posicaoValida(pos) && livre(pos) && base.qtdeMovimentos == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha + 1, base.posicao.coluna - 1);
                if (base.tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(base.posicao.linha + 1, base.posicao.coluna + 1);
                if (base.tabuleiro.posicaoValida(pos) && existeInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;
        }
    }
}
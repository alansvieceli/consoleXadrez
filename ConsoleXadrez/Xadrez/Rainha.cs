using Tabuleiro;

namespace Xadrez {
    class Rainha : Peca {
        private enum IncQualCampo {
            LINHA,
            COLUNA,
            NE,
            NO,
            SE,
            SO
        }

        public Rainha(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "D";
        }

        private void verificarPecas(int linha, int coluna, Posicao pos, bool[,] matriz, IncQualCampo inc, int valorInc) {
            pos.definirValores(linha, coluna);
            while (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
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

        private void verificarPecas(int linha, int coluna, Posicao pos, bool[,] matriz, IncQualCampo inc) {
            pos.definirValores(linha, coluna);
            while (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                Peca peca = base.tabuleiro.getPeca(pos);
                if ((peca != null) && (peca.cor != cor)) {
                    break; //má pratica
                }

                switch (inc) {
                    case IncQualCampo.NE:
                        pos.linha--;
                        pos.coluna++;
                        break;
                    case IncQualCampo.NO:
                        pos.linha--;
                        pos.coluna--;
                        break;
                    case IncQualCampo.SE:
                        pos.linha++;
                        pos.coluna++;
                        break;
                    case IncQualCampo.SO:
                        pos.linha++;
                        pos.coluna--;
                        break;
                }
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

            //nordeste
            verificarPecas(base.posicao.linha - 1, base.posicao.coluna + 1, pos, matriz, IncQualCampo.NE);

            //noroeste
            verificarPecas(base.posicao.linha - 1, base.posicao.coluna - 1, pos, matriz, IncQualCampo.NO);

            //sudeste
            verificarPecas(base.posicao.linha + 1, base.posicao.coluna + 1, pos, matriz, IncQualCampo.SE);

            //sudoeste
            verificarPecas(base.posicao.linha + 1, base.posicao.coluna - 1, pos, matriz, IncQualCampo.SO);

            return matriz;
        }
    }
}

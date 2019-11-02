using System;
using Tabuleiro;

namespace Xadrez {
    class Bispo : Peca {

        private enum IncQualCampo {
            NE,
            NO,
            SE,
            SO
        }

        public Bispo(Tabuleiro.Tabuleiro tabuleiro, Tabuleiro.Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "B";
        }

        private void verificarPecas(int linha, int coluna, Posicao pos, bool[,] matriz, IncQualCampo inc) {
            pos.definirValores(linha, coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                matriz[pos.linha, pos.coluna] = true;
                Peca peca = tabuleiro.getPeca(pos);
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
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //nordeste
            verificarPecas(base.posicao.linha - 1 , base.posicao.coluna + 1, pos, matriz, IncQualCampo.NE);

            //noroeste
            verificarPecas(base.posicao.linha -1,  base.posicao.coluna - 1, pos, matriz, IncQualCampo.NO);

            //sudeste
            verificarPecas(base.posicao.linha + 1, base.posicao.coluna + 1, pos, matriz, IncQualCampo.SE);

            //sudoeste
            verificarPecas(base.posicao.linha + 1, base.posicao.coluna - 1, pos, matriz, IncQualCampo.SO);

            return matriz;

        }
    }
}

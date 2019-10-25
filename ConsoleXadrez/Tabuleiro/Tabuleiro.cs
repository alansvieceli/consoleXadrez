using System;

namespace Tabuleiro {
    class Tabuleiro {

        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }

        public Peca getPeca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public Peca getPeca(Posicao pos) {
            return pecas[pos.linha, pos.coluna];
        }

        public void addPeca(Peca p, Posicao pos) {

            if (existePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return getPeca(pos) != null;
        }

        public bool posicaoValida(Posicao pos) {
            return !((pos.linha < 0) || (pos.linha >= linhas) || (pos.coluna < 0) || (pos.coluna >= colunas));
        }

        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida");
            }
        }
    }
}

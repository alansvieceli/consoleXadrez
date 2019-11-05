using System;


namespace Tabuleiro {
    abstract class Peca {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdeMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qtdeMovimentos = 0;
        }

        protected bool podeMover(Posicao pos) {
            Peca p = this.tabuleiro.getPeca(pos);
            return (p == null) || (p.cor != this.cor);
        }

        public void incrementarQtdeMovimentos() {
            this.qtdeMovimentos++;
        }

        public void decrementarQtdeMovimentos() {
            this.qtdeMovimentos--;
        }

        public bool existeMovimentosPossiveis() {
            bool[,] matrix = movimentosPossiveis();

            for (int l = 0; l < this.tabuleiro.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < this.tabuleiro.colunas; c++) {
                    if (matrix[l,c]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}

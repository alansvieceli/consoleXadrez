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
            Peca p = tabuleiro.getPeca(pos);
            return (p == null) || (p.cor != this.cor);
        }

        public void incrementarQtdeMovimentos() {
            qtdeMovimentos++;

        }

        public bool existeMovimentosPossiveis() {
            bool[,] matrix = movimentosPossiveis();

            for (int l = 0; l < tabuleiro.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tabuleiro.colunas; c++) {
                    if (matrix[l,c]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}

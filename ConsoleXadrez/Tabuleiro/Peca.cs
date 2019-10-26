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

        public abstract bool[,] movimentosPossiveis();
    }
}

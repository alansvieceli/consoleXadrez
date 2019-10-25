using System;
using Tabuleiro;

namespace Xadrez {
    class PartidaXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogador;

        public PartidaXadrez() {
            this.tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            this.turno = 1;
            this.jogador = Cor.Branca; //no xadrez sempre quem inicia são as brancas
            colocarPecas();
        }

        private void colocarPecas() {
            tabuleiro.addPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 4).toPosicao());
        }

        public void executarMovimento(Posicao posOrigem, Posicao posDestino) {
            Peca p = tabuleiro.removePeca(posOrigem);
            p.incrementarQtdeMovimentos();

            Peca capturada = tabuleiro.removePeca(posDestino);
            tabuleiro.addPeca(p, posDestino);

        }

    }
}

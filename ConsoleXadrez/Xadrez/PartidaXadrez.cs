using System;
using Tabuleiro;

namespace Xadrez {
    class PartidaXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaXadrez() {
            this.tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca; //no xadrez sempre quem inicia são as brancas
            this.terminada = false;
            colocarPecas();
        }

        private void colocarPecas() {
            tabuleiro.addPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 4).toPosicao());
            tabuleiro.addPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('f', 3).toPosicao());
        }

        public void realizaJogada(Posicao posOrigem, Posicao posDestino) {
            executarMovimento(posOrigem, posDestino);
            turno++;
            mudaJogador();
        }

        public void validarPosicaoOrigem(Posicao pos) {

            Peca p = tabuleiro.getPeca(pos);
            if (p == null) {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }

            if (p.cor != jogadorAtual) {
                throw new TabuleiroException("A Peça escolhida não é sua.");
            }

            if (!p.existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não existe movimentos possíveis para peça");
            }

        }

        private void mudaJogador() {
            Cor novaCor = (jogadorAtual == Cor.Branca) ? Cor.Preta : Cor.Branca;
            jogadorAtual = novaCor;
        }

        private void executarMovimento(Posicao posOrigem, Posicao posDestino) {
            Peca p = tabuleiro.removePeca(posOrigem);
            p.incrementarQtdeMovimentos();

            Peca capturada = tabuleiro.removePeca(posDestino);
            tabuleiro.addPeca(p, posDestino);

        }

    }
}

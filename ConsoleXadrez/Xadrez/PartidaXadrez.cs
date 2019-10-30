using System;
using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez {
    class PartidaXadrez {

        public Tabuleiro.Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez() {
            this.tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca; //no xadrez sempre quem inicia são as brancas
            this.terminada = false;
            this.pecas = new HashSet<Peca>();
            this.capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in this.capturadas) {
                if (p.cor.Equals(cor)) {
                    aux.Add(p);
                }

            }

            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in this.pecas) {
                if (p.cor.Equals(cor)) {
                    aux.Add(p);
                }

            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colorNovaPeca(Peca peca, char coluna, int linha) {
            this.tabuleiro.addPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() {

            colorNovaPeca(new Torre(this.tabuleiro, Cor.Preta), 'a', 8);
            colorNovaPeca(new Torre(this.tabuleiro, Cor.Preta), 'h', 8);
            colorNovaPeca(new Rei(this.tabuleiro, Cor.Preta), 'e', 8);


            colorNovaPeca(new Torre(this.tabuleiro, Cor.Branca), 'a', 1);
            colorNovaPeca(new Torre(this.tabuleiro, Cor.Branca), 'h', 1);
            colorNovaPeca(new Rei(this.tabuleiro, Cor.Branca), 'e', 1);

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

            if (p.cor != this.jogadorAtual) {
                throw new TabuleiroException("A Peça escolhida não é sua.");
            }

            if (!p.existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não existe movimentos possíveis para peça");
            }

        }

        public void ValidarPosicaoDestino(Posicao posOrigem, Posicao posDestino) {
            if (!tabuleiro.getPeca(posOrigem).podeMoverPara(posDestino)) {
                throw new TabuleiroException("Posição destino inválida!");
            }

        }

        private void mudaJogador() {
            Cor novaCor = (this.jogadorAtual == Cor.Branca) ? Cor.Preta : Cor.Branca;
            this.jogadorAtual = novaCor;
        }

        private void executarMovimento(Posicao posOrigem, Posicao posDestino) {
            Peca p = tabuleiro.removePeca(posOrigem);
            p.incrementarQtdeMovimentos();

            Peca capturada = tabuleiro.removePeca(posDestino);
            tabuleiro.addPeca(p, posDestino);

            if (capturada != null) {
                capturadas.Add(capturada);
            }

        }

    }
}

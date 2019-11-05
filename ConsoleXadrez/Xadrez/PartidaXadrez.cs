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
        public bool xeque { get; private set; }

        public PartidaXadrez() {
            this.tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Vermelha; //no xadrez sempre quem inicia são as Vermelhas
            this.terminada = false;
            this.pecas = new HashSet<Peca>();
            this.capturadas = new HashSet<Peca>();
            this.xeque = false;
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

        public void realizaJogada(Posicao posOrigem, Posicao posDestino) {
            Peca capturda = executarMovimento(posOrigem, posDestino);

            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(posOrigem, posDestino, capturda);
                throw new TabuleiroException("Você não se pode colocar em cheque!");
            }

            this.xeque = estaEmXeque(corAdversaria(jogadorAtual));

            if (estaEmXequeMate(corAdversaria(jogadorAtual))) {
                this.terminada = true;
            } else {
                turno++;
                mudaJogador();
            }

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
            if (!tabuleiro.getPeca(posOrigem).movimentoPossivel(posDestino)) {
                throw new TabuleiroException("Posição destino inválida!");
            }

        }

        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca p in pecasEmJogo(corAdversaria(cor))) {
                bool[,] mat = p.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }

        public bool estaEmXequeMate(Cor cor) {
            if (!estaEmXeque(cor)) {
                return false;
            }

            foreach (Peca p in pecasEmJogo(cor)) {
                bool[,] mat = p.movimentosPossiveis();

                for (int l = 0; l < this.tabuleiro.linhas; l++) {

                    for (int c = 0; c < this.tabuleiro.colunas; c++) {
                        if (mat[l, c]) {
                            Posicao origem = p.posicao;
                            Posicao destino = new Posicao(l, c);
                            Peca pecaCapturada = executarMovimento(origem, destino);

                            bool xeque = estaEmXeque(cor);

                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!xeque) {
                                return false;
                            }
                        }
                    }
                }

            }

            return true;
        }

        private void colocarPecas() {

            colorNovaPeca(new Torre(this.tabuleiro, Cor.Verde), 'a', 8);
            colorNovaPeca(new Cavalo(this.tabuleiro, Cor.Verde), 'b', 8);
            colorNovaPeca(new Bispo(this.tabuleiro, Cor.Verde), 'c', 8);
            colorNovaPeca(new Rainha(this.tabuleiro, Cor.Verde), 'd', 8);
            colorNovaPeca(new Rei(this.tabuleiro, Cor.Verde), 'e', 8);
            colorNovaPeca(new Bispo(this.tabuleiro, Cor.Verde), 'f', 8);
            colorNovaPeca(new Cavalo(this.tabuleiro, Cor.Verde), 'g', 8);
            colorNovaPeca(new Torre(this.tabuleiro, Cor.Verde), 'h', 8);

            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'a', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'b', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'c', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'd', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'e', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'f', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'g', 7);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Verde, this), 'h', 7);


            colorNovaPeca(new Torre(this.tabuleiro, Cor.Vermelha), 'a', 1);
            colorNovaPeca(new Cavalo(this.tabuleiro, Cor.Vermelha), 'b', 1);
            colorNovaPeca(new Bispo(this.tabuleiro, Cor.Vermelha), 'c', 1);
            colorNovaPeca(new Rainha(this.tabuleiro, Cor.Vermelha), 'd', 1);
            colorNovaPeca(new Rei(this.tabuleiro, Cor.Vermelha), 'e', 1);
            colorNovaPeca(new Bispo(this.tabuleiro, Cor.Vermelha), 'f', 1);
            colorNovaPeca(new Cavalo(this.tabuleiro, Cor.Vermelha), 'g', 1);
            colorNovaPeca(new Torre(this.tabuleiro, Cor.Vermelha), 'h', 1);

            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'a', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'b', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'c', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'd', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'e', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'f', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'g', 2);
            colorNovaPeca(new Peao(this.tabuleiro, Cor.Vermelha, this), 'h', 2);

        }

        private void mudaJogador() {
            Cor novaCor = (this.jogadorAtual == Cor.Vermelha) ? Cor.Verde : Cor.Vermelha;
            this.jogadorAtual = novaCor;
        }

        private Peca executarMovimento(Posicao posOrigem, Posicao posDestino) {
            Peca p = tabuleiro.removePeca(posOrigem);
            p.incrementarQtdeMovimentos();

            Peca capturada = tabuleiro.removePeca(posDestino);
            tabuleiro.addPeca(p, posDestino);

            if (capturada != null) {
                capturadas.Add(capturada);
            }

            return capturada;
        }

        private void desfazMovimento(Posicao posOrigem, Posicao posDestino, Peca capturada) {
            Peca p = tabuleiro.removePeca(posDestino);
            p.decrementarQtdeMovimentos();

            if (capturada != null) {
                tabuleiro.addPeca(capturada, posDestino);
                capturadas.Remove(capturada);
            }

            tabuleiro.addPeca(p, posOrigem);

        }

        private Cor corAdversaria(Cor cor) {

            return cor.Equals(Cor.Vermelha) ? Cor.Verde : Cor.Vermelha;

        }

        private Rei rei(Cor cor) {
            foreach (Peca p in pecasEmJogo(cor)) {
                if (p is Rei) {
                    return (Rei)p;
                }
            }

            return null;
        }
    }
}

using System;
using Tabuleiro;

namespace Xadrez {

    class Rei : Peca {

        PartidaXadrez partida;


        private struct PosisoesTestes {
            public int linha;
            public int coluna;
        }

        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = base.tabuleiro.getPeca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdeMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matriz = new bool[base.tabuleiro.linhas, base.tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            PosisoesTestes[] direcoes = new PosisoesTestes[8];
            //Norte
            direcoes[0].linha = base.posicao.linha - 1;
            direcoes[0].coluna = base.posicao.coluna;
            //Nordeste
            direcoes[1].linha = base.posicao.linha - 1;
            direcoes[1].coluna = base.posicao.coluna + 1;
            //Leste
            direcoes[2].linha = base.posicao.linha;
            direcoes[2].coluna = base.posicao.coluna + 1;
            //Sudeste
            direcoes[3].linha = base.posicao.linha + 1;
            direcoes[3].coluna = base.posicao.coluna + 1;
            //Sul
            direcoes[4].linha = base.posicao.linha + 1;
            direcoes[4].coluna = base.posicao.coluna;
            //Sudoeste
            direcoes[5].linha = base.posicao.linha + 1;
            direcoes[5].coluna = base.posicao.coluna - 1;
            //Oeste
            direcoes[6].linha = base.posicao.linha;
            direcoes[6].coluna = base.posicao.coluna - 1;
            //Noroeste
            direcoes[7].linha = base.posicao.linha - 1;
            direcoes[7].coluna = base.posicao.coluna - 1;

            foreach (PosisoesTestes element in direcoes) {

                pos.definirValores(element.linha, element.coluna);
                if (base.tabuleiro.posicaoValida(pos) && base.podeMover(pos)) {
                    matriz[pos.linha, pos.coluna] = true;
                }

            }

            //#roque (pequeno e grande)
            // #jogadaespecial roque
            if (qtdeMovimentos == 0 && !partida.xeque) {
                // #jogadaespecial roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (base.tabuleiro.getPeca(p1) == null && base.tabuleiro.getPeca(p2) == null) {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (base.tabuleiro.getPeca(p1) == null && base.tabuleiro.getPeca(p2) == null && base.tabuleiro.getPeca(p3) == null) {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }

    }
}

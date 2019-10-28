using System;
using Tabuleiro;

namespace Xadrez {

    class Rei : Peca {

        private struct PosisoesTestes {
            public int linha;
            public int coluna;
        }

        public Rei(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "R";
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            PosisoesTestes[] direcoes = new PosisoesTestes[8];
            //Norte
            direcoes[0].linha = posicao.linha - 1;
            direcoes[0].coluna = posicao.coluna;
            //Nordeste
            direcoes[1].linha = posicao.linha - 1;
            direcoes[1].coluna = posicao.coluna + 1;
            //Leste
            direcoes[2].linha = posicao.linha;
            direcoes[2].coluna = posicao.coluna + 1;
            //Sudeste
            direcoes[3].linha = posicao.linha + 1;
            direcoes[3].coluna = posicao.coluna + 1;
            //Sul
            direcoes[4].linha = posicao.linha + 1;
            direcoes[4].coluna = posicao.coluna;
            //Sudoeste
            direcoes[5].linha = posicao.linha + 1;
            direcoes[5].coluna = posicao.coluna - 1;
            //Oeste
            direcoes[6].linha = posicao.linha;
            direcoes[6].coluna = posicao.coluna - 1;
            //Noroeste
            direcoes[7].linha = posicao.linha - 1;
            direcoes[7].coluna = posicao.coluna - 1;

            foreach (PosisoesTestes element in direcoes) {

                pos.definirValores(element.linha, element.coluna);
                if (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                    matriz[pos.linha, pos.coluna] = true;
                }

            }

            return matriz;
        }

    }
}

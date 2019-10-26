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

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.getPeca(pos);
            return (p == null) || (p.cor != this.cor);

        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            PosisoesTestes[] direcoes = new PosisoesTestes[8];
            //Norte
            direcoes[0].linha = pos.linha - 1;
            direcoes[0].coluna = pos.coluna;
            //Nordeste
            direcoes[0].linha = pos.linha - 1;
            direcoes[0].coluna = pos.coluna + 1;
            //Leste
            direcoes[0].linha = pos.linha;
            direcoes[0].coluna = pos.coluna + 1;
            //Sudeste
            direcoes[0].linha = pos.linha + 1;
            direcoes[0].coluna = pos.coluna + 1;
            //Sul
            direcoes[0].linha = pos.linha + 1;
            direcoes[0].coluna = pos.coluna;
            //Sudoeste
            direcoes[0].linha = pos.linha + 1;
            direcoes[0].coluna = pos.coluna - 1;
            //Oeste
            direcoes[0].linha = pos.linha;
            direcoes[0].coluna = pos.coluna - 1;
            //Noroeste
            direcoes[0].linha = pos.linha - 1;
            direcoes[0].coluna = pos.coluna - 1;

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

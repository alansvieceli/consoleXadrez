using System;
using Tabuleiro;

namespace Xadrez {
    class Torre : Peca {

        public Torre(Tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {

        }

        public override string ToString() {
            return "T";
        }

        public override bool[,] movimentosPossiveis() {
            throw new NotImplementedException();
        }
    }
}

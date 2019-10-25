using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleXadrez {
    class Program {
        static void Main(string[] args) {

            Tabuleiro.Tabuleiro tab = new Tabuleiro.Tabuleiro(8, 8);

            tab.addPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            tab.addPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
            tab.addPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();

        }
    }
}

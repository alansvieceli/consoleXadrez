using System;
using Tabuleiro;

namespace ConsoleXadrez {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro) {
            for (int l = 0; l < tabuleiro.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tabuleiro.colunas; c++) {

                    if (tabuleiro.getPeca(l, c) == null) {
                        Console.Write("- ");
                    } else {
                        imprimirPeca(tabuleiro.getPeca(l, c));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca p) {

            ConsoleColor c = Console.ForegroundColor;
            if (p.cor == Cor.Branca) {
                Console.ForegroundColor = ConsoleColor.Red;
            } else {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write(p);
            Console.ForegroundColor = c;

        }
    }
}

using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleXadrez {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro) {
            for (int l = 0; l < tabuleiro.linhas; l++) {
                Console.Write(8 - l + " ");
                for (int c = 0; c < tabuleiro.colunas; c++) {
                    imprimirPeca(tabuleiro.getPeca(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca p) {

            if (p == null) {
                Console.Write("- ");
            } else {
                ConsoleColor c = Console.ForegroundColor;
                if (p.cor == Cor.Branca) {
                    Console.ForegroundColor = ConsoleColor.Red;
                } else {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write(p);
                Console.ForegroundColor = c;
                Console.Write(" ");
            }

        }

        public static PosicaoXadrez lerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }
    }
}

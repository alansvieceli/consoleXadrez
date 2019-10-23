using System;
using Tabuleiro;

namespace ConsoleXadrez {
    class Tela {

        public static void imprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro) {
            for (int l = 0; l < tabuleiro.linhas; l++) {

                for (int c = 0; c < tabuleiro.colunas; c++) {

                    String texto = (tabuleiro.getPeca(l, c) == null) ? "- " : tabuleiro.getPeca(l, c) + " ";

                    Console.Write(texto);

                }
                Console.WriteLine();
            }

        }
    }
}

using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleXadrez {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaXadrez partida = new PartidaXadrez();

                Tela.imprimirTabuleiro(partida.tabuleiro);

                Console.ReadLine();
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}

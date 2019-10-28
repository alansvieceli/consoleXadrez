using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleXadrez {
    class Program {
        static void Main(string[] args) {

            try {
                PartidaXadrez partida = new PartidaXadrez();

                


                while (!partida.terminada) {

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.Write("Posicao ORIGEM: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] possicoesPossiveis = partida.tabuleiro.getPeca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro, possicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Posicao DESTINO: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executarMovimento(origem, destino);

                }

                Console.ReadLine();
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}

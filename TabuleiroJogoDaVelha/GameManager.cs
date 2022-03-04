using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabuleiroJogoDaVelha
{
   
    public static class GameManager
    {
        public static DateTime Atualizar = DateTime.Now;

        public static string jogadorAtual = "X";

        private static string[,] tabuleiro = new string[3, 3];

        public static string[,] GetTabuleiro()
        {
            return tabuleiro;
        }

        public static void ReiniciaTabuleiro()
        {
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                    tabuleiro[l, c] = "";
            jogadorAtual = "X";
        }

        public static string GetValor(int linha, int coluna)
        {
            return tabuleiro[linha, coluna];
        }
        
        public static string[,] RealizarJogada(string marcador, int linha, int coluna)
        {
            if ((marcador == null) || (marcador.Trim().Length == 0))
                throw new Exception("Jogador inválido!");
            if ((marcador != jogadorAtual) || ("X,O".Split(',').Where(p => p == marcador).Count() == 0))
                throw new Exception("Jogador inválido!");
            if (linha > 2 || coluna > 2)
                throw new Exception("Linha ou coluna inválida!");
            if (tabuleiro[linha, coluna] != "")
                throw new Exception("Campo indisponível!");

            tabuleiro[linha, coluna] = marcador.ToUpper();

            Atualizar = DateTime.Now.AddDays(1);

            jogadorAtual = jogadorAtual == "X" ? "O" : "X";

            return tabuleiro;
        }
        
        public static string VerificaVencedor()
        {
            string vencedor = Verifica("X");
            if (vencedor.Trim().Length == 0)
                vencedor = Verifica("O");

            return vencedor;
        }
        private static string Verifica(string jogador)
        {
            int pontos = 0;
            //Horizontal
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (jogador == tabuleiro[l, c])
                        pontos++;
                }
                if (pontos >= 3)
                    return jogador;
                else
                    pontos = 0;
            }

            //Vertical
            pontos = 0;
            for (int c = 0; c < 3; c++)
            {
                for (int l = 0; l < 3; l++)
                {
                    if (jogador == tabuleiro[l, c])
                        pontos++;
                }
                if (pontos >= 3)
                    return jogador;
                else
                    pontos = 0;
            }



            //diagonal principal
            pontos = 0;
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                    if(l  == c)
                        if (jogador == tabuleiro[l, c])
                            pontos++;
               
            if (pontos >= 3)
                return jogador;
  

            //diagonal secundaria
            pontos = 0;
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                    if (l + c == 3 + 1)
                        if (jogador == tabuleiro[l, c])
                            pontos++;

            if (pontos >= 3)
                return jogador;

            //se ninguem canhou
            pontos = 0;
            for (int l = 0; l < 3; l++)
                for (int c = 0; c < 3; c++)
                    if (tabuleiro[l, c].Trim().Length > 0)
                        pontos++;

            if (pontos >= 9)
                return "Ninguem venceu!";

            return "";
        }
    }
}

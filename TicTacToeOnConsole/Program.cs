using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOnConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";
            bool gameOver = false;

            //Getting player info and create player 
            Console.WriteLine("Enter Player 1 Name: ");
            playerName = Console.ReadLine();
            TicTacToe player1 = new TicTacToe("X", playerName);
            Console.WriteLine("Enter Player 2 Name: /type 'computer' for single player");
            playerName = Console.ReadLine();
            TicTacToe player2 = new TicTacToe("O", playerName);

            while(!gameOver)
            {
                //draw board
                TicTacToe.drawBoard();
                while(!player1.IsGameOver() && !player2.IsGameOver())
                {
                    gameOver = true;
                }
                if(gameOver)
                {
                    Console.WriteLine("Play Again? Press spacebar to quit");
                    if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("Game Close!");
                        Thread.Sleep(1000);
                        System.Environment.Exit(0);
                    }  
                    else
                        gameOver = false; 
                }
            }
            //pause before run new game
            Console.ReadLine();
        }
    }
}
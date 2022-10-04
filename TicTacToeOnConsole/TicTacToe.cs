using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOnConsole
{

    class TicTacToe
    {
        static string[,] gameBoard;
        string playerName;
        
        //Constructor
        public TicTacToe(string player, string playerName)
        {
            PlayerName = playerName;
            Player = player;
            gameBoard = new string[3, 3];
        }

        public string Player { get; set; }
        //Player Properties 
        public String PlayerName
        {
            get { return playerName; }
            set
            {
                //make sure the name is entered
                if (value.Length > 0)
                    playerName = value;
                else
                {
                    //make sure the name is not an empty String
                    while (value.Length < 1)
                    {
                        Console.WriteLine("Invalid Name. Try Again");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        public static void drawBoard()
        {
            //rows
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    gameBoard[row, column] = "-";
                }
            }
            //render the board after every player make a move
            BoardRenderer();
        }
        private static void BoardRenderer()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(gameBoard[row, column] + " "); //draw the board / output the board
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //checking if input ok, not out of bound !
        private bool BoardCheck(int row, int column)
        {
            bool ok = false;
            if (row < 1 || column < 1 || row > 3 || column > 3) //input out of bound
                return false;
            if (gameBoard[row - 1, column - 1] != "X" && gameBoard[row - 1, column - 1] != "O")
                ok = true;

            return ok;
        }
        //check if it is a tie
        private bool Tie()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    //not a tie
                    if (gameBoard[row, column] != "X" && gameBoard[row, column] != "O")
                        return false;
                }
            }
            return true;
        }
        private bool Win()
        {
            //check rows and columns combination
            //rows 
            if (gameBoard[0,0] == Player && gameBoard[0,1] == Player && gameBoard[0,2] == Player)
            {
                return true; 
            }
            if (gameBoard[1, 0] == Player && gameBoard[1, 1] == Player && gameBoard[1, 2] == Player)
            {
                return true;
            }
            if (gameBoard[2, 0] == Player && gameBoard[2, 1] == Player && gameBoard[2, 2] == Player)
            {
                return true;
            }
            //column
            if (gameBoard[0, 0] == Player && gameBoard[1, 0] == Player && gameBoard[2, 0] == Player)
            {
                return true;
            }
            if (gameBoard[0, 1] == Player && gameBoard[1, 1] == Player && gameBoard[2, 1] == Player)
            {
                return true;
            }
            if (gameBoard[0, 2] == Player && gameBoard[1, 2] == Player && gameBoard[2, 2] == Player)
            {
                return true;
            }
            //diagonal
            if (gameBoard[0, 0] == Player && gameBoard[1, 1] == Player && gameBoard[2, 2] == Player)
            {
                return true;
            }
            if (gameBoard[0, 2] == Player && gameBoard[1, 1] == Player && gameBoard[2, 0] == Player)
            {
                return true;
            }

            return false; 
        }
        //Check if the game is still playing 
        public bool IsGameOver()
        {
            Random rowPC = new Random();
            Random columnPC = new Random();

            int column = 0;
            int row = 0;

            
            //play with another player
            if(playerName != "computer")
            {
                Console.WriteLine("Enter Your Move: ");
                int.TryParse(Console.ReadLine().Trim(), out row);
                int.TryParse(Console.ReadLine().Trim(), out column);
            }
            //play with computer
            else
            {
                row = rowPC.Next(1, 4);
                for(int i = 0; i < 3000; i++)
                    column = columnPC.Next(1, 4);
            }
            //if player enter wrong input
            while(!BoardCheck(row,column))
            {
                //display error to player if invalid input
                if(PlayerName != "computer")
                {
                    Console.WriteLine("Invalid input, enter your move again: ");
                    int.TryParse(Console.ReadLine().Trim(), out row);
                    int.TryParse(Console.ReadLine().Trim(), out column);
                }
                //if computer, then go next move;
                else
                {
                    row = rowPC.Next(1, 4);
                    for (int i = 0; i < 3000; i++)
                        column = columnPC.Next(1, 4);
                }
            }
            //if player enter correct input 
            gameBoard[row - 1, column - 1] = Player;
            //update & render board after move;
            BoardRenderer(); 
            //check win or draw
            if(Win())
            {
                if (PlayerName == "computer")
                    Console.WriteLine("Computer Wins!");
                else
                    Console.WriteLine("Player " + PlayerName + " win!");

                return true; //game over
            }
            else if(Tie())
            {
                Console.WriteLine("It's a tie!");
                return true; //game over
            }

            return false; //game continue playing when no win or draw
        }

        
    }
}

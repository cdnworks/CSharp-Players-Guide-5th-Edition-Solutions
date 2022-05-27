// See https://aka.ms/new-console-template for more information

//this tic-tac-toe console program works as you'd expect it would
//two players take turns placing their own symbol (X or O) in an attempt to make a run of 3 in a row.
//players cannot play over another player's move
//if a player makes a run of 3 in a row, they win the game.
//if after 9 turns, with no player making 3 in a row, the game is ended in a draw or a 'cat's game'
//this program contains a number of classes to build a game of tic-tac-toe, and is initialized from main with the Run() function




//main
TicTacToeGame game = new TicTacToeGame();
game.Run();






public class TicTacToeGame
{
    //The TicTacToeGame class has many responsibilities.
    //primarily, it maintains the flow of the game
    //it checks if the game is won
    //it also knows how many rounds have passed (useful for knowing who's turn it is and if the game is a draw.)
    //it also prompts the respective player that it's their turn, and calls the renderer's DrawBoard and the player GetMove functions

    //Create a new board, renderer and players
    //set the turn number to 1.
    Board board = new Board();
    BoardRenderer renderer = new BoardRenderer();
    Player player1 = new Player() { Symbol = Space.X };
    Player player2 = new Player() { Symbol = Space.O };
    private int _turn = 1;



    public void Run()
    {
        //do game stuff here
        while ( _turn < 10 ) 
        {
            //if the game is at turn 10, end it on a draw.
            if(_turn == 10)
            {
                break;
            }


            //determine who's turn it is, then begin their turn
            //player 1 goes on odd number turns
            if( _turn % 2 != 0 )
            {
                //turn logic:
                //1. clear the console
                //2. prompt user
                //3. draw the board
                //4. get a legal move from the user
                //5. draw the board after move
                //6. check if the player wins, end if so else continue
                //7. increment turn
                Console.Clear();
                Console.WriteLine("Player 1 - It is your turn.");
                renderer.DrawBoard(board);
                player1.GetMove(board);
                renderer.DrawBoard(board);
                if (HasWon(player1))
                {
                    Console.WriteLine("Player 1 Wins!");
                    //end game
                    break;
                }
                _turn++;

            }
            else
            {
                //turn logic:
                //1. clear the console
                //2. prompt user
                //3. draw the board
                //4. get a legal move from the user
                //5. draw the board after move
                //6. check if the player wins, end if so else continue
                //7. increment turn
                Console.Clear();
                Console.WriteLine("Player 2 - It is your turn.");
                renderer.DrawBoard(board);
                player2.GetMove(board);
                renderer.DrawBoard(board);
                if (HasWon(player2))
                {
                    Console.WriteLine("Player 2 Wins!");
                    //end game
                    break;
                }
                _turn++;
            }
        }

    }

    //Gamestate check, checks for a winner (i.e. 3 symbols in a row)
    private bool HasWon(Player player)
    {
        //horizontal lines
        if (board.SpaceContains(0, 0) == player.Symbol && board.SpaceContains(0, 1) == player.Symbol && board.SpaceContains(0,2 ) == player.Symbol) return true;
        if (board.SpaceContains(1, 0) == player.Symbol && board.SpaceContains(1, 1) == player.Symbol && board.SpaceContains(1, 2) == player.Symbol) return true;
        if (board.SpaceContains(2, 0) == player.Symbol && board.SpaceContains(2, 1) == player.Symbol && board.SpaceContains(2, 2) == player.Symbol) return true;

        //vertical lines
        if (board.SpaceContains(0, 0) == player.Symbol && board.SpaceContains(1, 0) == player.Symbol && board.SpaceContains(2, 0) == player.Symbol) return true;
        if (board.SpaceContains(0, 1) == player.Symbol && board.SpaceContains(1, 1) == player.Symbol && board.SpaceContains(2, 1) == player.Symbol) return true;
        if (board.SpaceContains(0, 2) == player.Symbol && board.SpaceContains(1, 2) == player.Symbol && board.SpaceContains(2, 2) == player.Symbol) return true;

        //diagonal lines
        if (board.SpaceContains(0, 0) == player.Symbol && board.SpaceContains(1, 1) == player.Symbol && board.SpaceContains(2, 2) == player.Symbol) return true;
        if (board.SpaceContains(0, 2) == player.Symbol && board.SpaceContains(1, 1) == player.Symbol && board.SpaceContains(2, 0) == player.Symbol) return true;

        //no lines
        return false;
    }


}


public class Board
{
    //the board builds the fundemental 3x3 grid and holds the symbols
    //can return the value of a given cell
    //can determine if a given cell is empty and return a bool
    //can 'place' a symbol into a given cell


    //initialize a blank board on construction
    private Space[,] _board = new Space[3, 3];
    public Board()
    {
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                _board[i, j] = Space.Blank;
            }
        }
    }

    public Space SpaceContains (int row, int col)
    {
        //should probably protect this
        return _board[row, col];
    }

    public bool IsSpaceEmpty (int row, int col)
    {
        if (_board[row, col] == Space.Blank) return true;
        return false;
    }

    public void FillSpace (int row, int col, Space symbol)
    {
        _board[row, col] = symbol;
    }


}


public class BoardRenderer
{
    //this class exists only to draw the board using information from the Board class object, in the game handler class
    public void DrawBoard(Board board)
    {
        //convert symbol enums to strings and collect them in an 2d array to make printing easier
        string[,] symbol = new string[3, 3];

        for (int i = 0; i < symbol.GetLength(0); i++)
        {
            for (int j = 0; j < symbol.GetLength(1); j++)
            {
                if (board.IsSpaceEmpty(i,j)) symbol[i, j] = " ";
                else symbol[i, j] = Convert.ToString(board.SpaceContains(i,j));
            }
        }

        Console.WriteLine($" {symbol[0, 0]} | {symbol[0, 1]} | {symbol[0, 2]}");
        Console.WriteLine($"---#---#---");
        Console.WriteLine($" {symbol[1, 0]} | {symbol[1, 1]} | {symbol[1, 2]}");
        Console.WriteLine($"---#---#---");
        Console.WriteLine($" {symbol[2, 0]} | {symbol[2, 1]} | {symbol[2, 2]}");

    }
}

public class Player
{
    //the player class exists to instruct the player on how to make a selection and
    //then get a move from the player and put it on the board
    //the player class also contains it's identifying symbol, X or O.
    public Space Symbol { get; init; }

    public void GetMove(Board board)
    {
        Console.WriteLine("Where would you like to play?");
        Console.WriteLine(" 1 | 2 | 3 ");
        Console.WriteLine("---#---#---");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine("---#---#---");
        Console.WriteLine(" 7 | 8 | 9 ");

        //collect correct user input
        int choice;


        //update the board
        //input case
        bool invalidMove = true;
        while (invalidMove)
        {
            while (true)
            {
                Console.WriteLine("Select a space to place your mark (Enter 1-9)");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice < 1 || choice > 9) Console.WriteLine("Not a valid move.");
                else break;
            }


            switch (choice)
            {
                case 1:
                    if (board.IsSpaceEmpty(0, 0))
                    {
                        board.FillSpace(0, 0, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 2:
                    if (board.IsSpaceEmpty(0, 1))
                    {
                        board.FillSpace(0, 1, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 3:
                    if (board.IsSpaceEmpty(0, 2))
                    {
                        board.FillSpace(0, 2, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 4:
                    if (board.IsSpaceEmpty(1, 0))
                    {
                        board.FillSpace(1, 0, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 5:
                    if (board.IsSpaceEmpty(1, 1))
                    {
                        board.FillSpace(1, 1, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 6:
                    if (board.IsSpaceEmpty(1, 2))
                    {
                        board.FillSpace(1, 2, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 7:
                    if (board.IsSpaceEmpty(2, 0))
                    {
                        board.FillSpace(2, 0, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 8:
                    if (board.IsSpaceEmpty(2, 1))
                    {
                        board.FillSpace(2, 1, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
                case 9:
                    if (board.IsSpaceEmpty(2, 2))
                    {
                        board.FillSpace(2, 2, Symbol);
                        invalidMove = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Space is occupied! Try again.");
                        break;
                    }
            }
        }


    }


}


//enum definition for the 3 possible 'symbols' that occupy the board spaces.
public enum Space { X, O, Blank }
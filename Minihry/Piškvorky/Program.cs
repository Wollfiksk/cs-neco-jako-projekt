namespace Piškvorky
{
    internal class Program
    {
        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            bool gameOngoing = true;

            while (gameOngoing)
            {
                PrintBoard();
                PlayerTurn();
                gameOngoing = !CheckWin();
                if (gameOngoing)
                {
                    SwitchPlayer();
                }
            }

            PrintBoard();
            Console.WriteLine($"Hráč {currentPlayer} vyhrál!");
        }

        static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("Piškvorky 3x3");
            Console.WriteLine();
            Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
        }

        static void PlayerTurn()
        {
            int choice;
            bool validChoice = false;

            while (!validChoice)
            {
                Console.WriteLine($"\nHráč {currentPlayer}, zadejte číslo pole (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && choice >= 1 && choice <= 9)
                {
                    int row = (choice - 1) / 3;
                    int col = (choice - 1) % 3;

                    if (board[row, col] != 'X' && board[row, col] != 'O')
                    {
                        board[row, col] = currentPlayer;
                        validChoice = true;
                    }
                    else
                    {
                        Console.WriteLine("Toto pole je již obsazeno, zkuste jiné.");
                    }
                }
                else
                {
                    Console.WriteLine("Neplatná volba, zkuste to znovu.");
                }
            }
        }

        static void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        static bool CheckWin()
        {
            // Zkontrolovat řádky, sloupce a diagonály
            return (CheckRowColDiag(board[0, 0], board[0, 1], board[0, 2]) ||
                    CheckRowColDiag(board[1, 0], board[1, 1], board[1, 2]) ||
                    CheckRowColDiag(board[2, 0], board[2, 1], board[2, 2]) ||
                    CheckRowColDiag(board[0, 0], board[1, 0], board[2, 0]) ||
                    CheckRowColDiag(board[0, 1], board[1, 1], board[2, 1]) ||
                    CheckRowColDiag(board[0, 2], board[1, 2], board[2, 2]) ||
                    CheckRowColDiag(board[0, 0], board[1, 1], board[2, 2]) ||
                    CheckRowColDiag(board[0, 2], board[1, 1], board[2, 0]));
        }

        static bool CheckRowColDiag(char c1, char c2, char c3)
        {
            return (c1 == c2 && c2 == c3);
        }
    }
}

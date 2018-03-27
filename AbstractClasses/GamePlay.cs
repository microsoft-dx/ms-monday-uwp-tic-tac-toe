using TicTacToe.Interfaces;

namespace TicTacToe.AbstractClasses
{
    abstract class Game : IGame
    {
        public static int turn = 0;
        public static int[,] moves = new int[3, 3];
        public static bool isWonByXPlayer;
        public static bool isWonBy0Player;
        private const int numberOfRowsAndColumns = 3;
        private const int maximumNumberOfTurns = 9;

        public bool IsOver()
        {
            return turn == maximumNumberOfTurns;
        }

        public void Restart()
        {
            int row, column;

            for (row = 0; row < numberOfRowsAndColumns; row++)
                for (column = 0; column < numberOfRowsAndColumns; column++)
                    moves[row, column] = 0;

            turn = 0;

            isWonBy0Player = false;
            isWonByXPlayer = false;
        }

        public void UpdateStatus()
        {
            for (int row = 0; row < numberOfRowsAndColumns; row++)
                isCompleteLine(row);

            for (int column = 0; column < numberOfRowsAndColumns; column++)
                isCompleteColumn(column);

            isCompleteFirstDiagonal();
            isCompleteSecondDiagonal();
        }

        private void isCompleteSecondDiagonal()
        {
            if (moves[0, 2] == moves[1, 1] && moves[1, 1] == moves[2, 0])
            {
                if (moves[1, 1] == 2)
                    isWonBy0Player = true;

                if (moves[1, 1] == 1)
                    isWonByXPlayer = true;
            }
        }

        private void isCompleteFirstDiagonal()
        {
            if (moves[0, 0] == moves[1, 1] && moves[1, 1] == moves[2, 2])
            {
                if (moves[0, 0] == 2)
                    isWonBy0Player = true;

                if (moves[0, 0] == 1)
                    isWonByXPlayer = true;
            }
        }

        private void isCompleteColumn(int column)
        {
            if (moves[column, 0] == moves[column, 1] && moves[column, 1] == moves[column, 2])
            {
                if (moves[column, 0] == 2)
                    isWonBy0Player = true;

                if (moves[column, 1] == 1)
                    isWonByXPlayer = true;
            }
        }

        private void isCompleteLine(int line)
        {
            if (moves[0, line] == moves[1, line] && moves[1, line] == moves[2, line])
            {
                if (moves[0, line] == 1)
                    isWonByXPlayer = true;

                if (moves[0, line] == 2)
                    isWonBy0Player = true;
            }
        }

        public bool IsXTurn()
        {
            return turn % 2 == 0;
        }

        public bool Is0Turn()
        {
            return turn % 2 != 0;
        }
    }
}

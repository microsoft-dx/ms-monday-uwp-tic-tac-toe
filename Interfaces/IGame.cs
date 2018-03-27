namespace TicTacToe.Interfaces
{
    interface IGame
    {
        void UpdateStatus();

        bool IsOver();
        bool IsXTurn();
        bool Is0Turn();

        void Restart();
    }
}

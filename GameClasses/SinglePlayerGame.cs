using System.Threading.Tasks;
using TicTacToe.AbstractClasses;
using TicTacToe.PlayerClasses;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TicTacToe.GameClasses
{
    class SinglePlayerGame : Game
    {
        public HumanPlayer HumanPlayer { get; set; }
        public ComputerPlayer ComputerPlayer { get; set; }
        Grid MyGrid { get; set; }

        public SinglePlayerGame(Grid myGrid, HumanPlayer humanPlayer, ComputerPlayer computerPlayer)
        {
            MyGrid = myGrid;
            HumanPlayer = humanPlayer;
            ComputerPlayer = computerPlayer;
        }

        public void UpdateMoves(object sender, TappedRoutedEventArgs e)
        {
            var image = (Image)sender;
            var column = Grid.GetColumn((Border)image.Parent);
            var row = Grid.GetRow((Border)image.Parent);

            moves[row, column] = 1;
        }

        public async void MakeMove(object sender, TappedRoutedEventArgs e, Grid myGrid)
        {
            HumanPlayer.InsertX(sender, e);
            UpdateMoves(sender, e);

            await Task.Delay(1000);

            ComputerPlayer.Insert0(myGrid, moves);

            turn++;
        }
    }
}

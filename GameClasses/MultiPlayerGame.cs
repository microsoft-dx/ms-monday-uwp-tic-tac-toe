using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.AbstractClasses;
using TicTacToe.PlayerClasses;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TicTacToe.GameClasses
{
    class MultiPlayerGame : Game
    {
        public HumanPlayer Player1 { get; set; }
        public HumanPlayer Player2 { get; set; }

        public MultiPlayerGame(HumanPlayer player1, HumanPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public void UpdateMoves(object sender, TappedRoutedEventArgs e)
        {
            var image = (Image)sender;
            var column = Grid.GetColumn((Border)image.Parent);
            var row = Grid.GetRow((Border)image.Parent);

            if (IsXTurn())
                moves[row, column] = 1;

            if (Is0Turn())
                moves[row, column] = 2;
        }

        public void InsertX(object sender, TappedRoutedEventArgs e)
        {
            Player1.InsertX(sender, e);

            UpdateMoves(sender, e);
            turn++;
        }

        public void Insert0(object sender, TappedRoutedEventArgs e)
        {
            Player2.Insert0(sender, e);

            UpdateMoves(sender, e);
            turn++;
        }
    }
}

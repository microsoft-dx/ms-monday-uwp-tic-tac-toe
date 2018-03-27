using System;
using TicTacToe.Interfaces;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TicTacToe.PlayerClasses
{

    class ComputerPlayer : IPlayer
    {
        public string Name { get; set; }

        public ComputerPlayer(string name)
        {
            Name = name;
        }

        public void Insert0(Grid myGrid, int[,] moves)
        {
            var bitmapImage = new BitmapImage(new Uri("ms-appx:///Assets//0Image.png"));

            FindMove(myGrid, moves, bitmapImage);
        }

        private static void FindMove(Grid myGrid, int[,] moves, BitmapImage bitmapImage)
        {
            for (int i = 0; i < 3; i++)
                if (isPossibleToMoveHere(moves, i, i))
                {
                    MoveHere(myGrid, moves, bitmapImage, i, i);
                    return;

                }

            for (int i = 1; i < 3; i++)
                if (isPossibleToMoveHere(moves, 0, i))
                {
                    MoveHere(myGrid, moves, bitmapImage, 0, i);
                    return;

                }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (isPossibleToMoveHere(moves, i, j))
                    {
                        MoveHere(myGrid, moves, bitmapImage, i, j);
                        return;

                    }
        }

        private static bool isPossibleToMoveHere(int[,] moves, int i, int j)
        {
            return moves[i, j] == 0;
        }

        private static void MoveHere(Grid myGrid, int[,] moves, BitmapImage bitmapImage, int i, int j)
        {
            var image = (myGrid.Children[i * 3 + j] as Border).Child as Image;
            image.Source = bitmapImage;

            moves[i, j] = 2;
        }

    }
}

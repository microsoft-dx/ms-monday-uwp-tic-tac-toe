using System;
using TicTacToe.Interfaces;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace TicTacToe.PlayerClasses
{
    class HumanPlayer : IPlayer
    {
        public string Name { get; set; }

        public HumanPlayer(string name)
        {
            Name = name;
        }

        public void InsertX(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets//XImage.png"));
        }

        public void Insert0(object sender, TappedRoutedEventArgs e)
        {
            var image = sender as Image;
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets//0Image.png"));
        }
    }
}
